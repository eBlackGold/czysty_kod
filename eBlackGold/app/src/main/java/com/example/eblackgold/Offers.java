package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

public class Offers extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_offers);

        Spinner dropdown = findViewById(R.id.dropdownSearchTypeOffers);
        String[] items = new String[]{"Typ1", "Typ2", "Typ3"};
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, items);
        dropdown.setAdapter(adapter);

        Spinner dropdown2 = findViewById(R.id.dropdownSortOffers);
        String[] items2 = new String[]{"Alfabetycznie", "Cena rosnąco", "Cena malejąco"};
        ArrayAdapter<String> adapter2 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, items);
        dropdown.setAdapter(adapter);
    }
}