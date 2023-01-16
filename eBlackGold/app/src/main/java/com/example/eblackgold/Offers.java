package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class Offers extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_offers);

        Spinner dropdownType = findViewById(R.id.dropdownTypeOffers);
        String[] types = new String[]{Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, types);
        dropdownType.setAdapter(adapter);

        Spinner dropdownSort = findViewById(R.id.dropdownSortOffers);
        String[] sortBy = new String[]{"Alfabetycznie", "Cena rosnąco", "Cena malejąco"};
        ArrayAdapter<String> adapter2 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, sortBy);
        dropdownSort.setAdapter(adapter2);

        TextView searchText =  findViewById(R.id.searchOffers);
        EditText priceFrom = findViewById(R.id.priceFromOffers);
        EditText priceTo = findViewById(R.id.priceToOffers);

        Button searchOffers = findViewById(R.id.buttonSearchOffers);

        searchOffers.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod wyświetlający wyszukane oferty
            }
        });
    }
}