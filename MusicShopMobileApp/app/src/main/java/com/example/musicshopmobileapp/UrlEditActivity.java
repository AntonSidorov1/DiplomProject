package com.example.musicshopmobileapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.DB.DB;
import com.example.DB.Helper;
import com.example.URL.URL;

import java.util.ArrayList;

public class UrlEditActivity extends AppCompatActivity {

    TextView url;
    Spinner protocols;
    EditText address;

    ArrayList<String> protocolsList = new ArrayList<String>();
    ArrayAdapter<String> protocolsAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_url_edit);

        protocolsList.add("http");
        protocolsList.add("https");

        protocolsAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1);
        protocolsAdapter.addAll(protocolsList);

        url = findViewById(R.id.textViewUrlEdit);
        protocols = findViewById(R.id.spinnerProtocols);
        protocols.setAdapter(protocolsAdapter);
        address = findViewById(R.id.editTextAddress);

        GetDatas();
    }

    public Context GetContext()
    {
        return this;
    }

    public void GetDatas()
    {
        GetURL();
        ViewURL();
    }

    public void GetURL()
    {
        url.setText(Helper.GetUrlAddress(GetContext()));
    }

    public void ViewURL()
    {
        String protocol = Helper.URL.Protocol;
        int index = protocolsList.indexOf(protocol);
        protocols.setSelection(index);
        address.setText(Helper.URL.Path);
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
            exit();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    void exit()
    {
        finish();
    }

    public void Exit_Click(View v)
    {
        exit();
    }

    public void Cancel_Click(View v)
    {
        GetDatas();
    }

    public void Save_Click(View v)
    {
        int index = protocols.getSelectedItemPosition();
        String protocol = protocolsList.get(index);
        String path = address.getText().toString();
        Helper.URL = new URL(protocol, path);
        DB.GetDB(this).SaveUrl();
        Cancel_Click(v);
    }

}