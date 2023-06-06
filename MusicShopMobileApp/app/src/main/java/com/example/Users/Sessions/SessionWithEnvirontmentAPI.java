package com.example.Users.Sessions;

import android.app.Activity;

import com.example.API.ApiClient;
import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.Users.Addresses.AddressesList;

public class SessionWithEnvirontmentAPI extends ApiClientWithMessage {
    public SessionWithEnvirontmentAPI(Activity ctx) {
        super(ctx);
        GetMessageReady = false;
    }


    @Override
    public void GetResultReady(ResultOfAPI res) {
        GetReady(res);
        SessionWithEnvirontmentList addresses = new SessionWithEnvirontmentList(res.Body);
        GetAddressesReady(addresses);
    }

    public void GetReady(ResultOfAPI res)
    {

    }

    public void GetAddressesReady(SessionWithEnvirontmentList addresses)
    {

    }
}
