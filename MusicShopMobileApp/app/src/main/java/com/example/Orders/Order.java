package com.example.Orders;

import android.graphics.Bitmap;

import com.example.Products.Product;

import org.json.JSONException;
import org.json.JSONObject;

public class Order {
    public Order() {
        ID = 0;
        Number = "";
        Info = "";
        PickupPoint = "";
        StatusID = 0;
    }

    public Order(JSONObject object)
    {
        this();
        SetJson(object);
    }

    public Order(String jsonObject)
    {
        this();
        SetJson(jsonObject);
    }

    public int ID;
    public String Number, Info, PickupPoint;
    public int StatusID;

    public boolean Active()
    {
        return StatusID < 5 || StatusID > 6;
    }


    public void SetOrder(Order order) {
        ID = order.ID;
        Number = order.Number;
        Info = order.Info;
        PickupPoint = order.PickupPoint;
        StatusID = order.StatusID;
    }

    @Override
    public String toString() {
        return Info;
    }

    public void SetJson(String jsonObject)
    {
        try {
            SetJson(new JSONObject(jsonObject));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }


    public void SetJson(JSONObject object) {

        try {
            ID = object.getInt("id");
            Number = object.getString("number");
            Info = object.getString("information");
            PickupPoint = object.getString("pickupPoint");
            try
            {
                StatusID = object.getInt("statusID");
            }
            catch (Exception e)
            {

            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }
}
