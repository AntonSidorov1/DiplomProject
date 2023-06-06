package com.example.Traid.Organization;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;

import com.example.API.ApiClient;
import com.example.Traid.GeographyPoint.GeographyPoint;
import com.example.Traid.Sity.Sity;

import org.json.JSONException;
import org.json.JSONObject;

public class Organization extends Sity {

    public Bitmap Logotip;

    public Organization()
    {
        super();
        Name = "Все организации";
        SetDataByName();
        Logotip = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
    }

    public Organization(JSONObject object) {
        super(object);
    }

    public Organization(String jsonObject) {
        super(jsonObject);
    }

    @Override
    protected void SetDataJson(JSONObject jsonObject) {

        try {
            Logotip = Bitmap.createBitmap(ApiClient.BitmapFromJsonObject(jsonObject, "logotip"));
            Logotip.setWidth(100);
            Logotip.setHeight(100);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    @Override
    protected void SetDataPoint(GeographyPoint point) {
        super.SetDataPoint(point);
        if(point.IsOrganization())
            Logotip = point.AsOrganization().Logotip;
    }
}
