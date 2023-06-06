package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.Configuration.ChangeEvent;
import com.example.DB.Helper;
import com.example.Users.Addresses.Address;
import com.example.Users.Addresses.AddressAPI;
import com.example.Users.Addresses.AddressesList;
import com.example.Users.UsersHelper;
import com.example.musicshopmobileapp.R;

public class AddressesActivity extends AppCompatActivity {

    EditText address;
    TextView addressEdit;
    ListView listViewAddresses;

    ArrayAdapter<Address> addressesAdapter;
    AddressesList addresses;

    boolean run = true, run1 = true;

    @Override
    public void finish() {
        run = false;
        runFail = false;
        super.finish();
    }

    String url;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_addresses);

        address = findViewById(R.id.editTextAddressEdit);
        address.setText("");

        addressEdit = findViewById(R.id.textViewAddress);
        addressEdit.setText(UsersHelper.GetAddressType(false));

        listViewAddresses = findViewById(R.id.listViewAddresses);
        addressesAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        listViewAddresses.setAdapter(addressesAdapter);
        listViewAddresses.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Address address = addresses.get(position);
                AddressInfo(address);
            }
        });

        addresses = new AddressesList();
        addresses.AddressType = UsersHelper.AddressType;

        url = Helper.GetUrlAddress(this) +"/"+ addresses.GetUrlType();

        RunDatasChange();
    }

    void AddressInfo(Address address)
    {
        run1 = false;

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);

        builder.setTitle("Просмотр "+UsersHelper.GetAddressType(true).toLowerCase()+"а");
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                run1 = true;
            }
        });

        builder.setNegativeButton("Удалить", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                ApiClientWithMessage api = new ApiClientWithMessage(GetContext())
                {
                    @Override
                    public void GetResult(ResultOfAPI res) {
                        run1 = true;
                    }
                };

                api.TitleMessage = "Удаление "+UsersHelper.GetAddressType(true).toLowerCase()+"а";
                api.MessageReady = UsersHelper.GetAddressType(true) + " успешно удалён";
                api.MessageFail = "Не удалось удалить " + UsersHelper.GetAddressType(true).toLowerCase() +"\n" +
                        "Возможно он не существует";

                api.DELETE(url+"/"+address.ID, true);
            }
        });

        AlertDialog dialog = builder.create();
        dialog.setMessage(address.Value);
        dialog.show();

    }

    public void Exit(View v)
    {
        finish();
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        if(item.getItemId() == R.id.ExitItem)
        {
            finish();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    int maxCount = 50;
    int countGet = 20;

    boolean get = false;

    public void GetDatas()
    {
        GetDatas(20);
    }

    public  void UpdateAddresses_Click(View v)
    {
        GetDatas();
    }

    boolean runFail = true;
    public void GetDatas(int count)
    {
        get = run1;
        run1 = false;

        AddressAPI api = new AddressAPI(this)
        {
            @Override
            public void GetAddressesReady(AddressesList list) {
                addresses.SetList(list);
                addressesAdapter.clear();
                addressesAdapter.addAll(addresses);
                addressesAdapter.notifyDataSetChanged();
                run1 = get;
            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                if (!runFail) {
                    return;
                }
                if (count > 0) {
                    GetDatas(count - 1);
                    return;
                }
                finish();
            }
        };

        api.TitleMessage = "Вывод "+UsersHelper.GetAddressType(true)+"ов";
        api.MessageFail = "Вы больше не авторизированы в системе";

        api.GetMessageFailOutput = count < 1;
        api.StopFail = true;

        api.GET(url, true);

    }

    public void Clear_Click(View v)
    {
        address.setText("");
    }

    public void AddressAdd_Click(View v)
    {
        String address = this.address.getText().toString();

        Address addressValue = new Address();
        addressValue.Value = address;
        addressValue.TypeAddress = addresses.AddressType;

        String json = addressValue.GetAddressJson();

        run1 = false;
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResult(ResultOfAPI res) {
                run1 = true;
            }
        };

        api.TitleMessage = "Добавление "+UsersHelper.GetAddressType(true).toLowerCase()+"а";
        api.MessageReady = UsersHelper.GetAddressType(true) + " успешно добавлен";
        api.MessageFail = "Не удалось добавить " + UsersHelper.GetAddressType(true).toLowerCase() +"\n" +
                "Возможно он уже существует";

        api.POST(url, json, true);

    }

    public void RunDatasChange()
    {
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                while(run)
                {
                    if(run1)
                    {
                        GetContext().runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                GetDatas();
                            }
                        });
                    }
                    try {
                        Thread.sleep(UsersHelper.GetRandomMilliSeconds());
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        };

        Thread thread = new Thread(runnable);
        thread.start();
    }

    public Activity GetContext()
    {
        return this;
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode) {
        GetDatas();
        run1 = false;
        super.startActivityForResult(intent, requestCode);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {

        GetDatas();
        run1 = true;
        super.onActivityResult(requestCode, resultCode, data);
    }


}