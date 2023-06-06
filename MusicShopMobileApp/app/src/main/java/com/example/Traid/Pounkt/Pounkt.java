package com.example.Traid.Pounkt;

import com.example.Traid.GeographyPoint.GeographyPoint;

import org.json.JSONException;
import org.json.JSONObject;

public abstract class Pounkt extends GeographyPoint {

    public Pounkt()
    {
        super();
        Name = "Все " + TypeName();
        SetDataByName();
        SetRegistrateByName();
        SetItemByName();
    }

    public Pounkt(JSONObject object) {
        super(object);
    }

    public Pounkt(String jsonObject) {
        super(jsonObject);
    }

    public abstract String TypeName();

    public String RegistrateData = "";
    public String ItemData = "";

    public void SetRegistrateByName()
    {
        RegistrateData = Name;
    }

    public void SetItemByName()
    {
        ItemData = Name;
    }

    @Override
    public String GetData() {
        return ItemData;
    }

    @Override
    protected void SetDataJson(JSONObject jsonObject) {
        try {
            RegistrateData = jsonObject.getString("registrateData");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        try {
            ItemData = jsonObject.getString("itemData");
        } catch (JSONException e) {
            e.printStackTrace();
        }

        SetEndDataJson(jsonObject);
    }

    protected abstract void SetEndDataJson(JSONObject jsonObject);


    @Override
    protected void SetDataPoint(GeographyPoint point) {
        if(point.IsPounkt())
        {
            Pounkt pounkt = point.AsPounkt();
            RegistrateData = pounkt.RegistrateData;
            ItemData = pounkt.ItemData;
            SetEndDataPoint(pounkt);
        }
    }

    protected abstract void SetEndDataPoint(Pounkt pounkt);
}
