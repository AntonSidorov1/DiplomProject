package com.example.Users;

import android.app.Activity;

import com.example.API.ApiClient;
import com.example.API.ResultOfAPI;

import org.json.JSONObject;

public class LoginAPI extends ApiClient {
    public LoginAPI(Activity ctx) {
        super(ctx);
    }

    public void Get(String url)
    {
        GET(url, true);
    }

    @Override
    public void ready_result(ResultOfAPI res) throws Exception {
        super.ready_result(res);

        if(res.Code != 200)
        {
            throw new Exception();
        }
		if(res.Body.equals("null") || res.Body.equals(""))
		{
			throw new Exception();
		}

        JSONObject object = new JSONObject(res.Body);
        String login = object.getString("login");

        GetLogin(login);

        User user = new User();
        try
        {

            user.SetJson(res.Body);
        }
        catch (Exception e)
        {
            user.login = login;
        }
        GetLogin(user);
    }

    public void GetLogin(String login)
    {

    }

    public void GetLogin(User user)
    {

    }

    @Override
    public void on_fail(ResultOfAPI req, String message) {
        on_fail(req.URL);
    }
}
