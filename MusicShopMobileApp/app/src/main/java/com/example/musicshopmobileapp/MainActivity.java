package com.example.musicshopmobileapp;

import androidx.activity.result.contract.ActivityResultContracts;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.API.ApiClient;
import com.example.API.ApiClientWithMessage;
import com.example.API.ConnectConfig;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Products.Categories.Category;
import com.example.Products.Product;
import com.example.Products.ProductHelper;
import com.example.Products.ProductsList;
import com.example.Products.ProductsListWithInfo;
import com.example.Traid.TraidHelper;
import com.example.Users.User;
import com.example.Users.UsersHelper;

import org.json.JSONException;
import org.json.JSONObject;
import android.content.res.AssetManager;

import java.io.InputStream;

public class MainActivity extends AppCompatActivity {

    TextView login, textViewFIO, count;
    ListView listViewProducts;
    TextView category;

    ProductsList productsList = new ProductsList();
    ProductsAdapter productsAdapter;
    Bitmap image;
    EditText productNameEdid, minDiscountEdit, maxDiscountEdit;
    Spinner nameSort, priceSort;
    CheckBox haveProducts;

    String[] sort = new String[]
    {
        "Не сортировать",
            "По возрастанию",
            "По убыванию"
    };

    String[] sortParams = new String[]
    {
        "None",
                "Asc",
                "Desc"
    };

    String sortName = "None";
    String sortPrice = "None";

    ArrayAdapter<String> priceSortAdapter, nameSortAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String versionName = BuildConfig.VERSION_NAME;
        int versionCode = BuildConfig.VERSION_CODE;
        String appName = getPackageName();
        String operationSystem = System.getProperty("os.name");
        String osVersion = System.getProperty("os.version");

        login = findViewById(R.id.textViewLogin);
        login.setText("");

        textViewFIO = findViewById(R.id.textViewFIO);
        textViewFIO.setText("");

        count = findViewById(R.id.textViewCount);
        count.setText("");
        category = findViewById(R.id.textViewCategory);
        category.setText(ProductHelper.categoryName);

