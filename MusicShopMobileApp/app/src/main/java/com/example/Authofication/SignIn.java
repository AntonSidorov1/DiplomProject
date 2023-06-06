package com.example.Authofication;

import android.app.Activity;
import android.content.DialogInterface;
import android.util.Log;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;

import com.example.API.ApiClient;
import com.example.API.ConnectConfig;
import com.example.API.ResultOfAPI;

import org.json.JSONObject;

public class SignIn extends ApiClient {

    public SignIn(Activity ctx) {
        super(ctx);
    }

    public void EndSend()
    {

    }

    public void send(String url, String login, String password, String environtment)
    {
        String body = "{" +
                "\"login\": \""+login+"\", " +
                "\"password\": \""+password+"\"," +
                "\"environtmentToken\": \""+environtment+"\"" +
                "}";
        POST(url, body, false);
    }

    @Override
    public void on_fail(String req) {
        String message = "Неудалось войти в систему";
        ResultOfAPI res = new ResultOfAPI();
        res.Body = ErrorMessage();
        res.URL = req;
        on_fail(res, message);

    }

    @Override
    public void ready_result(ResultOfAPI res) throws Exception {
        try {
            if(res.Code == 500)
            {
                res.Body = ErrorMessage();
                on_fail(res, "Неудалось войти в систему");
                return;
            }

            if(res.Code == 400)
            {
                res.Body = "Неверный логин или пароль";
                on_fail(res, "Неудалось войти в систему ("+res.Code+")");
                GetMessageFail = true;
                return;
            }

            if(res.Code == 423)
            {
                res.Body = "Пользователь с данным логином заблокирован";
                on_fail(res, "Неудалось войти в систему ("+res.Code+")");
                GetMessageFail = true;
                return;
            }

            if(res.Code == 406)
            {
                res.Body = "Пользователь с данным логином не имеет ролей в системе";
                on_fail(res, "Неудалось войти в систему ("+res.Code+")");
                GetMessageFail = true;
                return;
            }

            if(res.Code != 200 || res.equals("null"))
            {
                throw new Exception();
            }

            if (res == null) {
                throw new Exception();
            }

            JSONObject json = new JSONObject(res.Body);
            String token = json.getString("jwtToken");
            Log.e("result", token);

            ConnectConfig.SetToken(GetActivity(), token);

            AlertDialog.Builder dialog = new AlertDialog.Builder(GetActivity());
            dialog.setTitle("Вы успешно вошли в систему");
            dialog.setPositiveButton("ОК", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    EndSend();
                }
            });
            AlertDialog dlg = dialog.create();

                dlg.setMessage("Вы успешно вошли в систему");
            dlg.setCancelable(false);
            dlg.show();

            Toast.makeText(GetActivity(), "Вы успешно вошли в систему", Toast.LENGTH_SHORT);
        }
        catch(Exception e)
        {
            res.Body = "Неверный логин или пароль \n" +
                    "Или пользователь заблокирован \n" +
                    "Или пользователь не имеет ролей в системе";
            throw new Exception("Неудалось авторизироваться");
        }



    }

    public boolean GetResultFailNoMessage(ResultOfAPI res, String message)
    {
        return true;
    }

    public void GetFailNoMessage(ResultOfAPI res, String message)
    {
        GetMessageFail = GetResultFailNoMessage(res, message);
        if(GetMessageFail)
            on_fail(res, message);
    }

    @Override
    public void on_fail(ResultOfAPI res, String message) {

        if(!GetMessageFail)
        {
            GetFailNoMessage(res, message);
            return;
        }
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

    public int Count = 20;

    public Boolean GetMessageFail = true;
}
