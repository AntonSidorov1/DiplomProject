package com.example.Users.Sessions;

import com.example.Users.Addresses.Address;
import com.example.Users.Addresses.AddressesList;
import com.example.Users.Addresses.TypeAddress;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class SessionWithEnvirontmentList extends ArrayList<SessionWithEnvirontment> {
    public SessionWithEnvirontmentList()
    {
        super();
    }

    public SessionWithEnvirontmentList(Collection<? extends SessionWithEnvirontment> addresses)
    {
        this();
        addAll(addresses);
    }

    public SessionWithEnvirontmentList(List<SessionWithEnvirontment> addresses)
    {
        this();
        addAll(addresses);
    }

    public SessionWithEnvirontmentList(ArrayList<SessionWithEnvirontment> addresses)
    {
        this();
        addAll(addresses);
    }

    public SessionWithEnvirontmentList(SessionWithEnvirontmentList addresses)
    {
        this();
        addAll(addresses);
    }



    public SessionWithEnvirontmentList(JSONArray array)
    {
        this();
        SetJson(array);
    }

    public SessionWithEnvirontmentList(String arrayJson)
    {
        this();
        SetJson(arrayJson);
    }

    public void SetList(Collection<? extends SessionWithEnvirontment> addresses)
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
                SessionWithEnvirontment address = new SessionWithEnvirontment(object);
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

}
