package com.example.Users.Addresses;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class AddressesList extends ArrayList<Address> {

    public AddressesList()
    {
        super();
    }

    public AddressesList(Collection<? extends Address> addresses)
    {
        this();
        addAll(addresses);
    }

    public AddressesList(List<Address> addresses)
    {
        this();
        addAll(addresses);
    }

    public AddressesList(ArrayList<Address> addresses)
    {
        this();
        addAll(addresses);
    }

    public AddressesList(AddressesList addresses)
    {
        this();
        addAll(addresses);
    }



    public AddressesList(JSONArray array)
    {
        this();
        SetJson(array);
    }

    public AddressesList(String arrayJson)
    {
        this();
        SetJson(arrayJson);
    }

    public TypeAddress AddressType = TypeAddress.Telefon;

    public void SetList(Collection<? extends Address> addresses)
    {
        clear();
        addAll(addresses);
    }

    public void SetJson(JSONArray array)
    {

        clear();
        for(int i = 0; i < array.length(); i++)
        {
            try {
                JSONObject object = array.getJSONObject(i);
                Address address = new Address(object);
                address.TypeAddress = AddressType;
                add(address);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }

    public void SetJson(String jsonArray)
    {
        try {
            SetJson(new JSONArray(jsonArray));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public String GetUrlType()
    {
        if(AddressType == com.example.Users.Addresses.TypeAddress.Telefon)
        {
            return "telefons";
        }
        else
        {
            return "emails";
        }
    }

}
