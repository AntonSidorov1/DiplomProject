package com.example.Traid.GeographyPoint;

import com.example.Products.Categories.CategoriesFilters.CategoryFilter;
import com.example.Traid.GeographyPointType;
import com.example.Traid.Organization.Organization;
import com.example.Traid.Pounkt.Pounkt;
import com.example.Traid.Sity.Sity;
import com.example.Traid.Stock.Stock;
import com.example.Traid.TraidingPoint.TraidingPoint;

import org.json.JSONException;
import org.json.JSONObject;

public abstract class GeographyPoint {
    public  GeographyPoint()
    {
        ID = 0;
        Name = "";
        Data = "";
    }

    public GeographyPoint(JSONObject object)
    {
        SetJson(object);
    }

    public GeographyPoint(String jsonObject)
    {
        SetJson(jsonObject);
    }

    public int ID;
    public String Name;
    public String Data;

    @Override
    public String toString() {
        return GetData();
    }


    public void SetFilter(CategoryFilter filter)
    {
        ID = filter.ID;
        Name = filter.Name;
    }


    public void SetJson(String jsonObject)
    {
        try {
            SetJson(new JSONObject(jsonObject));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public void SetJson(JSONObject jsonObject)
    {
        try {
            ID = jsonObject.getInt("id");
            Name = jsonObject.getString("name");
            Data = jsonObject.getString("data");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        SetDataJson(jsonObject);
    }
    public String GetDescription() {
        return Data;
    }

    public abstract String GetData();

    protected abstract void SetDataJson(JSONObject jsonObject);

    public boolean IsSity()
    {
        return this instanceof Sity;
    }

    public Sity AsSity()
    {
        return (Sity) this;
    }

    public boolean IsOrganization()
    {
        return this instanceof Organization;
    }

    public Organization AsOrganization()
    {
        return (Organization) this;
    }

    public boolean IsPounkt()
    {
        return this instanceof Pounkt;
    }

    public Pounkt AsPounkt()
    {
        return (Pounkt) this;
    }

    public boolean IsStock()
    {
        return this instanceof Stock;
    }

    public Stock AsStock()
    {
        return (Stock) this;
    }

    public boolean IsTraid()
    {
        return this instanceof TraidingPoint;
    }

    public TraidingPoint AsTraid()
    {
        return (TraidingPoint) this;
    }


    public static GeographyPoint GetPoint(GeographyPointType type)
    {
        switch (type)
        {
            case Sity:return new Sity();
            case Organization: return new Organization();
            case Stock: return new Stock();
            case TraidingPoint: return new TraidingPoint();

            default:return null;
        }
    }

    public static GeographyPoint GetPoint(GeographyPointType type, JSONObject jsonObject)
    {
        GeographyPoint point = GetPoint(type);
        point.SetJson(jsonObject);
        return point;
    }


    public static GeographyPoint GetPoint(GeographyPointType type, String jsonObject)
    {
        GeographyPoint point = GetPoint(type);
        point.SetJson(jsonObject);
        return point;
    }

    protected abstract void SetDataPoint(GeographyPoint point);

    public void SetPoint(GeographyPoint point)
    {
        ID = point.ID;
        Name = point.Name;
        Data = point.Data;
        SetDataPoint(point);
    }

    public void SetDataByName()
    {
        Data = Name;
    }
}
