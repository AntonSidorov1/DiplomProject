package com.example.Products;

import android.graphics.Bitmap;

import com.example.Traid.GeographyPoint.GeographyPoint;
import com.example.Users.Addresses.Address;
import com.example.Users.Addresses.AddressesList;
import com.example.Users.Addresses.TypeAddress;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class ProductsList extends ArrayList<Product> {


    public ProductsList()
    {
        super();
    }

    public ProductsList(Collection<? extends Product> addresses)
    {
        this();
        addAll(addresses);
    }

    public ProductsList(List<Product> addresses)
    {
        this();
        addAll(addresses);
    }

    public ProductsList(ArrayList<Product> addresses)
    {
        this();
        addAll(addresses);
    }

    public ProductsList(ProductsList addresses)
    {
        this();
        addAll(addresses);
    }

    public int IndexByID(Product point)
    {
        return IndexByID(point.ID);
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

    public Product GetByID(int id)
    {
        return get(IndexByID(id));
    }

    public Product GetByID(Product point)
    {
        return GetByID(point.ID);
    }

    public boolean ContainsByID(int id)
    {
        for(int i = 0; i < size(); i++)
        {
            if(get(i).ID == id)
                return true;
        }
        return  false;
    }

    public boolean ContainsByID(Product point)
    {
        return ContainsByID(point.ID);
    }


    public ProductsList(JSONArray array, Bitmap bit)
    {
        this();
        SetJson(array, bit);
    }

    public ProductsList(JSONArray array)
    {
        this(array, Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
    }

    public ProductsList(String arrayJson, Bitmap bit)
    {
        this();
        SetJson(arrayJson, bit);
    }

    public void SetList(Collection<? extends Product> addresses)
    {
        clear();
        addAll(addresses);
    }

    public void SetJson(JSONArray arrayJson)
    {
        SetJson(arrayJson, Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
    }

    public void SetJson(String arrayJson)
    {
        SetJson(arrayJson, Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
    }

    public void SetJson(JSONArray array, Bitmap bit)
    {

        clear();
        for(int i = 0; i < array.length(); i++)
        {
            try {
                JSONObject object = array.getJSONObject(i);
                Product address = new Product(object, bit);
                add(address);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }

    public void SetJson(String jsonArray, Bitmap bit) {

        try {
            SetJson(new JSONArray(jsonArray), bit);
        } catch (JSONException ex) {
            ex.printStackTrace();
        }
    }

    public JSONArray GetJsonQuantity()
    {
        JSONArray array = new JSONArray();
        for(int i = 0; i < size(); i++)
        {
            array.put(get(i).GetJsonQuantity());
        }
        return array;
    }

}
