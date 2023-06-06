package com.example.Users;

import android.app.Activity;
import android.content.Context;
import android.widget.EditText;
import android.widget.TextView;

import com.example.API.ApiClient;
import com.example.API.ConnectConfig;
import com.example.API.ResultOfAPI;
import com.example.Configuration.ChangeEvent;
import com.example.DB.DB;
import com.example.DB.Helper;
import com.example.Users.Addresses.TypeAddress;
import com.example.Users.FIO.FIO;
import com.example.musicshopmobileapp.BuildConfig;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Random;

public class UsersHelper {

    public static String Login = "";

    public static FIO FIO = new FIO();


    public static void GetDatas(Activity context, Boolean fio)
    {
        GetDatas(context, new ChangeEvent(), fio);
    }

    public static void GetDatas(Activity context, ChangeEvent event, Boolean fio)
    {
        TextView view = new EditText(context);
        GetDatas(view, view, context, event, fio);
    }

    public static void GetDatas
            (TextView ulr, TextView login, Activity context, Boolean fio)
    {
        GetDatas(ulr, login, context, new ChangeEvent(), fio);
    }

    public static void GetDatas
            (TextView ulr, TextView login, Activity context, ChangeEvent event, Boolean fio)
    {
        GetURL(ulr, context);


            GetLogin(login, context, event, fio);
    }


    public static void GetURL(TextView url, Activity context)
    {
        url.setText(Helper.GetUrlAddress(context));
    }

    public static void GetLogin(TextView login, Activity context, Boolean fio)
    {
        GetLogin(login, context, new ChangeEvent(), fio);
    }



    public static void GetLogin(TextView login, Activity context, ChangeEvent event, Boolean fio) {

        TextView textViewLogin = login;
        String token = ConnectConfig.GetToken(context);
        LoginAPI loginAPI = new LoginAPI(context) {
            @Override
            public void on_fail(ResultOfAPI req, String message) {
                if (req.Code == 401) {
                    runGoest(login, GetActivity(), event, fio);
                    return;
                }
                on_fail(message);
            }

            @Override
            public void on_fail(String req) {
                login.setText("");
            }

            @Override
            public void GetLogin(User login) {

                textViewLogin.setText(login.GetOutputData(fio));
                event.Run(login.login);
            }
        };
        loginAPI.Get(Helper.GetUrlAddress(context) + "/accounts/data");

    }



    static void runGoest(TextView login, Activity ctx, ChangeEvent event, Boolean fio)
    {
        JSONObject object = new JSONObject();
        try {
            object.put("environtmentToken", Helper.EnvirontmentSession);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String body = object.toString();
        ApiClient apiClient = new ApiClient(ctx)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if (res.Code == 401) {

                    throw new Exception("Вы больше не авторизированы");
                }
                JSONObject object = new JSONObject(res.Body);
                ConnectConfig.Token = object.getString("jwtToken");

                ConnectConfig.SetToken(GetActivity(), ConnectConfig.Token);

                GetLogin(login, ctx, event, fio);
            }

            @Override
            public void on_fail(ResultOfAPI res, String req) {
                runEnvirontment(login,true, GetActivity(), event, fio);
            }

            @Override
            public void on_fail(String req) {

            }
        };
        apiClient.POST(Helper.GetUrlAddress((ctx))+"/sessions/goest", body, false);
    }

    static void runEnvirontment(TextView login, boolean runGoest, Activity ctx, ChangeEvent event, Boolean fio)
    {
        JSONObject object = new JSONObject();
        JSONObject device = new JSONObject();
        JSONObject app = new JSONObject();
        JSONObject browser = new JSONObject();

        try {
            device.put("name", "Android");
            device.put("operationSystem", System.getProperty("os.name") + " " +System.getProperty("os.version"));
            object.put("device", device);
            app.put("name", ctx.getPackageName());
            app.put("version", BuildConfig.VERSION_CODE + " - " + BuildConfig.VERSION_NAME);
            object.put("application", app);
            browser.put("use", false);
            object.put("browser", browser);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String body = object.toString();

        ApiClient  apiClient = new ApiClient(ctx)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {

                JSONObject object = new JSONObject(res.Body);
                Helper.EnvirontmentSession = object.getString("environtmentToken");

                if(runGoest)
                    runGoest(login, GetActivity(), event, fio);
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
            }

            @Override
            public void on_fail(String req) {
            }
        };
        apiClient.POST(Helper.GetUrlAddress((ctx))+"/environtment-token/open", body, false);
    }


    public static void GetRole(TextView roleEng, TextView roleRus, TextView login, Activity context, Boolean fio)
    {
        GetRole(roleEng, roleRus, login, context, new ChangeEvent(), fio);
    }

    public static void GetRole(TextView roleEng, TextView roleRus, TextView login, Activity context, ChangeEvent event, Boolean fio)
    {


        String token = ConnectConfig.GetToken(context);
        if(token.length() > 0) {
            RoleApi roleAPI = new RoleApi(context) {
                @Override
                public void on_fail(String req) {

                    roleEng.setText("");
                    roleRus.setText("");
                    DB.GetDB(context).TokenClear();
                    GetLogin(login, context, fio);
                }

                @Override
                public void GetRole(String nameRus, String nameEng, Role role) {
                    roleRus.setText(nameRus);
                    roleEng.setText(nameEng);
                    Role = role;
                    event.Run(Role);
                }
            };
            roleAPI.Get(Helper.GetUrlAddress(context) + "/users/get-role");
        }
    }

    public static Role Role;

    public static boolean RoleIsAdmin(Context context)
    {
        if(!DB.GetDB(context).HaveToken())
        {
            return false;
        }
        try
        {
            String role = Role.NameEng;
            return role.equals("admin") || role.equals("Admin");
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public static boolean RoleIsClient(Context context)
    {
        if(!DB.GetDB(context).HaveToken())
        {
            return false;
        }
        try
        {
            String role = Role.NameEng;
            return role.equals("client") || role.equals("Client");
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public static TypeAddress AddressType = TypeAddress.Telefon;

    public static String GetAddressType(Boolean only)
    {
        if(AddressType == TypeAddress.Telefon)
        {
            String telefon = "Телефон";
            if(only)
                return telefon;
            else
                return telefon+"ы";
        }
        else
        {
            String telefon = "Email-адрес";
            if(only)
                return telefon;
            else
                return telefon+"а";
        }
    }

    public static Random Random = new Random();

    public static int GetRandomNumber(int number)
    {
        return Random.nextInt(number)+1;
    }

    public  static int GetRandomNumber()
    {
        return GetRandomNumber(10);
    }

    public static int GetRandomNumberMilliSeconds()
    {
        return GetRandomNumber() *
                GetRandomNumber() *
                GetRandomNumber() *
                GetRandomNumber(5);
    }

    public static int GetRandomMilliSeconds()
    {
        int number = 5000;
        boolean rand = Random.nextBoolean();
        if(rand)
        {
            number += GetRandomNumberMilliSeconds();
        }
        return number * 6;
    }

}
