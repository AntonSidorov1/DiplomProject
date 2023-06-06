package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.API.ApiClient;
import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Users.FIO.FIO;
import com.example.Users.User;
import com.example.Users.UsersHelper;

import org.json.JSONException;
import org.json.JSONObject;

public class FIOActivity extends AppCompatActivity {

    String login = "";
    FIO FIO = new FIO();

    TextView loginTextView, FioTextView;
    EditText editTextFIO;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fioactivity);

        login = UsersHelper.Login;
        FIO = UsersHelper.FIO;

        loginTextView = findViewById(R.id.textViewLoginFIO);
        loginTextView.setText(login);

        FioTextView = findViewById(R.id.textViewFioOutput);
        FioTextView.setText(FIO.GetFIO());

        editTextFIO = findViewById(R.id.editTextFIO);
        editTextFIO.setText(FIO.GetFIO());

    }

    public void Exit_Click(View v)
    {
        finish();
    }

    public void Cancel_Click(View v)
    {

        editTextFIO = findViewById(R.id.editTextFIO);
        editTextFIO.setText(FIO.GetFIO());
    }

    public void Clear_Click(View v)
    {
        editTextFIO.setText("");
    }

    public void Save_Click(View v)
    {
        FIO fio = new FIO(editTextFIO.getText().toString());
        String body = fio.GetJson();

        JSONObject object = new JSONObject();
        try {
            object = new JSONObject(body);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        body = object.toString();

        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                UpdateUser();
            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                Error();
            }

        };
        api.TitleMessage = "Редактирование ФИО";
        api.MessageReady = "ФИО успешно изменены";
        api.MessageFail = "Не удалось поменять ФИО \n" +
                "   - Возможно вы уже неавторизированы в системе \n";
        api.PATCH(Helper.GetURL(this).GetURL()+"/accounts/change-fio/by-jwt", body, true);

    }

    void UpdateUser()
    {
        ApiClient apiClient = new ApiClient(this)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if (res.Code == 401) {

                    throw new Exception("Вы больше не авторизированы");
                }

                User user = new User();
                user.SetJson(res.Body);

                UsersHelper.Login = user.login;

                try {
                    UsersHelper.FIO = user.FIO;
                } catch (Exception e) {
                    UsersHelper.FIO = new FIO();
                }

                login = UsersHelper.Login;
                FIO = UsersHelper.FIO;

                loginTextView = findViewById(R.id.textViewLoginFIO);
                loginTextView.setText(login);

                FioTextView = findViewById(R.id.textViewFioOutput);
                FioTextView.setText(FIO.GetFIO());

                Success();
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                Error();
            }
        };

        apiClient.GET(Helper.GetUrlAddress((this))+"/accounts/data", true);
    }

    void Error()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Редактирование ФИО (Ошибка!!!)");
        builder.setCancelable(false);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                finish();
            }
        });

        AlertDialog dialog = builder.create();
        dialog.setMessage("Вы не авторизированы в системе");
        dialog.show();

        Toast.makeText(this, "Вы не авторизированы в системе", Toast.LENGTH_SHORT).show();

    }

    void Success()
    {

        Toast.makeText(this, "Вы успешно изменили ФИО", Toast.LENGTH_SHORT).show();

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

}