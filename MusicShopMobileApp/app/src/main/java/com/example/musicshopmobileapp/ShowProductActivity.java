package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Products.Product;
import com.example.Products.ProductsList;
import com.example.Traid.TraidHelper;
import com.example.Users.UsersHelper;

public class ShowProductActivity extends AppCompatActivity {

    int id = 0;
    TextView idText, articul, name, description, price, discount, priceWithDiscount, category, manufacture, supplier, count;
    ImageView productImage;
    EditText quantityInCart;

    boolean changeQuantity;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_product);
        id = getIntent().getIntExtra("id", 0);

        productImage = findViewById(R.id.imageViewProduct);
        idText = findViewById(R.id.textViewProductID);
        articul = findViewById(R.id.textViewProductArticul);
        name = findViewById(R.id.textViewProductName);
        description = findViewById(R.id.textViewProductDescription);
        price = findViewById(R.id.textViewProductPrice);
        discount = findViewById(R.id.textViewProductDiscount);
        priceWithDiscount = findViewById(R.id.textViewProductPriceWithDiscount);
        category = findViewById(R.id.textViewProductCategory);
        manufacture = findViewById(R.id.textViewProductManufacture);
        supplier = findViewById(R.id.textViewProductSupplier);
        count = findViewById(R.id.textViewCountProducts);
        quantityInCart = findViewById(R.id.editTextCountInCart);
        quantityInCart.setText("0");
        quantityInCart.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                if(quantityInCart.getText().toString().equals(""))
                    return;
                int quantity = 0;
                try {
                    quantity = Integer.parseInt(quantityInCart.getText().toString());
                }
                catch (Exception e)
                {
                    quantityInCart.setText("");
                    return;
                }
                if(!changeQuantity)
                    return;
                TraidHelper.ShoppingCart.SetProductsCount(Helper.Product, quantity);
            }
        });

        setProduct();
        RunDatasChange();
    }

    public void AddToCart(View v)
    {
        changeQuantity = false;
        TraidHelper.ShoppingCart.AddProduct(Helper.Product);
        try {
            quantityInCart.setText(String.valueOf(
                    TraidHelper.ShoppingCart.GetByID(Helper.Product).Quantity
            ));
        }
        catch (Exception e)
        {
            quantityInCart.setText("0");
        }
        changeQuantity = true;
    }

    public void SubToCart(View v)
    {
        changeQuantity = false;
        TraidHelper.ShoppingCart.SubProduct(Helper.Product);
        try {
            quantityInCart.setText(String.valueOf(
                    TraidHelper.ShoppingCart.GetByID(Helper.Product).Quantity
            ));
        }
        catch (Exception e)
        {
            quantityInCart.setText("0");
        }
        changeQuantity = true;
    }

    public void ClearToCart(View v)
    {
        changeQuantity = false;
        TraidHelper.ShoppingCart.ClearProduct(Helper.Product);
        try {
            quantityInCart.setText(String.valueOf(
                    TraidHelper.ShoppingCart.GetByID(Helper.Product).Quantity
            ));
        }
        catch (Exception e)
        {
            quantityInCart.setText("0");
        }
        changeQuantity = true;
    }

    void setProduct()
    {
        try {
            Product product = Helper.Product;

            changeQuantity = false;
            try {
                quantityInCart.setText(String.valueOf(
                        TraidHelper.ShoppingCart.GetByID(product).Quantity
                ));
            }
            catch (Exception e)
            {
                quantityInCart.setText("0");
            }
            changeQuantity = true;

            id = product.ID;
            try {
                productImage.setImageBitmap(product.Image);
            }
            catch (Exception e)
            {
                productImage.setImageBitmap(Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888));
            }
            try {
                idText.setText(String.valueOf(product.ID));
            }
            catch (Exception e)
            {
                idText.setText("");

            }
            try {
                articul.setText(String.valueOf(product.Articul));
            }
            catch (Exception e)
            {
                articul.setText("");

            }
            try {
                name.setText(String.valueOf(product.Name));
            }
            catch (Exception e)
            {
                name.setText("");

            }
            try {
                price.setText(String.valueOf(product.Price) + " р");
            }
            catch (Exception e)
            {
                price.setText("");

            }
            try {
                priceWithDiscount.setText(String.valueOf(product.GetPriceWithDiscount()) + " р");
            }
            catch (Exception e)
            {
                priceWithDiscount.setText("");

            }
            try {
                discount.setText(String.valueOf(product.Discount) + " %");
            }
            catch (Exception e)
            {
                discount.setText("");

            }
            try {
                description.setText(product.Description);
            }
            catch (Exception e)
            {
                description.setText("");
            }

            try {
                category.setText(String.valueOf(product.Category));
            }
            catch (Exception e)
            {
                category.setText("");

            }
            try {
                supplier.setText(String.valueOf(product.Supplier));
            }
            catch (Exception e)
            {
                supplier.setText("");

            }
            try {
                manufacture.setText(String.valueOf(product.Manufacture));
            }
            catch (Exception e)
            {
                manufacture.setText("");

            }

            try {
                count.setTextColor(Color.BLACK);
                count.setText(product.QuantityText);
                if(product.InPounkt && product.Quantity < 1)
                    count.setTextColor(Color.RED);
            }
            catch (Exception e)
            {
                count.setText("");
            }
        }
        catch (Exception e)
        {

        }
    }

    boolean get = false;

    boolean run = true, run1 = true;
    boolean runFail = true;

    public void GetDatas()
    {
        GetDatas(20);
    }

    public void UpdateProduct_Click(View v)
    {
        GetDatas();
    }

    public void GetDatas(int count)
    {
        run1 = false;
        Product product = Helper.Product;

        changeQuantity = false;
        try {
            quantityInCart.setText(String.valueOf(
                    TraidHelper.ShoppingCart.GetByID(product).Quantity
            ));
        }
        catch (Exception e)
        {
            quantityInCart.setText("0");
        }
        changeQuantity = true;

        UsersHelper.GetDatas(this, false);

        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                Helper.Product = new Product(res.Body);
                setProduct();

                }
                catch (Exception e)
                {

                }
                run1 = true;
            }


            @Override
            public void GetResultFail(ResultOfAPI res) {
                if(res.Code == 204)
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setTitle("Просмотр товара (Ошибка!!!)");
                    builder.setCancelable(false);
                    builder.setNegativeButton("ОК", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });
                    AlertDialog dialog = builder.create();
                    dialog.setMessage("Данного товара больше не существует");
                    dialog.show();
                    return;
                }
                if (!runFail) {
                    return;
                }
                if (count > 0) {
                    GetDatas(count - 1);
                    return;
                }
                finish();
            }
        };
        api.GetMessageFailOutput = count < 1 && runFail;
        api.GetMessageReady = false;

        api.TitleMessage = "Вывод товаров";
        api.MessageFail = "Не удалось вывести информацию о товаре";

        String url = Helper.GetUrlAddress(this);
        String type = TraidHelper.PointType;
        int point = TraidHelper.GetPointProductsID();
        if(!type.equals(""))
        {
            url+="/products-in-"+type+"s/by-"+type+"-id/"+point+"";
        }

        api.GET(url + "/products/"+id, true);

    }


    public void RunDatasChange()
    {
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                while(run)
                {
                    if(run1)
                    {
                        GetContext().runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                GetDatas();
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
        };

        Thread thread = new Thread(runnable);
        thread.start();
    }


    public Activity GetContext()
    {
        return this;
    }

    @Override
    public void startActivityForResult(@NonNull Intent intent, int requestCode) {
        run1 = false;
        super.startActivityForResult(intent, requestCode);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        GetDatas();
        run1 = true;
        super.onActivityResult(requestCode, resultCode, data);
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

    public void Exit(View v)
    {
        finish();
    }

    @Override
    public void finish() {
        run = false;
        runFail = false;
        super.finish();
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

}