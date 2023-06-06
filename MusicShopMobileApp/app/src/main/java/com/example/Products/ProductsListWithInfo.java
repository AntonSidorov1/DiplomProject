package com.example.Products;

import android.graphics.Bitmap;

import com.example.API.ApiClient;

import org.json.JSONException;
import org.json.JSONObject;

public class ProductsListWithInfo {
    public ProductsList Products = new ProductsList();
    public String Count = "";


    public void SetJson(JSONObject object, Bitmap bit)
    {
        try {
            Count = object.getString("count");
            Products = new ProductsList(object.getJSONArray("products"), bit);
        } catch (JSONException e) {
            e.printStackTrace();

        }

    }

    public void SetJson(String jsonObject)
    {
        SetJson(jsonObject, Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
    }

    public void SetJson(JSONObject jsonObject)
    {
        SetJson(jsonObject, Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
    }

    public void SetJson(String jsonObject, Bitmap bit)
    {
        try {
            SetJson(new JSONObject(jsonObject), bit);
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }


    public ProductsListWithInfo(){

    }

    public ProductsListWithInfo(JSONObject object, Bitmap bit)
    {
        SetJson(object, bit);
    }

    public ProductsListWithInfo(String jsonObject, Bitmap bit)
    {
        SetJson(jsonObject, bit);
    }

    public ProductsListWithInfo(JSONObject object)
    {
        SetJson(object);
    }

    public ProductsListWithInfo(String jsonObject)
    {
        SetJson(jsonObject);
    }


}
