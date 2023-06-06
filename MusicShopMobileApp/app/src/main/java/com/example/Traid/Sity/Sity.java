package com.example.Traid.Sity;

import com.example.Traid.GeographyPoint.GeographyPoint;

import org.json.JSONObject;

public class Sity extends GeographyPoint {

    public Sity()
    {
        super();
        Name = "Все города";
        SetDataByName();
    }

    public Sity(JSONObject object) {
        super(object);
    }

    public Sity(String jsonObject) {
        super(jsonObject);
    }

    @Override
    public String GetData() {
        return Name;
    }

    @Override
    protected void SetDataJson(JSONObject jsonObject) {

    }

    @Override
    protected void SetDataPoint(GeographyPoint point) {

    }

}
