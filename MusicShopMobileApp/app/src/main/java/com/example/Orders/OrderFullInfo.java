package com.example.Orders;

import com.example.Products.ProductsList;

import org.json.JSONObject;

public class OrderFullInfo extends Order {
    public OrderFullInfo() {
        super();
    }

    public OrderFullInfo(JSONObject object)
    {
        super(object);
    }

    public OrderFullInfo(String jsonObject)
    {
        super(jsonObject);
    }

    public ProductsList Products = new ProductsList();

    @Override
    public void SetJson(JSONObject object) {
        try
        {
            super.SetJson(object.getJSONObject("order"));
            try
            {
                Products.clear();
                Products.SetJson(object.getJSONArray("products"));
            }
            catch (Exception e)
            {

            }
        }
        catch (Exception e) {
            super.SetJson(object);
        }
    }
}
