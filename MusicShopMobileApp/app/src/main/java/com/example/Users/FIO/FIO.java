package com.example.Users.FIO;

import org.json.JSONException;
import org.json.JSONObject;

public class FIO {

    public FIO()
    {

    }

    public FIO(String fio)
    {
        this();
        SetFIO(fio);
    }

    public String FamilyName = "";
    public String FirstName = "";
    public String SurName = "";

    public String GetFIO()
    {
        return String.join(" ", FamilyName, FirstName, SurName).trim();
    }

    public void SetFIO(String fio)
    {
        FamilyName = "";
        FirstName = "";
        SurName = "";
        String[] initials = fio.split(" ");
        try
        {
            FamilyName = initials[0];
            FirstName = initials[1];
        }
        catch (Exception e)
        {
            FamilyName = "";
            FirstName = "";
            SurName = "";
            return;
        }

        try
        {
            SurName = initials[2];
        }
        catch (Exception e)
        {

            SurName = "";
            return;
        }
    }

    @Override
    public String toString() {
        return GetFIO();
    }

    public String GetJson()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("familyName", FamilyName);
            object.put("firstName", FirstName);
            object.put("surName", SurName);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object.toString();
    }
}
