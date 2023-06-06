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
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.API.ApiClient;
import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.Configuration.ChangeEvent;
import com.example.Configuration.FormatClass;
import com.example.DB.DB;
import com.example.DB.Helper;
import com.example.Users.Addresses.TypeAddress;
import com.example.Users.User;
import com.example.Users.UsersHelper;

import org.json.JSONArray;
import org.json.JSONObject;

public class ProfileActivity extends AppCompatActivity {

    TextView url, login;

    TextView Login()
    {
        return login;
    }

    Button signIn, signOut, registarte, changePassword, dropAccount, userData, buttonFIO, telefons, emails
            , history;

    boolean run = true, run1 = true;

    boolean visibleButton = false;

    @Override
    public void finish() {
        run = false;
        super.finish();
    }

    public void Exit(View v)
    {
        finish();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.profile_main);
        url = findViewById(R.id.textViewURL);

        login = findViewById(R.id.textViewLogin);
        login.setText("");
        login.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                setVisibleButton();
            }
        });

        signIn = findViewById(R.id.buttonLogIn);
        signOut = findViewById(R.id.buttonLogOut);
        registarte = findViewById(R.id.buttonRegistrate);
        changePassword = findViewById(R.id.buttonCahngePassword);
        dropAccount = findViewById(R.id.buttonDropAccount);
        userData = findViewById(R.id.buttonUserData);
        buttonFIO = findViewById(R.id.buttonEditFIO);
        telefons = findViewById(R.id.buttonTelefons);
        emails = findViewById(R.id.buttonEmail);
        history = findViewById(R.id.buttonHistory);

        Intent i = getIntent();
        try {
            login.setText(i.getStringExtra("login"));
        }
        catch (Exception e)
        {

        }

        setVisibleButton();

        GetDatas();
        RunDatasChange();
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

    void setVisibleButton()
    {

        String login = Login().getText().toString().trim();
        boolean visibleButton = login.equals("Goest") || login.equals("") || login.equals("Гость");
        int visible = FormatClass.GetNoVisibleByBool(visibleButton);
        int noVisible = FormatClass.GetVisibleByBool(visibleButton);
        signIn.setVisibility(noVisible);
        registarte.setVisibility(noVisible);
        signOut.setVisibility(visible);
        dropAccount.setVisibility(visible);
        buttonFIO.setVisibility(visible);
        changePassword.setVisibility(visible);
        userData.setVisibility(visible);
        telefons.setVisibility(visible);
        emails.setVisibility(visible);
        history.setVisibility(visible);
    }

    public void UpdateProfile_Click(View v)
    {
        GetDatas();
    }

    boolean get = false;
    public void GetDatas()
    {
        get = run1;
        run1 = false;

        ChangeEvent event = new ChangeEvent()
        {
            @Override
            public void Run() {

                String login = Login().getText().toString();
                if(login.equals("")) {
                    run1 = get;
                    return;
                }
                setVisibleButton();
                run1 = get;
            }
        };

        UsersHelper.GetDatas(url, login, this, event, true);
        event.Run();
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode) {
        GetDatas();
        run1 = true;
        super.startActivityForResult(intent, requestCode);
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

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {

        GetDatas();
        run1 = true;
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void UrlEdit_Click(View v)
    {
        Intent i = new Intent(this, UrlEditActivity.class);
        startActivityForResult(i, 200);
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode, @Nullable Bundle options) {
        run1 = false;
        super.startActivityForResult(intent, requestCode, options);
    }

    public void SignIn_Click(View v)
    {
        Intent i = new Intent(this, SignInActivity.class);
        i.putExtra("Doing", "input");
        i.putExtra("doingText", "Авторизация");
        i.putExtra("buttonSignIn", "Войти");
        startActivityForResult(i, 200);
    }

    public void ChangeProfile_Click(View v)
    {
        SignOut_Click(v, true);
    }

    public void SignOut_Click(View v)
    {
        SignOut_Click(v, false);
    }
    
    public void ChangeProfile(View v)
    {

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Смена аккаунта");

        builder.setNegativeButton("Зарегистрироваться", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                DB.GetDB(GetContext()).TokenClear();
                GetDatas();
                Registrate_Click(v);
            }
        });

        builder.setPositiveButton("Войти", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();
                SignIn_Click(v);
            }

        });

        builder.setNeutralButton("Отмена", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();
            }

        });

        AlertDialog dialog = builder.create();
        dialog.setCancelable(false);
        dialog.setMessage("Каким образом вы хотите сменить аккаунт?");
        dialog.show();
    }

    public void SignOut_Click(View v, boolean change)
    {


        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Выход из аккаунта");
        builder.setCancelable(false);

        builder.setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();

                AfterSignOut();

            }
        });

        builder.setNegativeButton("Нет", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();
                run1 = true;
            }
        });

        AlertDialog dialog = builder.create();
        dialog.setCancelable(false);
        dialog.setMessage("Вы действительно хотите выйти из аккаунта?");
        dialog.show();

    }

    public void AfterSignOut()
    {
        ApiClient apiClient = new ApiClient(this)
        {
            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                ClearToken();
                if(res.Code != 200)
                {
                    throw  new Exception();
                }
                JSONObject object = new JSONObject(res.Body);
                Helper.EnvirontmentSession = object.getString("environtmentToken");
                run1 = true;

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Выход из аккаунта");

                AlertDialog dialog = builder.create();
                dialog.setMessage("Вы успешно вышли из аккаунта");
                dialog.show();
                Toast.makeText(GetActivity(), "Вы успешно вышли из аккаунта", Toast.LENGTH_SHORT).show();
                return;
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Выход из аккаунта (Ошибка!!!)");

                AlertDialog dialog = builder.create();
                dialog.setMessage("Вы не авторизированы в системе");
                dialog.show();

                Toast.makeText(GetActivity(), "Вы не авторизированы в системе", Toast.LENGTH_SHORT).show();

                ClearToken();

                return;
            }
        };
        apiClient.DELETE(Helper.GetUrlAddress(this)+"/sessions/sign-out", true);
    }

    void ClearToken()
    {
        DB.GetDB(this).TokenClear();
        login.setText("Гость");
        setVisibleButton();
    }

    public void Registrate_Click(View v)
    {
        Intent i = new Intent(this, SignInActivity.class);
        i.putExtra("Doing", "client");
        i.putExtra("doingText", "Регистрация");
        i.putExtra("buttonSignIn", "Зарегистрироваться");
        startActivityForResult(i, 200);
    }

    public void ChangePassword_Click(View v)
    {
        Intent i = new Intent(this, SignInActivity.class);
        i.putExtra("Doing", "password");
        i.putExtra("doingText", "Смена пароля");
        i.putExtra("buttonSignIn", "Сменить пароль");
        startActivityForResult(i, 200);
    }

    public void DropAccount_Click(View v)
    {
        run1 = false;
        if(!DB.GetDB(this).HaveToken())
        {
            GetDatas();
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.setTitle("Удаление аккаунта (Ошибка!!!)");
            builder.setCancelable(false);
            builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    run1 = true;
                }
            });

            AlertDialog dialog = builder.create();
            dialog.setMessage("Вы не авторизированы в системе");
            dialog.show();
            Toast.makeText(this, "Вы не авторизированы в системе", Toast.LENGTH_SHORT).show();
            return;
        }


        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Удаление аккаунта");
        builder.setCancelable(false);

        builder.setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                ApiClientWithMessage api = new ApiClientWithMessage(GetContext())
                {
                    @Override
                    public void GetResult(ResultOfAPI res) {
                        DB.GetDB(GetContext()).TokenClear();
                        DB.GetDB(GetContext()).ClearAccount();
                        GetDatas();
                        run1 = true;
                    }
                };
                api.TitleMessage = "Удаление аккаунта";
                api.MessageReady = "Аккаунт успешно удалён";
                api.MessageFail = "Не удалось удалить аккаунт";
                api.DELETE(Helper.GetURL(GetContext()).GetURL() + "/accounts/delete-account", true);
            }
        });

        builder.setNegativeButton("Нет", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();
                run1 = true;
            }
        });

        AlertDialog dialog = builder.create();
        dialog.setCancelable(false);
        dialog.setMessage("Вы действительно хотите удалить аккаунт?");
        dialog.show();
    }

    public void ProgramInfo_Click(View v)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("О приложении");
        builder.setCancelable(false);

        builder.setPositiveButton("ОК", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();
            }
        });

        AlertDialog dialog = builder.create();
        dialog.setCancelable(false);
        dialog.setMessage("Название приложения - " +
                BuildConfig.APPLICATION_ID.replace('.', ',').split(",")[3] +
                " - " +getPackageName()+" \n" +
                "Версия - "+ BuildConfig.VERSION_CODE + " - " + BuildConfig.VERSION_NAME+" \n" +
                "Назначение - Музыкальный магазин \n" +
                "Автор - Сидоров Антон Дмитриевич \n" +
                "URL-адрес сервера - " + Helper.GetUrlAddress(GetContext()));
        dialog.show();
    }

    public void UsersManagment_Click(View v)
    {
        GetDatas();
        if(!UsersHelper.RoleIsAdmin(this))
        {
            Toast.makeText(this, "Вы не являетесь админом", Toast.LENGTH_SHORT);
            return;
        }
        //Intent i = new Intent(this, UsersListActivity.class);
        //startActivityForResult(i, 200);
    }

    public void UserData_Click(View v)
    {
        ApiClient apiClient = new ApiClient(this)
        {
            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if(res.Code != 200)
                    throw  new Exception();

                User user = new User();
                user.SetJson(res.Body);

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Данные пользователя");
                AlertDialog dialog = builder.create();
                dialog.setMessage(user.GetInfo());
                dialog.show();
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                super.on_fail(req);

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Данные пользователя (Ошибка !!!)");
                AlertDialog dialog = builder.create();
                dialog.setMessage("Вы не авторизированы");
                dialog.show();
            }
        };
        apiClient.GET(Helper.GetUrlAddress(this) + "/accounts/data", true);

    }

    public void Telefons_Click(View v)
    {
        UsersHelper.AddressType = TypeAddress.Telefon;
        Intent i = new Intent(this, AddressesActivity.class);
        startActivityForResult(i, 200);

        return;
        /*
        ApiClient apiClient = new ApiClient(this)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if(res.Code != 200)
                    throw  new Exception();

                String telefons = "Телефоны: \n";

                JSONArray array = new JSONArray(res.Body);
                for(int i = 0; i < array.length(); i++)
                {
                    telefons += (i+1)+") "+array.getJSONObject(i).getString("value")+"\n";
                }

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Телефоны");
                AlertDialog dialog = builder.create();
                dialog.setMessage(telefons);
                dialog.show();
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                super.on_fail(req);

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Данные пользователя (Ошибка !!!)");
                AlertDialog dialog = builder.create();
                dialog.setMessage("Вы не авторизированы");
                dialog.show();
            }
        };
        apiClient.GET(Helper.GetUrlAddress(this) + "/telefons", true);

         */

    }

    public void Emails_Click(View v)
    {
        UsersHelper.AddressType = TypeAddress.Email;
        Intent i = new Intent(this, AddressesActivity.class);
        startActivityForResult(i, 200);

        /*
        ApiClient apiClient = new ApiClient(this)
        {
            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if(res.Code != 200)
                    throw  new Exception();

                String telefons = "Email-адреса: \n";

                JSONArray array = new JSONArray(res.Body);
                for(int i = 0; i < array.length(); i++)
                {
                    telefons += (i+1)+") "+array.getJSONObject(i).getString("value")+"\n";
                }

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Телефоны");
                AlertDialog dialog = builder.create();
                dialog.setMessage(telefons);
                dialog.show();
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                super.on_fail(req);

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Данные пользователя (Ошибка !!!)");
                AlertDialog dialog = builder.create();
                dialog.setMessage("Вы не авторизированы");
                dialog.show();
            }
        };
        apiClient.GET(Helper.GetUrlAddress(this) + "/emails", true);

         */

    }

    public void FIO_Click(View v)
    {
        ApiClient apiClient = new ApiClient(this)
        {
            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if(res.Code != 200)
                    throw  new Exception();

                User user = new User();
                user.SetJson(res.Body);

                UsersHelper.FIO = user.FIO;
                UsersHelper.Login = user.login;

                Intent i = new Intent(GetContext(), FIOActivity.class);
                startActivityForResult(i, 200);
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                super.on_fail(req);

                AlertDialog.Builder builder = new AlertDialog.Builder(GetActivity());
                builder.setTitle("Данные пользователя (Ошибка !!!)");
                AlertDialog dialog = builder.create();
                dialog.setMessage("Вы не авторизированы");
                dialog.show();
            }
        };
        apiClient.GET(Helper.GetUrlAddress(this) + "/accounts/data", true);

    }


    public void LoginHistory_Click(View v)
    {
        Intent i = new Intent(this, SessionsActivity.class);
        startActivityForResult(i, 200);
    }


}