package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Products.Categories.CategoriesFilters.CategoriesFiltersList;
import com.example.Products.Categories.CategoriesFilters.CategoryFilter;
import com.example.Products.Categories.CategoriesList;
import com.example.Products.Categories.Category;
import com.example.Products.ProductHelper;
import com.example.Products.ProductsListWithInfo;
import com.example.Users.UsersHelper;

public class CategoriesActivity extends AppCompatActivity {

    Spinner spinnerCategoriesFilters;
    CategoriesFiltersList categoryFilters = new CategoriesFiltersList();
    ArrayAdapter<CategoryFilter> categoryFilterAdapter;
    boolean filtersChange = true;
    RadioButton categoriesTree;
    ListView categories;
    CategoriesList categoriesList = new CategoriesList();
    ArrayAdapter<Category> categoriesAdapter;
    TextView category;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_categories);

        spinnerCategoriesFilters = findViewById(R.id.spinnerCategoriesFilters);
        categoryFilterAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        spinnerCategoriesFilters.setAdapter(categoryFilterAdapter);
        spinnerCategoriesFilters.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (!filtersChange)
                    return;
                ProductHelper.CategoryFilterID = categoryFilters.get(position).ID;
                getCategories();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        categoriesTree = findViewById(R.id.radioButtonTree);
        if(ProductHelper.TreeStruct)
            categoriesTree.setChecked(true);
        categoriesTree.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                ProductHelper.TreeStruct = isChecked;
                ProductHelper.CategoryID = 0;
                getCategories();
            }
        });

        categories = findViewById(R.id.listViewCategories);
        categoriesAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        categories.setAdapter(categoriesAdapter);
        categories.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Category categoryNow = categoriesList.get(position);
                ProductHelper.CategoryID = categoryNow.ID;
                ProductHelper.categoryName = categoryNow.RealName;
                category.setText(ProductHelper.categoryName);
                if(ProductHelper.TreeStruct)
                {
                    getCategories();
                }
            }
        });
        category = findViewById(R.id.textViewNowCategory);
        category.setText(ProductHelper.categoryName);

        runUpdate();
    }

    public void Back_Click(View v)
    {
        finish();
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


    @Override
    public void finish() {
        run = false;
        super.finish();
    }

    boolean getLogin = true, run = true, get = true;
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

        getDatas();

        get = true;
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void UpdateCategories_Click(View v)
    {
        getDatas();
    }

    void Update_Click()
    {
        UpdateCategories_Click(new View(this));
    }

    boolean getRun()
    {
        return run;
    }

    public void getDatas()
    {
        UsersHelper.GetDatas(this, false);
        getFilters();
    }

    public void getFilters()
    {
        category.setText(ProductHelper.categoryName);
        //category.setText(ProductHelper.categoryName);
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                filtersChange = false;
                try {
                    categoryFilters.SetJson(res.Body);
                    categoryFilterAdapter.clear();
                    categoryFilterAdapter.addAll(categoryFilters);
                    categoryFilterAdapter.notifyDataSetChanged();
                    filtersChange = true;
                    spinnerCategoriesFilters.setSelection(categoryFilters.IndexByID(ProductHelper.CategoryFilterID));
                }
                catch (Exception e)
                {

                }
                filtersChange = true;

                try {
                    ProductHelper.CategoryFilterID = categoryFilters.get(
                            spinnerCategoriesFilters.getSelectedItemPosition()
                    ).ID;
                }
                catch (Exception e)
                {
                    ProductHelper.CategoryFilterID = 0;
                }
                getCategories();
            }

            @Override
            public void GetResult(ResultOfAPI res) {
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        String url = Helper.GetUrlAddress(this)+"/categories-filters";

        api.GET(url, true);
    }

    public void getCategories() {
        String url = Helper.GetUrlAddress(this) + "/categories";
        if (ProductHelper.TreeStruct) {
            url += "/" + ProductHelper.CategoryID + "/sub-categories";
        }
        url += "?filterID=" + ProductHelper.CategoryFilterID;

        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    categoriesList.SetJson(res.Body);
                    categoriesAdapter.clear();
                    categoriesAdapter.addAll(categoriesList);
                    categoriesAdapter.notifyDataSetChanged();
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }
                try {
                    Category categoryNow = categoriesList.GetByID(ProductHelper.CategoryID);
                    ProductHelper.CategoryID = categoryNow.ID;
                    ProductHelper.categoryName = categoryNow.RealName;
                }
                catch (Exception e)
                {
                    ProductHelper.CategoryID = 0;
                    ProductHelper.categoryName = "Все категории";
                }
                category.setText(ProductHelper.categoryName);
            }



            @Override
            public void GetResult(ResultOfAPI res) {
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;

        api.GET(url, true);
    }

    void runDatas()
    {
        while(run)
        {
            if(get)
            {

                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            getFilters();
                        }
                    });
            }

            try {
                Thread.sleep(UsersHelper.GetRandomMilliSeconds());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    void runUpdate()
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

}