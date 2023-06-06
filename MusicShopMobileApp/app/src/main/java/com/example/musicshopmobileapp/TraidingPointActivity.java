package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.Spinner;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Products.ProductHelper;
import com.example.Traid.GeographyPoint.GeographyPoint;
import com.example.Traid.GeographyPoint.GeographyPointsList;
import com.example.Traid.GeographyPointType;
import com.example.Traid.Organization.Organization;
import com.example.Traid.Sity.Sity;
import com.example.Traid.Stock.Stock;
import com.example.Traid.TraidHelper;
import com.example.Traid.TraidingPoint.TraidingPoint;
import com.example.Users.UsersHelper;

public class TraidingPointActivity extends AppCompatActivity {


    boolean run = true, get = true;
    boolean changeSities = true, changeOrganizations = true,
    changeStocks = true, changePoints = true;

    GeographyPointsList sities = new GeographyPointsList(GeographyPointType.Sity);
    GeographyPointsList organizations = new GeographyPointsList(GeographyPointType.Organization);
    GeographyPointsList stocks = new GeographyPointsList(GeographyPointType.Stock);
    GeographyPointsList shops = new GeographyPointsList(GeographyPointType.TraidingPoint);
    ArrayAdapter<GeographyPoint> sitiesAdapter, organizationsAdapter, stocksAdapter, shopsAdapter;
    ImageView logotipOrg, logotipShop;
    RadioButton noFilters, shop, pounkrOfIssue, both;

    Spinner spinnerSities, spinnerOrganizations, spinnerStocks, spinnerShops;

    @Override
    public void finish() {
        run = false;
        super.finish();
    }

    public void Exit(View v)
    {
        finish();
    }

    public void Update_Click(View v)
    {
        GetDatas();
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode) {
        get = false;
        super.startActivityForResult(intent, requestCode);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        GetDatas();

        get = true;
        super.onActivityResult(requestCode, resultCode, data);
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_traiding_point);


        spinnerSities = findViewById(R.id.spinnerSities);
        sitiesAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        spinnerSities.setAdapter(sitiesAdapter);
        spinnerSities.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (!changeSities)
                    return;
                TraidHelper.Sity = sities.get(position).AsSity();
                getStocks();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        logotipOrg = findViewById(R.id.imageViewOrgLogotip);
        logotipOrg.setImageBitmap(Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
        spinnerOrganizations = findViewById(R.id.spinnerOrganizations);
        organizationsAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        spinnerOrganizations.setAdapter(organizationsAdapter);
        spinnerOrganizations.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (!changeOrganizations)
                    return;
                TraidHelper.Organization = organizations.get(position).AsOrganization();
                logotipOrg.setImageBitmap(TraidHelper.Organization.Logotip);
                //getCategories();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });


        spinnerStocks = findViewById(R.id.spinnerStocks);
        stocksAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        spinnerStocks.setAdapter(stocksAdapter);
        spinnerStocks.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (!changeStocks)
                    return;
                TraidHelper.Stock = stocks.get(position).AsStock();
                //getCategories();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });


        logotipShop = findViewById(R.id.imageViewShopLogotip);
        logotipShop.setImageBitmap(Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
        spinnerShops = findViewById(R.id.spinnerShops);
        shopsAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        spinnerShops.setAdapter(shopsAdapter);
        spinnerShops.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (!changePoints)
                    return;
                TraidHelper.TraidingPoint = shops.get(position).AsTraid();
                try {
                    TraidingPoint point = shops.get(position).AsTraid();
                    Organization organization = organizations.GetByID(point.OrganizationID).AsOrganization();
                    logotipShop.setImageBitmap(organization.Logotip);
                }
                catch (Exception e)
                {
                    logotipShop.setImageBitmap(Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
                }
                //getCategories();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        noFilters = findViewById(R.id.radioButtonNo);
        noFilters.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(!isChecked)
                    return;
                GetDataBySecconds();
            }
        });

