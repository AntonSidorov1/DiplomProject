package com.example.Products;

import org.json.JSONException;
import org.json.JSONObject;

public class ProductQuantity {
    public ProductQuantity()
    {
        ID = 0;
        Quantity = 0;
    }
    public int ID;
    public int Quantity;

    public JSONObject GetJsonQuantity()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("id", ID);
            object.put("quantity", Quantity);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object;
    }

    public void SetQuantity(ProductQuantity product)
    {
        ID = product.ID;
        Quantity = product.Quantity;
    }
}
