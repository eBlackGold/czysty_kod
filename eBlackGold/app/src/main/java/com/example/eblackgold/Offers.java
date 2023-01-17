package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

public class Offers extends AppCompatActivity {

    //Na sztywno podane wartości parametrów dla produktów do testowania listy
    String productNamesList[] = {"Produkt1", "Produkt2", "Produkt3"};
    String unitsList[] = {"30", "10", "999"};
    String pricesList[] = {"30zł", "1200zł", "475zł"};
    String typesList[] = {Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
    int imagesList[] = {R.drawable.ic_box, R.drawable.ic_box, R.drawable.ic_box};

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

        ListView offersList = findViewById(R.id.productListOffers);
        OffersListAdapter offersListAdapter = new OffersListAdapter(getApplicationContext(), productNamesList, unitsList, pricesList, typesList, imagesList);
        offersList.setAdapter(offersListAdapter);
        offersList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                //position -> index w liście
                Intent intent = new Intent(getBaseContext(), AddToCart.class);
                startActivity(intent);
            }
        });


        Button searchOffers = findViewById(R.id.buttonSearchOffers);

        searchOffers.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod wyświetlający wyszukane oferty
            }
        });
    }
}