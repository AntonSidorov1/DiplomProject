package com.example.Products.Categories;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class CategoriesList extends ArrayList<Category> {

    public CategoriesList()
    {
        super();
    }

    public CategoriesList(Collection<? extends Category> addresses)
    {
        this();
        addAll(addresses);
    }

    public int IndexByID(int id)
    {
        int index = -1;

        for(int i = 0; i < size(); i++)
        {
            if(get(i).ID == id)
                return i;
        }

        return  index;
    }

    public CategoriesList(List<Category> addresses)
    {
        this();
        addAll(addresses);
    }

    public CategoriesList(ArrayList<Category> addresses)
    {
        this();
        addAll(addresses);
    }

    public CategoriesList(CategoriesList addresses)
    {
        this();
        addAll(addresses);
    }

    public void SetList(Collection<? extends Category> addresses)
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
                Category address = new Category(object);
                add(address);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }

    public Category GetByID(int id)
    {
        return get(IndexByID(id));
    }

    public void SetJson(String jsonArray) {

        try {
            SetJson(new JSONArray(jsonArray));
        } catch (JSONException ex) {
            ex.printStackTrace();
        }
    }

}
