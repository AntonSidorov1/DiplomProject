package com.example.Users.Addresses;

import android.app.Activity;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;

public class AddressAPI extends ApiClientWithMessage {
    public AddressAPI(Activity ctx) {
        super(ctx);
        GetMessageReady = false;
    }

    @Override
    public void GetResultReady(ResultOfAPI res) {
        GetReady(res);
        AddressesList addresses = new AddressesList(res.Body);
        GetAddressesReady(addresses);
    }

    public void GetReady(ResultOfAPI res)
    {

    }

    public void GetAddressesReady(AddressesList addresses)
    {

    }
}
