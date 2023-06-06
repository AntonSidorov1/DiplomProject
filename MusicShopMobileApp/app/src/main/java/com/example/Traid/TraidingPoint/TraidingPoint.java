package com.example.Traid.TraidingPoint;

import com.example.Traid.Pounkt.Pounkt;

import org.json.JSONException;
import org.json.JSONObject;

public class TraidingPoint extends Pounkt {
    public TraidingPoint()
    {
        super();
        StockID = 0;
        OrganizationID = 0;
        SityID= 0;
        ExistencePounktOfIssue = false;
        ExistenceShop = false;
    }

    public TraidingPoint(JSONObject object) {
        super(object);
    }

    public TraidingPoint(String jsonObject) {
        super(jsonObject);
    }

    public int StockID, OrganizationID, SityID;
    public boolean ExistenceShop, ExistencePounktOfIssue;

    @Override
    public String TypeName() {
        return "торговые пункты";
    }

    @Override
    protected void SetEndDataJson(JSONObject jsonObject) {
        try {
            StockID = jsonObject.getInt("stockID");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        try {
            OrganizationID = jsonObject.getInt("organizationID");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        try {
            SityID = jsonObject.getInt("sityID");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        try {
            ExistenceShop = jsonObject.getBoolean("existenceShop");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        try {
            ExistencePounktOfIssue = jsonObject.getBoolean("existencePounktOfIssue");
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void SetEndDataPoint(Pounkt pounkt) {
        if(pounkt.IsTraid())
        {
            TraidingPoint point = pounkt.AsTraid();
            StockID = point.StockID;
            OrganizationID = point.OrganizationID;
            SityID = point.SityID;
            ExistenceShop = point.ExistenceShop;
            ExistencePounktOfIssue = point.ExistencePounktOfIssue;

        }
    }
}