        shop = findViewById(R.id.radioButtonShop);
        shop.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(!isChecked)
                    return;
                GetDataBySecconds();
            }
        });

        pounkrOfIssue = findViewById(R.id.radioButtonPounktOfIssue);
        pounkrOfIssue.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(!isChecked)
                    return;
                GetDataBySecconds();
            }
        });

        both = findViewById(R.id.radioButtonBoth);
        both.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(!isChecked)
                    return;
                GetDataBySecconds();
            }
        });


        getDatas();
    }


    public void GetOrgInfo_Click(View v)
    {
        get = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Организация");
        builder.setCancelable(false);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage(TraidHelper.Organization.Data);
        dialog.show();
    }

    public void GetStockInfo_Click(View v)
    {
        get = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Склад");
        builder.setCancelable(false);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage(TraidHelper.Stock.Data);
        dialog.show();
    }

    public void GetShopInfo_Click(View v)
    {
        get = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Торговый пункт");
        builder.setCancelable(false);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage(TraidHelper.TraidingPoint.Data);

        dialog.show();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        if(item.getItemId() == R.id.ExitItem)
        {
            finish();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    void GetDatas()
    {
        UsersHelper.GetDatas(this, false);
        getSities();
        getOrgs();
    }

    void getSities()
    {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                changeSities = false;
                try {
                    sities.SetJson(res.Body);
                    sitiesAdapter.clear();
                    sitiesAdapter.addAll(sities);
                    sitiesAdapter.notifyDataSetChanged();
                    changeSities = true;
                    spinnerSities.setSelection(sities.IndexByID(TraidHelper.Sity));
                }
                catch (Exception e)
                {

                }
                changeSities = true;

                try {
                    TraidHelper.Sity = sities.get(
                            spinnerSities.getSelectedItemPosition()
                    ).AsSity();
                }
                catch (Exception e)
                {
                    TraidHelper.Sity = new Sity();
                }
                getStocks();
            }

            @Override
            public void GetResult(ResultOfAPI res) {
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        String url = Helper.GetUrlAddress(this)+"/sities";

        api.GET(url, true);
    }

    void getOrgs()
    {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                changeOrganizations = false;
                try {
                    organizations.SetJson(res.Body);
                    organizationsAdapter.clear();
                    organizationsAdapter.addAll(organizations);
                    organizationsAdapter.notifyDataSetChanged();
                    changeOrganizations = true;
                    spinnerOrganizations.setSelection(organizations.IndexByID(TraidHelper.Organization));
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }
                changeOrganizations = true;

                try {
                    TraidHelper.Organization = organizations.get(
                            spinnerOrganizations.getSelectedItemPosition()
                    ).AsOrganization();
                }
                catch (Exception e)
                {
                    TraidHelper.Organization = new Organization();
                }
                getShops();
            }

            @Override
            public void GetResult(ResultOfAPI res) {
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        String url = Helper.GetUrlAddress(this)+"/organizations";

        api.GET(url, true);
    }

    void getStocks()
    {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                changeStocks = false;
                try {
                    stocks.SetJson(res.Body);
                    stocksAdapter.clear();
                    stocksAdapter.addAll(stocks);
                    stocksAdapter.notifyDataSetChanged();
                    changeStocks = true;
                    spinnerStocks.setSelection(stocks.IndexByID(TraidHelper.Stock));
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }
                changeStocks = true;

                try {
                    TraidHelper.Stock = stocks.get(
                            spinnerStocks.getSelectedItemPosition()
                    ).AsStock();
                }
                catch (Exception e)
                {
                    TraidHelper.Stock = new Stock();
                }
                getShops();
            }

            @Override
            public void GetResult(ResultOfAPI res) {
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        String url = Helper.GetUrlAddress(this)+"/stocks?sityID="+TraidHelper.Sity.ID;

        api.GET(url, true);
    }


    void getShops()
    {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                changePoints = false;
                try {
                    shops.SetJson(res.Body);
                    shopsAdapter.clear();
                    shopsAdapter.addAll(shops);
                    shopsAdapter.notifyDataSetChanged();
                    changePoints = true;
                    spinnerShops.setSelection(shops.IndexByID(TraidHelper.TraidingPoint));
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }
                changePoints = true;

                try {
                    TraidHelper.TraidingPoint = shops.get(
                            spinnerShops.getSelectedItemPosition()
                    ).AsTraid();
                }
                catch (Exception e)
                {
                    TraidHelper.TraidingPoint = new TraidingPoint();
                }
                //getCategories();
            }

            @Override
            public void GetResult(ResultOfAPI res) {
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        String url = Helper.GetUrlAddress(this)+"/trading-points";
        if(IsShops())
            url+="/shops";
        else if(IsPounktsOfIssue())
            url+="/pounkts-of-issue";
        else if(IsBoth())
            url+="/both-type";

        url+="?sityID="+TraidHelper.Sity.ID +"&" +
                "stockID="+TraidHelper.Stock.ID+"&" +
                "organizationID="+TraidHelper.Organization.ID;
        api.GET(url, true);
    }

    public boolean IsShops()
    {
        return shop.isChecked();
    }

    public boolean IsPounktsOfIssue()
    {
        return pounkrOfIssue.isChecked();
    }

    public boolean IsBoth()
    {
        return both.isChecked();
    }

    boolean getRun()
    {
        return run;
    }

    public void GetDataBySecconds()
    {
        get = false;
        Runnable run = new Runnable() {
            @Override
            public void run() {
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                if(!getRun())
                    return;
                GetDatas();
                get = true;
            }
        };
        Thread t = new Thread(run);
        t.start();
    }

    void getDatas()
    {
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                runDatas();
            }
        };
        Thread thread = new Thread(runnable);
        thread.start();
    }


    void runDatas()
    {
        while(run)
        {
            if(get) {

                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        GetDatas();
                    }
                });
                try {
                    Thread.sleep(UsersHelper.GetRandomMilliSeconds());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }

            }
        }
    }

    public void SetSityByStock_Click(View v)
    {
        SetSityByStock();
    }

    public void SetSityByStock()
    {
        try
        {
            TraidHelper.SetSityByStock(sities);
            int index = sities.IndexByID(TraidHelper.Sity);
            spinnerSities.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void SetSityByPoint(View v)
    {
        try
        {
            TraidHelper.SetSityByTraidingPoint(sities);
            int index = sities.IndexByID(TraidHelper.Sity);
            spinnerSities.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void SetStockByPoint(View v)
    {
        try
        {
            TraidHelper.SetStockByTraidingPoint(stocks);
            int index = stocks.IndexByID(TraidHelper.Stock);
            spinnerStocks.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void SetOrgByPoint(View v)
    {
        try
        {
            TraidHelper.SetOrganizationByTraidingPoint(organizations);
            int index = organizations.IndexByID(TraidHelper.Organization);
            spinnerOrganizations.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void SetDataByPoint(View v)
    {
        SetDataByPoint();
    }

    public void SetDataByPoint()
    {
        TraidHelper.SetData(sities, stocks, organizations);
        try
        {
            int index = organizations.IndexByID(TraidHelper.Organization);
            spinnerOrganizations.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        try
        {
            int index = stocks.IndexByID(TraidHelper.Stock);
            spinnerStocks.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        try
        {
            int index = sities.IndexByID(TraidHelper.Sity);
            spinnerSities.setSelection(index);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        get = true;
    }

    public void SetMessage()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Пункт получения");
        builder.setCancelable(false);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                SetDataByPoint();
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage("Пункт получения успешно установлен");
        dialog.show();
    }

    public void SetPickupPoint(View v)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        get = false;
        builder.setCancelable(false);
        builder.setTitle("Пункт получения");
        builder.setPositiveButton("Магазин", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                TraidHelper.PointType="shop";
                SetMessage();
            }
        });
        builder.setNegativeButton("Пункт выдачи / склад", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                TraidHelper.PointType="stock";
                SetMessage();
            }
        });
        builder.setNeutralButton("Отмена", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage("Установить как ");
        dialog.show();
    }
}