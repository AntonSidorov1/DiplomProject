package com.example.Traid;

import android.app.Activity;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Products.ShoppingCart;
import com.example.Products.ShoppingCartHelper;
import com.example.Traid.GeographyPoint.GeographyPoint;
import com.example.Traid.GeographyPoint.GeographyPointsList;
import com.example.Traid.Organization.Organization;
import com.example.Traid.Sity.Sity;
import com.example.Traid.Stock.Stock;
import com.example.Traid.TraidingPoint.TraidingPoint;

import org.json.JSONException;
import org.json.JSONObject;

public class TraidHelper {
    public static Sity Sity = new Sity();
    public static Organization Organization = new Organization();
    public static Stock Stock = new Stock();

    public static void SetSityByStock(GeographyPointsList sities)
    {
        try {

            if(Stock.ID > 0)
        {
            GeographyPoint sity = sities.GetByID(Stock.SityID);
            if(sity.IsSity())
                Sity = sity.AsSity();
        }
        }
        catch (Exception e)
        {

        }
    }

    public static void SetSityByTraidingPoint(GeographyPointsList sities)
    {
        try {

            if (TraidingPoint.ID > 0) {
                GeographyPoint sity = sities.GetByID(TraidingPoint.SityID);
                if (sity.IsSity())
                    Sity = sity.AsSity();
            }
        }
        catch (Exception e)
        {

        }
    }

    public static void SetStockByTraidingPoint(GeographyPointsList stocks) {
        try {

            if (TraidingPoint.ID > 0) {
                GeographyPoint stock = stocks.GetByID(TraidingPoint.StockID);
                if (stock.IsStock())
                    Stock = stock.AsStock();
            }
        } catch (Exception e) {

        }
    }

    public static void SetOrganizationByTraidingPoint(GeographyPointsList organizations) {
        try {
            if (TraidingPoint.ID > 0) {
                GeographyPoint organization = organizations.GetByID(TraidingPoint.OrganizationID);
                if (organization.IsOrganization())
                    Organization = organization.AsOrganization();
            }
        } catch (Exception e) {

        }
    }

    public static void SetData(GeographyPointsList sities, GeographyPointsList stocks, GeographyPointsList organizations)
    {
        SetOrganizationByTraidingPoint(organizations);
        SetStockByTraidingPoint(stocks);
        SetSityByStock(sities);
    }

    public static TraidingPoint PickupPoint()
    {
        return TraidingPoint;
    }
    public static TraidingPoint TraidingPoint = new TraidingPoint();


    public static String GetTraidingPoint()
    {
        if (PickupPoint().ID == 0)
            return "";
        if(PointType.equals(""))
        {
            return "Торговый пункт: \n"+
                    PickupPoint().RegistrateData+"\n\n";
        }
        if(PointType.equals("shop") && PickupPoint().ExistenceShop)
            return "Магазин: \n"+
                    PickupPoint().RegistrateData;
        if(PointType.equals("stock") && PickupPoint().ExistencePounktOfIssue)
        {
            return "Пункт выдачи: \n"+
                    PickupPoint().RegistrateData;
        }
        if(PointType.equals("stock") && !PickupPoint().ExistencePounktOfIssue)
        {
            return "!!! Пункт выдачи не выбран";
        }
        PointType = "";
        return GetTraidingPoint();
    }


    public static String PointType = "";

    public static String OrderToken = "";

    public static int GetTraidingPointID()
    {
        if(!PointType.equals("shop") && !PointType.equals("stock"))
            return 0;
        if(PointType.equals("shop") && !PickupPoint().ExistenceShop)
            return 0;
        if(PointType.equals("stock") && !PickupPoint().ExistencePounktOfIssue)
            return 0;
        return TraidingPoint.ID;
    }

    public static int GetPointProductsID()
    {
        if(PointType.equals(""))
        {
            return 0;
        }
        try
        {
            if(PointType.equals("shop") && PickupPoint().ExistenceShop)
                return PickupPoint().ID;
            else
            {
                if(PointType.equals("stock"))
                {
                    if(Stock.ID > 0)
                    {
                        return Stock.ID;
                    }
                    else if(PickupPoint().ExistencePounktOfIssue)
                    {
                        return TraidingPoint.StockID;
                    }
                }
            }
        }
        catch (Exception e)
        {

        }
        return  0;
    }

