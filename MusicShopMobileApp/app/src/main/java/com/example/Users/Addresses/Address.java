package com.example.Users.Addresses;

import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Type;

public class Address {
    public int ID = 0;
    public String Value = "";

    public Address()
    {
        this(0, "");
    }

    public Address(int id, String value)
    {
        ID = id;
        Value = value;
    }

    public Address(JSONObject object)
    {
        this();

        SetJson(object);
    }

    public Address(String jsonObject)
    {
        this();

        SetJson(jsonObject);
    }


    public void SetJson(JSONObject object)
    {
        try {
            ID = object.getInt("id");
            Value = object.getString("value");
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public void SetJson(String jsonObject)
    {
        try {
            SetJson(new JSONObject(jsonObject));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public JSONObject GetJsonObject()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("id", ID);
            object.put("value", Value);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object;
    }

    public String GetJson()
    {
        return GetJsonObject().toString();
    }

    public JSONObject GetTelefonJsonObject()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("telefon", Value);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object;
    }

    public String GetTelefonJson()
    {
        return GetTelefonJsonObject().toString();
    }

    public JSONObject GetEmailJsonObject()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("email", Value);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object;
    }

    public String GetEmailJson()
    {
        return GetEmailJsonObject().toString();
    }

    public JSONObject GetAddressJsonObject(TypeAddress type)
    {
        if(type == com.example.Users.Addresses.TypeAddress.Email)
        {
            return GetEmailJsonObject();
        }
        else
        {
            return GetTelefonJsonObject();
        }
    }

    public JSONObject GetAddressJsonObject()
    {
        return GetAddressJsonObject(TypeAddress);
    }

    public String GetAddressJson(TypeAddress type)
    {
        return GetAddressJsonObject(type).toString();
    }

    public String GetAddressJson()
    {
        return GetAddressJson(TypeAddress);
    }

    public TypeAddress TypeAddress = com.example.Users.Addresses.TypeAddress.Telefon;

    public String GetUrlType()
    {
        if(TypeAddress == com.example.Users.Addresses.TypeAddress.Telefon)
        {
            return "telefons";
        }
        else
        {
            return "emails";
        }
    }



    @Override
    public String toString() {
        return Value;
    }
}

