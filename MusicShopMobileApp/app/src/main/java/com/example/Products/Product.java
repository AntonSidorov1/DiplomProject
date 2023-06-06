package com.example.Products;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.Image;

import com.example.API.ApiClient;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;

public class Product extends ProductQuantity {

    public Product(){
        super();
        NameIfon = "";
        Image = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
    }

    public Product(JSONObject object, Bitmap bit)
    {
        SetJson(object, bit);
    }

    public Product(String jsonObject, Bitmap bit)
    {
        SetJson(jsonObject, bit);
    }

    public Product(JSONObject object)
    {
        SetJson(object);
    }

    public Product(String jsonObject)
    {
        SetJson(jsonObject);
    }

    public String Name = "";
    public String Description = "";
    public String Category = "";
    public String Manufacture = "";
    public String Supplier = "";
    public String Articul = "";
    public double Price = 0;
    public int Discount = 0;
    public String NameIfon;
    public double GetPriceWithDiscount()
    {
        return Price - (Price*(Discount/100.0));
    }
    public String QuantityText = "";
    public String QuantityInfo = "";
    public boolean InPounkt = false;
    public boolean InOrder = false;
    public boolean Maybe = false;

    public  Bitmap Image;

    public String Information = "";

    public void SetProduct(Product product)
    {
        ID = product.ID;
        Name = product.Name;
        Description = product.Description;
        Information = product.Information;
        Category = product.Category;
        Manufacture = product.Manufacture;
        Supplier = product.Supplier;
        Articul = product.Articul;
        Price = product.Price;
        Discount = product.Discount;
        Quantity = product.Quantity;
        QuantityText = product.QuantityText;
        QuantityInfo = product.QuantityInfo;
        InPounkt = product.InPounkt;
        InOrder = product.InOrder;
        Maybe = product.Maybe;
        NameIfon = product.NameIfon;
        try {
            Image = Bitmap.createBitmap(product.Image);
        }
        catch (Exception e)
        {

        }
    }

    public void SetJson(JSONObject object, Bitmap bit)
    {
        NameIfon = "";
        InPounkt = false;
        InOrder = false;
        Maybe = false;
        try {
            ID = object.getInt("id");
            Articul = object.getString("articul");
            Name = object.getString("name");
            Description = object.getString("description");
            Price = object.getDouble("priceWithOutDiscount");
            Discount = object.getInt("discount");
            Information = object.getString("information");

            Category = object.getJSONObject("category").getString("name");
            Manufacture = object.getJSONObject("manufacture").getString("name");
            Supplier = object.getJSONObject("supplier").getString("name");
        } catch (JSONException e) {
            e.printStackTrace();
        }

        try {
            Image = ApiClient.BitmapFromJsonObject(object, "photo");
        } catch (JSONException e) {
            e.printStackTrace();
            Image = bit;
        }

        try {
            QuantityText = object.getString("quantityText");
            Quantity = object.getInt("quantity");
            try {
                QuantityInfo=object.getString("quaontityInfo");
                Maybe=object.getBoolean("mayby");
                InOrder = true;
            }
            catch (Exception e) {
                InOrder = false;
                InPounkt = true;
            }
        } catch (JSONException e) {
            e.printStackTrace();
            Quantity = 0;
            QuantityText = "";
            QuantityInfo = "";
            InPounkt = false;
            InOrder = false;
            Maybe = false;
        }

        try
        {
            NameIfon = object.getString("nameIfon");
        }
        catch (Exception e)
        {
            NameIfon = "";
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

    @Override
    public String toString() {
        return NameIfon;

    }
}
