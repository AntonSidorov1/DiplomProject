package com.example.Traid.GeographyPoint;

import com.example.Products.Categories.CategoriesList;
import com.example.Products.Categories.Category;
import com.example.Traid.GeographyPointType;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class GeographyPointsList extends ArrayList<GeographyPoint> {
    public GeographyPointsList()
    {
        super();
        PointType = GeographyPointType.TraidingPoint;
    }

    public GeographyPointsList(GeographyPointType pointType)
    {
        this();
        PointType = pointType;
    }

    public GeographyPointsList(Collection<? extends GeographyPoint> addresses)
    {
        this();
        addAll(addresses);
    }

    public int IndexByID(GeographyPoint point)
    {
        return IndexByID(point.ID);
    }

    public int IndexByID(int id)
    {
        int index = -1;

        for(int i = 0; i < size(); i++)
        {
            if(get(i).ID == id)
                return i;
        }

        return  index;
    }

    public GeographyPointsList(List<GeographyPoint> addresses)
    {
        this();
        addAll(addresses);
    }

    public GeographyPointsList(ArrayList<GeographyPoint> addresses)
    {
        this();
        addAll(addresses);
    }

    public GeographyPointsList(GeographyPointsList addresses)
    {
        this();
        addAll(addresses);
    }

    public void SetList(Collection<? extends GeographyPoint> addresses)
    {
        clear();
        addAll(addresses);
    }

    public GeographyPointType PointType;


    public void SetJson(JSONArray array)
    {

        clear();
        for(int i = 0; i < array.length(); i++)
        {
            try {
                JSONObject object = array.getJSONObject(i);
                GeographyPoint address = GeographyPoint.GetPoint(PointType, object);
                add(address);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }

    public GeographyPoint GetByID(int id)
    {
        return get(IndexByID(id));
    }

    public GeographyPoint GetByID(GeographyPoint point)
    {
        return GetByID(point.ID);
    }

    public void SetJson(String jsonArray) {

        try {
            SetJson(new JSONArray(jsonArray));
        } catch (JSONException ex) {
            ex.printStackTrace();
        }
    }


}
