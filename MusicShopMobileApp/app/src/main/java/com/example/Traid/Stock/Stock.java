package com.example.Traid.Stock;

import com.example.Traid.Pounkt.Pounkt;

import org.json.JSONException;
import org.json.JSONObject;

public class Stock extends Pounkt {
    public Stock()
    {
        super();
        SityID = 0;
    }

    public Stock(JSONObject object) {
        super(object);
    }

    public Stock(String jsonObject) {
        super(jsonObject);
    }

    @Override
    public String TypeName() {
        return "склады";
    }

    public int SityID;

    @Override
    protected void SetEndDataJson(JSONObject jsonObject) {
        try {
            SityID = jsonObject.getInt("sityID");
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void SetEndDataPoint(Pounkt pounkt) {
        if(pounkt.IsStock())
            SityID = pounkt.AsStock().SityID;
    }
}
