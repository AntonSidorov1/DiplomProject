package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.example.API.ApiClient;
import com.example.API.ApiClientWithMessage;
import com.example.API.ResultOfAPI;
import com.example.Configuration.ChangeEvent;
import com.example.Configuration.FormatClass;
import com.example.DB.Helper;
import com.example.Orders.OrderFullInfo;
import com.example.Products.Product;
import com.example.Products.ShoppingCartHelper;
import com.example.Traid.TraidHelper;
import com.example.Users.UsersHelper;

import org.json.JSONException;
import org.json.JSONObject;

public class OrderActivity extends AppCompatActivity {

    boolean run = true, get = true;
    OrderFullInfo order = new OrderFullInfo();
    int id;

    Button cancel;
    TextView number;

    ArrayAdapter<Product> products;
    ListView productsView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order);
        try {
            id = getIntent().getIntExtra("id", 0);
        }
        catch (Exception e)
        {

        }

        number = findViewById(R.id.textViewNumber);
        number.setText("");
        cancel = findViewById(R.id.buttonOrderCancel);

        productsView = findViewById(R.id.listViewOrderProducts);
        products = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        productsView.setAdapter(products);
        productsView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                try {

                    Helper.Product = order.Products.get(position);
                    Intent i = new Intent(GetContext(), ShowProductActivity.class);
                    startActivityForResult(i, 200);
                }
                catch (Exception e)
                {

                }
            }
        });

        getDatas();
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

    public void Update_Click(View v)
    {
        Update_Click();
    }

    public void Update_Click()
    {
        get = false;
        GetDatas();
        get = true;
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
        GetDatas();

        get = true;
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void GetDatas()
    {
        ChangeEvent event = new ChangeEvent()
        {
            @Override
            public void Run(String text) {
                GetOrder();
            }
        };
        UsersHelper.GetDatas(GetActivity(), event, false);
    }

    public void GetOrder()
    {
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    order.SetJson(res.Body);
                    number.setText(order.Number);
                    products.clear();
                    products.addAll(order.Products);
                    products.notifyDataSetChanged();
                    cancel.setVisibility(FormatClass.GetVisibleByBool(order.Active()));
                } catch (Exception e) {
                    e.printStackTrace();
                }

            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                if(res.Code == 204)
                {
                    String error = "Данного заказа не существует";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Просмотр заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 401)
                {
                    String error = "Вы не авторизированы в системе";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Просмотр заказа (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 403)
                {
                    String error = "Вы не имеете роль клиента";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Просмотр заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code >= 500)
                {
                    String error = ErrorMessage();

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Просмотр заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;
        String url = Helper.GetUrlAddress(this)+"/orders/"+id+"/full-info";
        api.GET(url, true);

    }


    void runDatas()
    {
        while(run) {
            if (get) {

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

    public void GetInfo(View v)
    {
        get = false;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);
        builder.setTitle("Заказ");
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });
        AlertDialog dialog = builder.create();
        dialog.setMessage(order.Info +"\n\n" +
                ""+order.PickupPoint);
        dialog.show();
    }

    public void Cancel_Click(View v) {
        get = false;
        String error = "Вы действительно хотите отменить данный заказ?";

        androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
        builder.setCancelable(false);
        builder.setTitle("Отмена заказа");
        builder.setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Cancel_Click();
            }
        });
        builder.setNegativeButton("Нет", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                get = true;
            }
        });

        androidx.appcompat.app.AlertDialog dialog = builder.create();
        dialog.setMessage(error);
        dialog.show();

    }

    public void Cancel_Click()
    {
        get = false;
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                String error = "Заказ успешно отменён";

                androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                builder.setCancelable(false);
                builder.setTitle("Отмена заказа");
                builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        GetDatas();
                        get = true;
                    }
                });

                androidx.appcompat.app.AlertDialog dialog = builder.create();
                dialog.setMessage(error);
                dialog.show();

            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                if(res.Code == 204)
                {
                    String error = "Данного заказа не существует";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Отмена заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 401)
                {
                    String error = "Вы не авторизированы в системе";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Отмена заказа (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 403)
                {
                    String error = "Вы не имеете роль клиента";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Отмена заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code >= 500)
                {
                    String error = ErrorMessage();

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Отмена заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;
        String url = Helper.GetUrlAddress(this)+"/orders/"+id+"/cancel";
        api.DELETE(url, true);
    }

    public void Repeart_Click(View v)
    {
        ShoppingCartHelper helper = new ShoppingCartHelper()
        {
            @Override
            public void GetResult(ResultOfAPI res) {
                if(res.Code==200)
                {
                    String error = "Товары из заказа перенесены в корзину";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Повтор заказа");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            get = true;
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();


                    return;
                }
                if(res.Code == 204)
                {
                    String error = "Данного заказа не существует";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Повтор заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 401)
                {
                    String error = "Вы не авторизированы в системе";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Повтор заказа (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code == 403)
                {
                    String error = "Вы не имеете роль клиента";

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Повтор заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
                if(res.Code >= 500)
                {
                    String error = ApiClient.ErrorMessage();

                    androidx.appcompat.app.AlertDialog.Builder builder = new androidx.appcompat.app.AlertDialog.Builder(GetContext());
                    builder.setCancelable(false);
                    builder.setTitle("Повтор заказа  (Ошибка!!!)");
                    builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            finish();
                        }
                    });

                    androidx.appcompat.app.AlertDialog dialog = builder.create();
                    dialog.setMessage(error);
                    dialog.show();

                    return;
                }
            }
        };

        get = false;
        ApiClientWithMessage api = new ApiClientWithMessage(this)
        {
            @Override
            public void GetResultReady(ResultOfAPI res) {
                try {
                    JSONObject object = new JSONObject(res.Body);
                    TraidHelper.OrderToken = object.getString("orderToken");
                    TraidHelper.GetCart(GetActivity(), helper);

                } catch (JSONException e) {
                    e.printStackTrace();
                }

            }

            @Override
            public void GetResultFail(ResultOfAPI res) {
                helper.GetResult(res);
            }
        };
        api.GetMessageFailOutput = false;
        api.GetMessageReady = false;
        String url = Helper.GetUrlAddress(this)+"/orders/"+id+"/repeart";
        api.GET(url, true);

    }

}