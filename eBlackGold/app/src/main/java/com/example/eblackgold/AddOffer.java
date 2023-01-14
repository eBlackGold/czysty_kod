package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TextView;

public class AddOffer extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_offer);

        ImageView imgOfProduct = findViewById(R.id.imgAddOffer);

        EditText productName = findViewById(R.id.productNameAddOffer);
        EditText units = findViewById(R.id.unitsAddOffer);
        EditText price = findViewById(R.id.priceAddOffer);

        Spinner dropdown = findViewById(R.id.dropdownTypeAddOffer);
        String[] items = new String[]{Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, items);
        dropdown.setAdapter(adapter);

        //Dostawy
        CheckBox personalPickup = findViewById(R.id.checkboxPersonalPickup);
        CheckBox courier = findViewById(R.id.checkboxCourier);

        //Zapłaty
        CheckBox blik = findViewById(R.id.checkboxBlik);
        CheckBox transfer = findViewById(R.id.checkboxTransfer);
        CheckBox cash = findViewById(R.id.checkboxCash);

        Button addOfferButton = findViewById(R.id.buttonAddOffer);

        imgOfProduct.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod pobierający zdjęcie od użytkownika
            }
        });

        addOfferButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod odpowiadający za dodanie oferty do bazy
            }
        });

        //Kod podmieniający wszystkie nazwy itp. na te pobrane z bazy
    }
}