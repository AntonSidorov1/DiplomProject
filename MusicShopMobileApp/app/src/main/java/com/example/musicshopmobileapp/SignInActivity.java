package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.text.method.HideReturnsTransformationMethod;
import android.text.method.PasswordTransformationMethod;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.API.ApiClient;
import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.Authofication.SignIn;
import com.example.Configuration.ChangeEvent;
import com.example.DB.Account;
import com.example.DB.DB;
import com.example.DB.Helper;
import com.example.Users.User;
import com.example.Users.UsersHelper;

import org.json.JSONException;
import org.json.JSONObject;

public class SignInActivity extends AppCompatActivity {


    TextView url, doing;
    CheckBox showPassword, signInWithAccount;
    Button signIn;
    String doingText;
    EditText login, password;
    TextView loginText, passwordText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);

        Intent i = getIntent();

        url = findViewById(R.id.textViewSignInURL);
        doing = findViewById(R.id.textViewSignInDoing);
        signIn = findViewById(R.id.buttonSignIn);

        doingText = i.getStringExtra("Doing");
        showPassword = findViewById(R.id.checkBoxShowPassword);
        CheckBox show = showPassword;
        signInWithAccount = findViewById(R.id.checkBoxSignInYes);

        login = findViewById(R.id.editTextLoginInput);
        password = findViewById(R.id.editTextPasswordInput);
        loginText = findViewById(R.id.textViewLoginInputText);
        passwordText = findViewById(R.id.textViewPasswordInputText);

        login.setText("");
        password.setText("");

        password.setTransformationMethod(PasswordTransformationMethod.getInstance());

        show.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean isChecked) {
                if(!isChecked)
                    password.setTransformationMethod(PasswordTransformationMethod.getInstance());
                else
                    password.setTransformationMethod(HideReturnsTransformationMethod.getInstance());
            }
        });

        if(!doingText.equals("client")) {
            signInWithAccount.setVisibility(View.INVISIBLE);
        }
        else
        {
            signInWithAccount.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                @Override
                public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                }
            });
        }

        doing.setText(i.getStringExtra("doingText"));
        SetButtonText(i.getStringExtra("buttonSignIn"));

        if(doingText.equals("input"))
        {
            signIn.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    SignIn_Click(v);
                }
            });

        }
        else {
            if (doingText.equals("client")) {
                signIn.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Registrate_Click(v);
                    }
                });
            }
            else if(doingText.equals("admin"))
            {
                signIn.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        AddAdmin_Click(v);
                    }
                });
            }
            else if(doingText.equals("password"))
            {
                login.setVisibility(View.INVISIBLE);
                loginText.setText(i.getStringExtra("login"));
                passwordText.setText("Новый пароль");

                signIn.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        ChangePassword_Click(v);
                    }
                });

                ApiClient apiClient = new ApiClient(this)
                {
                    @Override
                    public void ready_result(ResultOfAPI res) throws Exception {
                        if(res.Code != 200)
                            throw  new Exception();

                        User user = new User();
                        user.SetJson(res.Body);

                        password.setText(user.password);
                    }

                    @Override
                    public void on_fail(ResultOfAPI res, String message) {
                        on_fail(message);
                    }

                    @Override
                    public void on_fail(String req) {

                    }
                };
                apiClient.GET(Helper.GetUrlAddress(this) + "/accounts/data", true);

            }
        }

        GetDatas();
    }
    
    public void ChangePassword()
    {
        String body = "";

        JSONObject object = new JSONObject();
        try {
            object.put("password", password.getText().toString());
        } catch (JSONException e) {
            e.printStackTrace();
        }
        body = object.toString();

        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                finish();
            }
        };
        api.TitleMessage = "Смена пароля";
        api.MessageReady = "Пароль успешно сменен";
        api.MessageFail = "Не удалось сменить пароль \n" +
                "   - Возможно вы уже неавторизированы в системе \n";
        api.PATCH(Helper.GetURL(this).GetURL()+"/accounts/change-password/by-jwt", body, true);

    }

    public void ChangePassword_Click(View v)
    {
        String password = this.password.getText().toString();
        if(!password.equals(""))
        {
            ChangePassword();
            return;
        }

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Смена пароля");
        builder.setCancelable(false);

        builder.setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                ChangePassword();
            }
        });
        builder.setNegativeButton("Нет", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });

        AlertDialog dialog = builder.create();
        dialog.setMessage("Пользователь без пароля уязвим \n" +
                "Вы согласны с этим?");
        dialog.show();
    }

    public void SignIn_Click(View v)
    {
        ApiClient apiClient = new ApiClient(this)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {

                JSONObject object = new JSONObject(res.Body);
                Helper.EnvirontmentSession = object.getString("environtmentToken");

                SignIn(Helper.EnvirontmentSession);
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                AlertDialog.Builder dialog = new AlertDialog.Builder(GetActivity());
                dialog.setTitle(message);

                dialog.setCancelable(false);
                dialog.setPositiveButton("ОК", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                    }
                });

                AlertDialog dlg = dialog.create();
                if(res.Body != null) {
                    dlg.setMessage(res.Body);
                }
                dlg.show();

                Toast.makeText(GetActivity(), message, Toast.LENGTH_SHORT);
            }

            @Override
            public void on_fail(String req) {
                String message = "Неудалось войти в систему";
                ResultOfAPI res = new ResultOfAPI();
                res.Body = ErrorMessage();
                res.URL = req;
                on_fail(res, message);
            }
        };
        JSONObject object = new JSONObject();
        JSONObject device = new JSONObject();
        JSONObject app = new JSONObject();
        JSONObject browser = new JSONObject();

        try {
            device.put("name", "Android");
            device.put("operationSystem", System.getProperty("os.name") + " " +System.getProperty("os.version"));
            object.put("device", device);
            app.put("name", getPackageName());
            app.put("version", BuildConfig.VERSION_NAME + " " + BuildConfig.VERSION_CODE);
            object.put("application", app);
            browser.put("use", false);
            object.put("browser", browser);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String body = object.toString();

        apiClient.POST(Helper.GetUrlAddress((this))+"/environtment-token/open", body, false);



    }



    void SignIn(String environtment)
    {
        SignIn(environtment, 20);
    }

    boolean runFail = true;
    @Override
    public void finish() {
        runFail = false;
        super.finish();
    }

    void SignIn(String environtment, int count)
    {
        SignIn signIn = new SignIn(this)
        {
            @Override
            public void EndSend() {
                //AfterSignIn();
                finish();
            }

            @Override
            public boolean GetResultFailNoMessage(ResultOfAPI res, String message) {
                if(!runFail)
                {
                    return false;
                }
                if(count > 0)
                {
                    SignIn(environtment, count -1);
                    return false;
                }
                return true;

            }
        };

        String login = this.login.getText().toString();
        String password = this.password.getText().toString();

        String address = Helper.GetUrlAddress((this)) + "/sessions/sign-in";
        signIn.GetMessageFail = false;
        signIn.StopFail = true;
        signIn.send(address, login, password, environtment);
    }

    public void Registrate_Click(View v)
    {
        String password = this.password.getText().toString();
        if(!password.equals(""))
        {
            Registrate(v);
            return;
        }

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Смена пароля");
        builder.setCancelable(false);

        builder.setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Registrate(v);
            }
        });
        builder.setNegativeButton("Нет", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });

        AlertDialog dialog = builder.create();
        dialog.setMessage("Пользователь без пароля уязвим \n" +
                "Вы согласны с этим?");
        dialog.show();
    }

    void Registrate(View v)
    {
        Registrate(v, 20);
    }

    void Registrate(View v, int count)
    {
        ChangeEvent event = new ChangeEvent() {
            @Override
            public void Run(String text) {

                ApiClientWithMessage api = new ApiClientWithMessage(GetContext()) {
                    @Override
                    public void GetResultReady(ResultOfAPI res) {
                        AfterReadyRegistrate(v);
                    }

                    @Override
                    public void GetResultFail(ResultOfAPI res) {
                        if(!runFail)
                        {
                            return;
                        }
                        if(count > 0)
                        {
                            Registrate(v, count-1);
                            return;
                        }
                    }
                };
                api.TitleMessage = "Регистрация в системе";
                api.MessageReady = "Вы успешно зарегистрировались";
                api.MessageFail = "Не удалось зарегистрироваться \n" +
                        "   - Возможно логин уже существует в системе \n" +
                        "   - Возможно логин пустой (должен быть, хотя бы один символ)";

                api.GetMessageFail = count < 1;
                api.StopFail = true;

                api.POST(Helper.GetUrlAddress(GetContext()) + "/accounts/registrate",
                        "{" +
                                "\"login\": \"" + login.getText().toString() + "\"," +
                                "\"password\": \"" + password.getText().toString() + "\"" +
                                "}",
                        true);
            }
        };

        UsersHelper.GetDatas(this, event, true);
    }


    void AfterReadyRegistrate(View v)
    {
        Boolean signIn = signInWithAccount.isChecked();
        if(!signIn)
        {
            finish();
        }
        else
        {
            SignIn_Click(v);
            return;
        }
    }

    public void AddAdmin_Click(View v)
    {
        Account account = new Account();
        account.login = login.getText().toString();
        account.password = password.getText().toString();
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResult(ResultOfAPI res) {
                finish();
            }
        };
        api.TitleMessage = "Добавление админа";
        api.MessageReady = "Админ успешно добавлен";
        api.MessageFail = "Не удалось добавить админа \n" +
                "   - Возможно логин уже существует в системе \n" +
                "   - Возможно пароль совпадает с названием одной из ролей \n" +
                "   - Возможно логин пустой (должен быть, хотя бы один символ) \n" +
                "   - Возможно, вы не являетесь админом, или больше не авторизированы в системе";
        api.POST(Helper.URL.GetURL() + "/users/admins",
                account.GetJson(),
                true);
    }

    void SetButtonText(String text)
    {
        signIn.setText(text);
    }



    public Activity GetContext()
    {
        return this;
    }

    public void GetDatas()
    {
        GetURL();
    }

    public void GetURL()
    {
        url.setText(Helper.GetUrlAddress(GetContext()));
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
            exit();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    void exit()
    {
        finish();
    }

    public void Exit_Click(View v)
    {
        exit();
    }

}