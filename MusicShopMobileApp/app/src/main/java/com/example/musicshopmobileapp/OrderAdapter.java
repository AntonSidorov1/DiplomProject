package com.example.musicshopmobileapp;

import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.Products.Product;
import com.example.Products.ShoppingCart;

public class OrderAdapter extends ArrayAdapter<Product> {

    Context ctx;
    private LayoutInflater inflater;
    private int layout;

    public OrderAdapter(@NonNull Context context) {
        super(context, R.layout.list_item);

        layout = R.layout.order_list_item;

        this.inflater = LayoutInflater.from(context);
        ctx = context;
    }

    public void SetOrder(ShoppingCart cart)
    {
        clear();
        addAll(cart.Products);
        notifyDataSetChanged();
    }

    public void DeleteProduct(Product product, int position)
    {

    }

    public void InfoProduct(Product product, int position)
    {

    }


    private class ViewHolder {
        public Button description, info, delete;
        ViewHolder(View view){
            description = view.findViewById(R.id.buttonOrderProduct);
            info = view.findViewById(R.id.buttonPositionInfo);
            delete = view.findViewById(R.id.buttonDeletePosition);
        }
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        final OrderAdapter.ViewHolder viewHolder;
        if(convertView==null){
            convertView = inflater.inflate(this.layout, parent, false);
            viewHolder = new OrderAdapter.ViewHolder(convertView);
            convertView.setTag(viewHolder);
        }
        else{
            viewHolder = (OrderAdapter.ViewHolder) convertView.getTag();
        }

        Product product = getItem(position);

        Button description = viewHolder.description;
        description.setText(product.NameIfon);
        if(product.Maybe)
        {
            description.setBackgroundTintList(ColorStateList.valueOf(Color.WHITE));
        }
        else
        {
            description.setBackgroundTintList(ColorStateList.valueOf(Color.RED));
        }
        description.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                InfoProduct(product, position);
            }
        });
        viewHolder.info.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                InfoProduct(product, position);
            }
        });

        viewHolder.delete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DeleteProduct(product, position);
            }
        });


        return convertView;
    }

    public void ChangeCount(Product product, int position, int quantity)
    {

    }
}