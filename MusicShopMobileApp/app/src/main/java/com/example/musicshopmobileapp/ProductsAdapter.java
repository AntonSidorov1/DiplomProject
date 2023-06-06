package com.example.musicshopmobileapp;

import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;

import com.example.Products.Product;
import com.example.Products.ProductsList;
import com.example.musicshopmobileapp.R;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class ProductsAdapter extends ArrayAdapter<Product> {


    Context ctx;
    private LayoutInflater inflater;
    private int layout;
    public ProductsList productList = new ProductsList();

    public ProductsAdapter(@NonNull Context context) {
        super(context, R.layout.list_item);

        layout = R.layout.list_item;

        this.inflater = LayoutInflater.from(context);
        ctx = context;
    }

    private class ViewHolder {
        public Button description;
        ImageView image;
        ViewHolder(View view){
            image = view.findViewById(R.id.imageView);
            description = view.findViewById(R.id.descriptionView);
        }
    }


    public void SetList(ProductsList addresses)
    {
        clear();
        productList.SetList(addresses);

            addAll(addresses);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        final ViewHolder viewHolder;
        if(convertView==null){
            convertView = inflater.inflate(this.layout, parent, false);
            viewHolder = new ViewHolder(convertView);
            convertView.setTag(viewHolder);
        }
        else{
            viewHolder = (ViewHolder) convertView.getTag();
        }
            final Product product = productList.get(position);

            viewHolder.description.setText(product.Information);
            try {
                viewHolder.image.setImageBitmap(Bitmap.createScaledBitmap(product.Image, 200, 200, false));
            }
            catch (Exception e)
            {
                viewHolder.image.setImageBitmap(product.Image);
            }
            viewHolder.image.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    ShowProduct(product, position);
                }
            });
            viewHolder.description.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    ShowProduct(product, position);
                }
            });
            viewHolder.description.setAllCaps(false);
            viewHolder.description.setBackgroundColor(Color.CYAN);
            if(product.Discount > 14)
            {
                viewHolder.description.setBackgroundTintList(ColorStateList.valueOf(
                        Color.rgb(153, 255, 153)));
            }
            else
            {
                viewHolder.description.setBackgroundTintList(ColorStateList.valueOf(
                        Color.WHITE));
            }

            if(product.InPounkt)
            {
                if(product.Quantity < 1)
                    viewHolder.description.setBackgroundTintList(ColorStateList.valueOf(Color.RED));
            }

        return convertView;
    }

    public void ShowProduct(Product product, int position)
    {

    }
}
