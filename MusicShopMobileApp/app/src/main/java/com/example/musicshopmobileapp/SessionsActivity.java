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
import com.example.DB.Helper;
import com.example.Users.Addresses.Address;
import com.example.Users.Addresses.AddressAPI;
import com.example.Users.Addresses.AddressesList;
import com.example.Users.Sessions.SessionWithEnvirontment;
import com.example.Users.Sessions.SessionWithEnvirontmentAPI;
import com.example.Users.Sessions.SessionWithEnvirontmentList;
import com.example.Users.UsersHelper;

public class SessionsActivity extends AppCompatActivity {

    EditText session;
    TextView sessionEdit;
    ListView listViewSessions;

    ArrayAdapter<SessionWithEnvirontment> sessionsAdapter;
    SessionWithEnvirontmentList sessions;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sessions);


        listViewSessions = findViewById(R.id.listViewSessions);
        sessionsAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        listViewSessions.setAdapter(sessionsAdapter);
        listViewSessions.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                SessionWithEnvirontment address = sessions.get(position);
                AddressInfo(address);
            }
        });

        sessions = new SessionWithEnvirontmentList();

        RunDatasChange();
    }


    public void CloseAll_Click(View v)
    {
        run1 = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);
        builder.setTitle("Закрытие всех сессий");
        builder.setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                CloseAll();
            }
        });
        builder.setNegativeButton("Нет", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                run1 = true;
            }
        });

        AlertDialog dialog = builder.create();
        dialog.setMessage("Вы действительно хотите закрыть все сессии, кроме текущей?");
        dialog.show();
    }

    void CloseAll() {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResult(ResultOfAPI res) {
                GetDatas();
                run1 = true;
            }
        };
        api.TitleMessage = "Закрытие всех сессий";
        api.MessageReady = "Все сессии, кроме текущей, успешно закрыты";
        api.MessageFail = "Не удалось закрыть сессии";
        api.DELETE(Helper.GetUrlAddress(this)+"/sessions/close-all", true);
    }

    boolean get = false;

    public void GetDatas()
    {
        GetDatas(20);
    }

    public void UpdateSessions_Click(View v)
    {
        GetDatas();
    }

    boolean run = true, run1 = true;

    boolean runFail = true;
    public void GetDatas(int count)
    {
        get = run1;
        run1 = false;

        SessionWithEnvirontmentAPI api = new SessionWithEnvirontmentAPI(this)
        {
            @Override
            public void GetAddressesReady(SessionWithEnvirontmentList list) {
                sessions.SetList(list);
                sessionsAdapter.clear();
                sessionsAdapter.addAll(sessions);
                sessionsAdapter.notifyDataSetChanged();
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

        api.TitleMessage = "Вывод "+ UsersHelper.GetAddressType(true)+"ов";
        api.MessageFail = "Вы больше не авторизированы в системе";

        api.GetMessageFailOutput = count < 1;
        api.StopFail = true;

        api.GET(Helper.GetUrlAddress(this)+"/sessions/get-sessions", true);

    }

    void AddressInfo(SessionWithEnvirontment address)
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

        if(address.Closing()) {
            builder.setNegativeButton("Закрыть", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    ApiClientWithMessage api = new ApiClientWithMessage(GetContext()) {
                        @Override
                        public void GetResult(ResultOfAPI res) {
                            GetDatas();
                            run1 = true;
                        }
                    };

                    api.TitleMessage = "Закрытие сессии";
                    api.MessageReady = "Сессия успешно закрыта";
                    api.MessageFail = "Не удалось закрыть сессию " + "\n" +
                            " - Возможно она больше не существует \n" +
                            " - Возможно она больше не активна";

                    api.PUT(Helper.GetUrlAddress(GetContext())+"/sessions/close", address.GetSessionJsonText(), false);
                }
            });
        }

        AlertDialog dialog = builder.create();
        dialog.setMessage(address.FullDescription);
        dialog.show();

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

    @Override
    public void finish() {
        run = false;
        runFail = false;
        super.finish();
    }


}