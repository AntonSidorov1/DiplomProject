package com.example.Orders;

import android.graphics.Bitmap;

import com.example.Products.Product;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class OrdersList extends ArrayList<Order> {


    public OrdersList()
    {
        super();
    }

    public OrdersList(Collection<? extends Order> addresses)
    {
        this();
        addAll(addresses);
    }

    public OrdersList(List<Order> addresses)
    {
        this();
        addAll(addresses);
    }

    public OrdersList(ArrayList<Order> addresses)
    {
        this();
        addAll(addresses);
    }

    public OrdersList(OrdersList addresses)
    {
        this();
        addAll(addresses);
    }

    public int IndexByID(Order point)
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

    public Order GetByID(int id)
    {
        return get(IndexByID(id));
    }

    public Order GetByID(Product point)
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

    public boolean ContainsByID(Order point)
    {
        return ContainsByID(point.ID);
    }


    public OrdersList(JSONArray array)
    {
        this();
        SetJson(array);
    }

    public OrdersList(String arrayJson)
    {
        this();
        SetJson(arrayJson);
    }

    public void SetJson(JSONArray array)
    {

        clear();
        for(int i = 0; i < array.length(); i++)
        {
            try {
                JSONObject object = array.getJSONObject(i);
                Order address = new Order(object);
                add(address);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }

    public void SetList(Collection<? extends Order> addresses)
    {
        clear();
        addAll(addresses);
    }

    public void SetJson(String jsonArray) {

        try {
            SetJson(new JSONArray(jsonArray));
        } catch (JSONException ex) {
            ex.printStackTrace();
        }
    }


}