        productNameEdid = findViewById(R.id.editTextProductName);
        productNameEdid.setText("");
        productNameEdid.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                Update_Click(productNameEdid);
            }
        });

        minDiscountEdit = findViewById(R.id.editTextMinDiscount);
        minDiscountEdit.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                String discount = minDiscountEdit.getText().toString();
                if(discount.equals(""))
                    return;
                try {
                    int discountNamber = Integer.parseInt(discount);
                    if(discountNamber > 100 || discountNamber < 0)
                        throw new Exception();
                }
                catch (Exception e)
                {
                    minDiscountEdit.setText("0");
                    return;
                }
                Update_Click(minDiscountEdit);
            }
        });

        maxDiscountEdit = findViewById(R.id.editTextMaxDiscount);
        maxDiscountEdit.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                String discount = maxDiscountEdit.getText().toString();
                if(discount.equals(""))
                    return;
                try {
                    int discountNamber = Integer.parseInt(discount);
                    if(discountNamber > 100 || discountNamber < 0)
                        throw new Exception();
                }
                catch (Exception e)
                {
                    maxDiscountEdit.setText("100");
                    return;
                }
                Update_Click(minDiscountEdit);
            }
        });

        nameSortAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        nameSort = findViewById(R.id.spinnerNameSort);
        nameSortAdapter.addAll(sort);
        nameSort.setAdapter(nameSortAdapter);
        nameSort.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                try {
                    sortName = sortParams[position];
                }
                catch (Exception e)
                {
                    sortName = sortParams[0];
                }
                Update_Click();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        priceSortAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        priceSort = findViewById(R.id.spinnerPriceSort);
        priceSortAdapter.addAll(sort);
        priceSort.setAdapter(priceSortAdapter);
        priceSort.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                try {
                    sortPrice = sortParams[position];
                }
                catch (Exception e)
                {
                    sortPrice = sortParams[0];
                }
                Update_Click();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        AssetManager assets = getAssets();

        String filename = "Logotip.jpg";
        try(InputStream inputStream = getApplicationContext().getAssets().open("Logotip.jpg")){
            image = BitmapFactory.decodeStream(inputStream);
        }
        catch (Exception e){
            e.printStackTrace();
            image = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
        }

        listViewProducts = findViewById(R.id.listViewProducts);
        productsAdapter = new ProductsAdapter(this)
        {
            @Override
            public void ShowProduct(Product product, int position) {
                int id = product.ID;
                Helper.Product = product;
                Intent i = new Intent(GetContext(), ShowProductActivity.class);
                i.putExtra("id", id);
                startActivityForResult(i, 200);
            }
        };
        listViewProducts.setAdapter(productsAdapter);

        haveProducts = findViewById(R.id.checkBoxHave);
        haveProducts.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                Update_Click();
            }
        });


        getProducts = true;
        getDatas();

    }



    void Update_Click()
    {
        Update_Click(new View(this));
    }

    @Override
    public void finish() {
        run = false;
        super.finish();
    }

    Activity GetContext()
    {
        return this;
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode) {
        get = false;
        super.startActivityForResult(intent, requestCode);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        loadProducts = false;
        GetDatas();

        get = true;
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void GetDatas()
    {
        GetLogin();
        getCategory();
        getProducts();
    }

    boolean getRun()
    {
        return run;
    }

    public void Update_Click(View v)
    {
        try {

            get = false;
            GetDatas();
            Runnable run = new Runnable() {
                @Override
                public void run() {

                    try {
                        Thread.sleep(UsersHelper.GetRandomMilliSeconds());
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (getRun()) {
                                get = true;
                            }
                        }
                    });
                }
            };
            Thread t = new Thread(run);
            t.start();
        }
        catch (Exception e)
        {
            get = true;
        }
    }

    void runDatas()
    {
        while(run)
        {
            if(get)
            {
                if(getLogin)
                {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            GetLogin();
                        }
                    });
                }

                if(getCategories) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            getCategory();
                        }
                    });
                }
                if(getProducts) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            getProducts();
                        }
                    });
                }

            }

            try {
                Thread.sleep(UsersHelper.GetRandomMilliSeconds());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    public void Categories_Click(View v)
    {
        if(login.getText().toString().equals(""))
            return;
        Intent i = new Intent(this, CategoriesActivity.class);
        startActivityForResult(i, 200);
    }

    boolean getCategories = true;
    void getCategory()
    {
        getCategories = false;
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {

                    Category category = new Category(res.Body);
                    ProductHelper.CategoryID = category.ID;
                    ProductHelper.categoryName = category.RealName;
                }
                catch (Exception e)
                {

                }
            }

            @Override
            public void GetResult(ResultOfAPI res) {
                getCategories = true;
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        String url = Helper.GetUrlAddress(this)+"/categories/"+ProductHelper.CategoryID;

        api.GET(url, true);
    }

    boolean getProducts = true;
    void getProducts()
    {

        category.setText(ProductHelper.categoryName);
        getProducts = false;
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {

                    ProductsListWithInfo products = new ProductsListWithInfo(res.Body, image);
                    productsList.SetList(products.Products);

                    count.setText(products.Count);
                    productsAdapter.SetList(productsList);
                    listViewProducts.setAdapter(productsAdapter);
                    productsAdapter.notifyDataSetChanged();
                }
                catch (Exception e)
                {

                }
            }

            @Override
            public void GetResult(ResultOfAPI res) {
                getProducts = true;
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        int minDiscount = 0;
        int maxDiscount = 100;

        String url = Helper.GetUrlAddress(this)+"/products";

        String pointType = TraidHelper.PointType;
        int id = TraidHelper.GetPointProductsID();
        if(!TraidHelper.PointType.equals(""))
        {
            url+="-in-"+pointType+"s";
            url+="/by-"+pointType+"-id/"+id;
        }

        url+="/with-count";
              url+=  "?minDiscount="+minDiscountEdit.getText().toString()+
                "&maxDiscount="+maxDiscountEdit.getText().toString() +"" +
                "&sortByName="+sortName+"&sortByPrice="+sortPrice + "&" +
                "category="+ ProductHelper.CategoryID;
        String filterName = productNameEdid.getText().toString();
        if(!filterName.equals(""))
        {
            url += "&nameFilter="+filterName;
        }
        if(!TraidHelper.PointType.equals(""))
        {
            url+="&listFull="+(!haveProducts.isChecked());
        }

        api.GET(url, true);
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

    boolean loadProducts = false;
    boolean getLogin = true, run = true, get = true;
    void GetLogin()
    {
        getLogin = false;
        ApiClient apiClient = new ApiClient(this)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if (res.Code == 401) {

                    throw new Exception("Вы больше не авторизированы");
                }

                User user = new User();
                user.SetJson(res.Body);
                login.setText(user.login);
                try {
                    textViewFIO.setText(user.FIO.GetFIO());
                } catch (Exception e) {
                    e.printStackTrace();
                }
                getLogin = true;

                if(loadProducts)
                    return;
                getProducts();
                loadProducts = true;
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                runGoest();
            }

            @Override
            public void on_fail(String req) {
                getLogin = true;
            }
        };

        apiClient.GET(Helper.GetUrlAddress((this))+"/accounts/data", true);
    }

    void runGoest()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("environtmentToken", Helper.EnvirontmentSession);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String body = object.toString();
        ApiClient  apiClient = new ApiClient(this)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {
                if (res.Code == 401) {

                    throw new Exception("Вы больше не авторизированы");
                }
                JSONObject object = new JSONObject(res.Body);
                ConnectConfig.Token = object.getString("jwtToken");

                ConnectConfig.SetToken(GetActivity(), ConnectConfig.Token);

                GetLogin();
            }

            @Override
            public void on_fail(ResultOfAPI res, String req) {
                runEnvirontment(true);
            }

            @Override
            public void on_fail(String req) {
                getLogin = true;
            }
        };
        apiClient.POST(Helper.GetUrlAddress((this))+"/sessions/goest", body, false);
    }

    void runEnvirontment(boolean runGoest)
    {
        JSONObject object = new JSONObject();
        JSONObject device = new JSONObject();
        JSONObject app = new JSONObject();
        JSONObject browser = new JSONObject();

        try {
            device.put("name", "Android");
            device.put("operationSystem", System.getProperty("os.name") + " " +System.getProperty("os.version"));
            object.put("device", device);
            app.put("name", getPackageName());
            app.put("version", BuildConfig.VERSION_CODE + " - " + BuildConfig.VERSION_NAME);
            object.put("application", app);
            browser.put("use", false);
            object.put("browser", browser);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String body = object.toString();

        ApiClient  apiClient = new ApiClient(this)
        {

            @Override
            public void ready_result(ResultOfAPI res) throws Exception {

                JSONObject object = new JSONObject(res.Body);
                Helper.EnvirontmentSession = object.getString("environtmentToken");

                if(runGoest)
                    runGoest();
                else
                    getLogin = true;
            }

            @Override
            public void on_fail(ResultOfAPI res, String message) {
                login.setText("");
                getLogin = true;
            }

            @Override
            public void on_fail(String req) {
                getLogin = true;
            }
        };
        apiClient.POST(Helper.GetUrlAddress((this))+"/environtment-token/open", body, false);
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

    public void RunSettings(View v)
    {
        Intent i = new Intent(this, UrlEditActivity.class);
        startActivityForResult(i, 200);
    }

    public void RunProfile(View v)
    {
        Intent i = new Intent(this, ProfileActivity.class);
        i.putExtra("login", login.getText().toString());
        startActivityForResult(i, 200);
    }

    public void TraidingPoint_Click(View v)
    {
        get = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);
        builder.setTitle("Торговый пункт (пункт получения заказа)");
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });
        builder.setNegativeButton("Задать/Изменить", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Intent i = new Intent(GetContext(), TraidingPointActivity.class);
                startActivityForResult(i, 200);
            }
        });
        builder.setNeutralButton("Сбросить", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                TraidHelper.Clear();
                GetDatas();
                get = true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage(TraidHelper.GetPointDescription());
        dialog.show();

    }

    public void CartRun_Click(View v)
    {
        Intent i = new Intent(this, ShoppingCartActivity.class);
        startActivityForResult(i, 200);
    }

    public void OrdersRun_Click(View v)
    {
        Intent i = new Intent(this, OrdersActivity.class);
        startActivityForResult(i, 200);
    }

}