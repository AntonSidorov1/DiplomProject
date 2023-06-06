package com.example.Products.Categories.CategoriesFilters;

import android.graphics.Bitmap;

import com.example.Products.Product;

import org.json.JSONException;
import org.json.JSONObject;

public class CategoryFilter {

    public  CategoryFilter()
    {

    }

    public CategoryFilter(JSONObject object)
    {
        SetJson(object);
    }

    public CategoryFilter(String jsonObject)
    {
        SetJson(jsonObject);
    }

    public int ID = 0;
    public String Name = "";

    @Override
    public String toString() {
        return Name;
    }


    public void SetFilter(CategoryFilter filter)
    {
        ID = filter.ID;
        Name = filter.Name;
    }


    public void SetJson(String jsonObject)
    {
        try {
            SetJson(new JSONObject(jsonObject));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public void SetJson(JSONObject jsonObject)
    {
        try {
            ID = jsonObject.getInt("id");
            Name = jsonObject.getString("name");
        } catch (JSONException e) {
            e.printStackTrace();
        }

    }

}
