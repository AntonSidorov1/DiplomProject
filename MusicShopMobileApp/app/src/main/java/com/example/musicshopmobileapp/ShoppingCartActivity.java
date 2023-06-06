package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListView;

import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.DB.Helper;
import com.example.Products.Product;
import com.example.Products.ShoppingCart;
import com.example.Products.ShoppingCartHelper;
import com.example.Traid.TraidHelper;
import com.example.Users.User;
import com.example.Users.UsersHelper;

import org.json.JSONException;
import org.json.JSONObject;

public class ShoppingCartActivity extends AppCompatActivity {

    boolean run = true, get = true, update = true;
    ListView order;
    OrderAdapter orderAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_shopping_cart);

        order = findViewById(R.id.listViewOrder);

        orderAdapter = new OrderAdapter(this){
            @Override
            public void InfoProduct(Product product, int position) {
                Helper.Product = product;
                Intent i = new Intent(GetActivity(), ShowProductActivity.class);
                startActivityForResult(i, 200);
            }

            @Override
            public void DeleteProduct(Product product, int position) {
                get = false;
                try {
                    TraidHelper.ShoppingCart.ClearProduct(position);
                    this.SetOrder(TraidHelper.ShoppingCart);
                    GetDatas();
                }
                catch (Exception e)
                {

                }
                get = true;
            }

            @Override
            public void ChangeCount(Product product, int position, int quantity) {
                get = false;
                update = false;
                try {
                    TraidHelper.ShoppingCart.SetProductsCount(product, quantity);
                    SetOrder(TraidHelper.ShoppingCart);
                    GetDatas();
                }
                catch (Exception e)
                {

                }
                update = true;
                get = true;
            }
        };

        order.setAdapter(orderAdapter);
        orderAdapter.SetOrder(TraidHelper.ShoppingCart);

        GetDatas();
        getDatas();
    }

    public void ClearOrder(View v)
    {
        get = false;

        TraidHelper.ShoppingCart.Clear();
        GetDatas();

        get = true;
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

    public void UpdateCart_Click(View v)
    {
        GetDatas();
    }

    public void GetInformation(View v)
    {
        get = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);
        builder.setTitle("Корзина");
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                GetDatas();
                get =true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage(TraidHelper.ShoppingCart.Information);
        dialog.show();
    }

    public void GetShoppingCart()
    {
        get = false;
        ShoppingCartHelper cartHelper = new ShoppingCartHelper()
        {
            @Override
            public void GetResult() {
                get = true;
            }

            @Override
            public void GetCart(ShoppingCart cart) {
                if(!update)
                    return;
                orderAdapter.SetOrder(cart);
            }
        };

        TraidHelper.GetShoppingCart(this, cartHelper);
    }


    boolean getRun()
    {
        return run;
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

    public Activity GetActivity()
    {
        return this;
    }

    public void GetDatas()
    {
        UsersHelper.GetDatas(GetActivity(), false);
        GetShoppingCart();
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
                Intent i = new Intent(GetActivity(), TraidingPointActivity.class);
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

    public Activity GetContext()
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
        GetDatas();
        get = true;
        super.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    public void finish() {
        get = false;
        run = false;
        super.finish();
    }

    public void CreateOrder_Click(View v)
    {
        get = true;
        ShoppingCartHelper cartHelper = new ShoppingCartHelper()
        {
            @Override
            public void GetResult() {
                if(!run)
                {
                    return;
                }
                get = true;
            }

            @Override
            public void GetCart(ShoppingCart cart) {

                orderAdapter.SetOrder(cart);
                SetOrder();
            }
        };

        TraidHelper.GetShoppingCart(this, cartHelper);
    }


    public void SetOrder()
    {
        JSONObject object = new JSONObject();
        try {
            object.put("orderToken", TraidHelper.OrderToken);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String json = object.toString();
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    JSONObject object = new JSONObject(res.Body);
                    String number = object.getString("number");

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            TraidHelper.ShoppingCart.Clear();
                            finish();
                        }
                    });
                    builder.setTitle("Заказ");
                    AlertDialog dialog = builder.create();
                    dialog.setMessage("Номер вашего заказа - "+number);
                    dialog.show();

                } catch (JSONException e) {
                    e.printStackTrace();
                }

            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                if(res.Code == 400)
                {
                    String error = "Невозможно оформить заказ \n" +
                            " - Проыерьте наличие пункта получения (магазина или пункта выдачи) \n" +
                            " - Проверьте наличие, хотя бы, одного товара в корзине \n" +
                            " - Проверьте возможность заказа каждого товара в корзине (Товары, которые невозможно заказать выделены красным цветов)," +
                            " и если есть товары, которые невозможно заказать: \n" +
                            "\t 1) Проверьте существование таких товаров \n" +
                            "\t 2) Проверьте наличие таких товаров " +
                            "в магазине (если пункт получения - магазин) или на складе (если пункт получения - пункт выдачи) \n" +
                            "\t 3) Проверьте, чтобы количество таких товаров в корзине не превышало количество " +
                            "в магазине (если пункт получения - магазин) или на складе (если пункт получения - пункт выдачи) \n" +
                            "Выполните выше перечисленные проверки, исправьте ошибки, и попробуйте оформить заказ снова";

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Заказ (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            get = true;
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 401)
                {
                    String error = "Вы не авторизированы в системе";

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Заказ (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            get = true;
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 403)
                {
                    String error = "Вы не имеете роль клиента";

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Заказ (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            get = true;
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code >= 500)
                {
                    String error = ErrorMessage();

                    AlertDialog.Builder builder = new AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Заказ (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            get = true;
                        }
                    });

                    AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;
        api.POST(Helper.GetUrlAddress(this)+"/orders/set-order", json, true);
    }


}