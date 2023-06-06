package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.Configuration.ChangeEvent;
import com.example.DB.Helper;
import com.example.Orders.Order;
import com.example.Orders.OrdersList;
import com.example.Traid.TraidHelper;
import com.example.Users.UsersHelper;

import org.json.JSONException;
import org.json.JSONObject;

public class OrdersActivity extends AppCompatActivity {

    EditText orderNumber;

    boolean run = true, get = true;
    OrdersList orders = new OrdersList();
    ArrayAdapter<Order> ordersAdapter;
    ListView ordersView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_orders);
        orderNumber = findViewById(R.id.editTextOrderNumber);
        orderNumber.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                Update_Click();
            }
        });

        ordersView = findViewById(R.id.listViewOrders);
        ordersAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        ordersView.setAdapter(ordersAdapter);
        ordersView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                try {

                    Intent i = new Intent(GetContext(), OrderActivity.class);
                    i.putExtra("id", orders.get(position).ID);
                    startActivityForResult(i, 200);
                }
                catch (Exception e)
                {

                }
            }
        });

        getDatas();
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

    public void Exit(View v)
    {
        finish();
    }

    public void Update_Click(View v)
    {
        Update_Click();
    }

    public void Update_Click()
    {
        get = false;
        GetDatas();
        get = true;
    }

    public void NumberClear(View v)
    {
        orderNumber.setText("");
    }


    @Override
    public void finish() {
        run = false;
        super.finish();
    }

    Activity GetContext()
    {
        return this;
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode) {
        get = false;
        super.startActivityForResult(intent, requestCode);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        GetDatas();

        get = true;
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void GetDatas()
    {
        ChangeEvent event = new ChangeEvent()
        {
            @Override
            public void Run(String text) {
                GetOrders();
            }
        };
        UsersHelper.GetDatas(GetActivity(), event, false);
    }

    public void GetOrders()
    {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    orders.SetJson(res.Body);
                    ordersAdapter.clear();
                    ordersAdapter.addAll(orders);
                    ordersAdapter.notifyDataSetChanged();
                } catch (Exception e) {
                    e.printStackTrace();
                }

            }

            @Override
            public void GetResultFail(ResultOfAPI res) {

                if(res.Code == 401)
                {
                    String error = "Вы не авторизированы в системе";

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Список заказов (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 403)
                {
                    String error = "Вы не имеете роль клиента";

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Список заказов (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code >= 500)
                {
                    String error = ErrorMessage();

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Список заказов (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;
        String url = Helper.GetUrlAddress(this)+"/orders";
        String filter = orderNumber.getText().toString();
        if(!filter.equals(""))
            url+="?numberFilter="+filter;
        api.GET(url, true);


    }

    void runDatas()
    {
        while(run) {
            if (get) {

                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        GetDatas();
                    }
                });

                try {
                    Thread.sleep(UsersHelper.GetRandomMilliSeconds());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    boolean getRun()
    {
        return run;
    }


    void getDatas()
    {
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                runDatas();
            }
        };
        Thread thread = new Thread(runnable);
        thread.start();
    }

    public Activity GetActivity()
    {
        return this;
    }


}