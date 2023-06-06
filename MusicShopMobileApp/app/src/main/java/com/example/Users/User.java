package com.example.Users;

import com.example.DB.Account;
import com.example.Users.FIO.FIO;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;

public class User extends Account {

    public User(JSONObject object) {
        super(object);
    }

    public User(String object) {
        super(object);
    }

    public User()
    {
        super();
    }

    public ArrayList<Role> Role = new ArrayList<>();

    @Override
    public void SetJson(JSONObject json) {
        try
        {
            JSONObject object = json;
            login = object.getString("login");
            password = object.getString("password");

            try
            {
                FIO.SetFIO(object.getJSONObject("fio").getString("initials"));
            }
            catch (Exception e)
            {
                FIO = new FIO();
            }

            JSONArray array = object.getJSONArray("roles");
            for(int i = 0; i < array.length(); i++)
            {

                Role role = new Role();
                role.SetJson(array.getJSONObject(i));
                Role.add(role);
            }
        }
        catch (Exception e)
        {
            super.SetJson(json);
        }
    }

    @Override
    public String toString() {
        return super.toString() + " - "
                + Role.size() +"Ролей";
    }

    public String GetInfo()
    {
        String datas = "Логин: " + login + "\n" +
                "Пароль: " + password + "\n" +
                "ФИО: " + FIO + "\n" +
                "Роли: \n" ;

        for(int i = 0; i < Role.size(); i++)
        {
            Role role = Role.get(i);
            datas += String.valueOf(i+1)+") "+ role.NameRus + " ("+role.NameEng+") \n";
        }
        return  datas;
    }

    public FIO FIO = new FIO();

    public String GetOutputData(Boolean fio)
    {
        String result = login;
        if(fio)
        {
            result += "\n" +
                    FIO.GetFIO();
        }
        return result;
    }

    public  String GetOutputData() {
        return GetOutputData(false);

    }
}