    public void SetShop()
    {
        PointType = "shop";
    }

    public void SetPounktOfIssue()
    {
        PointType = "pounktOfIssue";
    }

    public static String GetPointDescription()
    {
        String point = "";
        if(Organization.ID > 0)
        {
            point+="Организация - "+Organization.Name+"\n\n";
        }
        if(Sity.ID > 0)
        {
            point+="Город - "+Sity.Name+"\n\n";
        }
        if(Stock.ID > 0)
        {
            point+="Склад: \n "+
                    Stock.RegistrateData +"\n\n";
        }
        if(PickupPoint().ID > 0)
        {
            point += GetTraidingPoint();
        }
        return  point;
    }

    public static void Clear()
    {
        Sity = new Sity();
        Organization = new Organization();
        Stock = new Stock();
        TraidingPoint = new TraidingPoint();
        PointType = "";
    }


    public static ShoppingCart ShoppingCart = new ShoppingCart();


    public static void GetShoppingCart(Activity activity, ShoppingCartHelper cart)
    {
        CheckSessionCart(activity, cart);
    }

    public static void GetShoppingCart(Activity activity)
    {
        GetShoppingCart(activity, new ShoppingCartHelper());
    }

    public static void CheckSessionCart(Activity activity, ShoppingCartHelper cart)
    {
        JSONObject object = new JSONObject();
        try {
            object.put("orderToken", OrderToken);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String json = object.toString();

        ApiClientWithMessage api = new ApiClientWithMessage(activity)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                boolean check = Boolean.parseBoolean(res.Body);
                if(check)
                {
                    SetCart(activity, cart);
                }
                else
                {
                    OpenCart(activity, cart);
                }
            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                cart.GetResult();
            }
        };

        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        api.PUT(Helper.GetUrlAddress(activity)+"/shopping-cart/get/check", json, false);
    }

    public static void SetCart(Activity activity, ShoppingCartHelper cart)
    {

        String json = ShoppingCart.GetJson();

        ApiClientWithMessage api = new ApiClientWithMessage(activity)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                boolean check = Boolean.parseBoolean(res.Body);
                if(check)
                {
                    GetCart(activity, cart);
                }
                else
                {
                    cart.GetResult();
                }
            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                cart.GetResult();
                cart.GetResult(res);
            }

        };

        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        api.POST(Helper.GetUrlAddress(activity)+"/shopping-cart/set/with-traiding-point-id", json, false);
    }

    public static void GetCart(Activity activity, ShoppingCartHelper cart)
    {
        JSONObject object = new JSONObject();
        try {
            object.put("orderToken", OrderToken);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String json = object.toString();

        ApiClientWithMessage api = new ApiClientWithMessage(activity)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    ShoppingCart.SetJson(res.Body);
                    cart.GetResultCart(ShoppingCart);
                } catch (Exception e) {
                    e.printStackTrace();
                    cart.GetResult();
                }
            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                cart.GetResult();
                cart.GetResult(res);
            }

            @Override
            public void GetResult(ResultOfAPI res) {
                cart.GetResult(res);
            }
        };

        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        api.PUT(Helper.GetUrlAddress(activity)+"/shopping-cart/get/full-info", json, false);
    }

    public static void OpenCart(Activity activity, ShoppingCartHelper cart)
    {
        ApiClientWithMessage api = new ApiClientWithMessage(activity)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    JSONObject object = new JSONObject(res.Body);
                    OrderToken = object.getString("orderToken");
                    SetCart(activity, cart);

                } catch (JSONException e) {
                    e.printStackTrace();
                    cart.GetResult();
                }
            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                cart.GetResult();
                cart.GetResult(res);
            }
        };

        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        api.POST(Helper.GetUrlAddress(activity)+"/shopping-cart/open", true);
    }
}
