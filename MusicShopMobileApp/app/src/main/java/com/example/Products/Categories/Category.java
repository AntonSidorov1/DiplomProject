package com.example.Products.Categories;

import com.example.Products.Categories.CategoriesFilters.CategoryFilter;

import org.json.JSONException;
import org.json.JSONObject;

public class Category extends CategoryFilter {

    public Category(JSONObject object) {
        super(object);
    }

    public Category(String jsonObject) {
        super(jsonObject);
    }

    public  Category()
    {
        RealName = "";
    }

    public String RealName;

    public void SetCategory(Category category)
    {
        SetFilter(category);
        RealName = category.RealName;
    }

    @Override
    public void SetJson(JSONObject jsonObject) {
        super.SetJson(jsonObject);

        try {
            RealName = jsonObject.getString("realName");
        } catch (JSONException e) {
            e.printStackTrace();
            RealName = "";
        }
    }
}
