package com.example.Products.Categories.CategoriesFilters;

import android.graphics.Bitmap;

import com.example.Products.Product;
import com.example.Products.ProductsList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class CategoriesFiltersList extends ArrayList<CategoryFilter> {

    public CategoriesFiltersList()
    {
        super();
    }

    public CategoriesFiltersList(Collection<? extends CategoryFilter> addresses)
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

    public CategoriesFiltersList(List<CategoryFilter> addresses)
    {
        this();
        addAll(addresses);
    }

    public CategoriesFiltersList(ArrayList<CategoryFilter> addresses)
    {
        this();
        addAll(addresses);
    }

    public CategoriesFiltersList(CategoriesFiltersList addresses)
    {
        this();
        addAll(addresses);
    }

    public void SetList(Collection<? extends CategoryFilter> addresses)
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
                CategoryFilter address = new CategoryFilter(object);
                add(address);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }

    public void SetJson(String jsonArray) {

        try {
            SetJson(new JSONArray(jsonArray));
        } catch (JSONException ex) {
            ex.printStackTrace();
        }
    }

}
