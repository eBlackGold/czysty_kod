package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;

public class Cart extends AppCompatActivity {

    //Na sztywno podane wartości parametrów dla produktów do testowania listy
    String productNamesList[] = {"Produkt1", "Produkt2", "Produkt3"};
    String unitsList[] = {"30", "10", "999"};
    String pricesList[] = {"30zł", "1200zł", "475zł"};
    String typesList[] = {Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
    int imagesList[] = {R.drawable.ic_box, R.drawable.ic_box, R.drawable.ic_box};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart);

        ListView cartList = findViewById(R.id.productListCart);
        CartListAdapter cartListAdapter = new CartListAdapter(getApplicationContext(), productNamesList, unitsList, pricesList, typesList, imagesList);
        cartList.setAdapter(cartListAdapter);
        cartList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                //position -> index w liście
                Intent intent = new Intent(getBaseContext(), AddToCart.class);
                startActivity(intent);
            }
        });

        Button buttonPay = findViewById(R.id.buttonPayCart);

        buttonPay.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod usuwający rzeczy z koszyka i dodanie ich do zamówień sprzedającego
            }
        });
    }
}