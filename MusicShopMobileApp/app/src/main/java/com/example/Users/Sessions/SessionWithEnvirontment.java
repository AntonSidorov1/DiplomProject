package com.example.Users.Sessions;

import org.json.JSONException;
import org.json.JSONObject;

public class SessionWithEnvirontment {

    public SessionWithEnvirontment()
    {

    }

    public SessionWithEnvirontment(JSONObject json)
    {
        this();
        SetJson(json);
    }

    public SessionWithEnvirontment(String json)
    {
        this();
        SetJson(json);
    }

    public String FullDescription = "";

    @Override
    public String toString() {
        return "================= \n"+
                FullDescription + "\n" +
                "================= \n";
    }

    public boolean This = false;

    public boolean Active = true;

    public boolean Closing()
    {
        return Active && !This;
    }

    public String Token = "";

    public JSONObject GetSessionJson(){
        JSONObject object = new JSONObject();
        try {
            object.put("token", Token);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object;
    }

    public String GetSessionJsonText()
    {
        return GetSessionJson().toString();
    }

    public void SetJson(String json)
    {
        try {
            SetJson(new JSONObject(json));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public void SetJson(JSONObject object)
    {
        try {
            FullDescription = object.getString("fullDescription");
            Active = object.getBoolean("active");
            This = object.getBoolean("this");
            Token = object.getString("token");
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }
}
