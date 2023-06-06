package com.example.Products;

import com.example.API.ApiClientWithMessage;
import com.example.Traid.TraidHelper;

import org.json.JSONException;
import org.json.JSONObject;

public class ShoppingCart {
    public ShoppingCart()
    {
        Products = new ProductsList();
        MayBe = false;
        Information = "";
    }


    public ShoppingCart(JSONObject object)
    {
        SetJson(object);
    }

    public ShoppingCart(String jsonObject)
    {
        SetJson(jsonObject);
    }

    public ProductsList Products;

    public boolean MayBe;
    public String Information;

    public  void SetJson(JSONObject object)
    {
        try {
            Products = new ProductsList(object.getJSONArray("shoppingCarts"));
        } catch (JSONException e) {
            e.printStackTrace();
        }

        try {
            JSONObject jsonObject = object.getJSONObject("info");
            MayBe = jsonObject.getBoolean("mayBe");
            Information = jsonObject.getString("information");
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public void SetJson(String jsonObject)
    {
        try {
            SetJson(new JSONObject(jsonObject));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public String GetJson()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("pointID", TraidHelper.GetTraidingPointID());
            object.put("pointType", TraidHelper.PointType);
            object.put("orderToken", TraidHelper.OrderToken);
            object.put("products", Products.GetJsonQuantity());
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return object.toString();
    }

    public void SetCart(ShoppingCart cart)
    {
        MayBe = cart.MayBe;
        Information = cart.Information;
        Products.SetList(cart.Products);
    }

    public void AddProduct(Product product)
    {
        if(Products.ContainsByID(product))
        {
            AddProduct(Products.IndexByID(product));
        }
        else
        {
            Product result = new Product();
            result.SetProduct(product);
            result.Quantity = 1;
            Products.add(result);
        }
    }

    public void SetProductsCount(Product product, int quantity)
    {
        AddProduct(product);
        SetProductsCount(Products.IndexByID(product), quantity);
    }

    public void SetProductsCount(int index, int quantity)
    {
        if(quantity < 1)
        {
            DeleteProduct(index);
        }
        else
        {
            Products.get(index).Quantity = quantity;
        }
    }

    public void DeleteProduct(int index)
    {
        try {
            Products.remove(index);
        }
        catch (Exception e)
        {

        }
    }

    public void AddProduct(int index)
    {
        int product = Products.get(index).Quantity;
        SetProductsCount(index, product + 1);
    }

    public void SubProduct(int index) {
        int product = Products.get(index).Quantity;
        SetProductsCount(index, product - 1);
    }

    public void SubProduct(Product product)
    {
        if(!Products.ContainsByID(product))
            return;
        SubProduct(Products.IndexByID(product));
    }

    public void ClearProduct(int index)
    {
        SetProductsCount(index, 0);
    }

    public void ClearProduct(Product product)
    {
        ClearProduct(Products.IndexByID(product));
    }

    public Product GetByID(int id)
    {
        return Products.GetByID(id);
    }

    public Product GetByID(Product product)
    {
        return GetByID(product.ID);
    }

    public void Clear()
    {
        Products.clear();
    }
}
