package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RadioGroup;
import android.widget.TextView;

public class AddToCart extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_to_cart);

        ImageView imgOfProduct = findViewById(R.id.imgAddToCart);

        TextView productName = findViewById(R.id.productNameAddToCart);
        TextView sellerName = findViewById(R.id.sellerNameAddToCart);
        TextView unitsInStock = findViewById(R.id.unitsAddToCart);
        TextView price = findViewById(R.id.priceAddToCart);
        TextView type = findViewById(R.id.typeAddToCart);

        RadioGroup deliveryOptions = findViewById(R.id.radioGroupDeliveryAddToCart);
        RadioGroup paymentOptions = findViewById(R.id.radioGroupPaymentAddToCart);

        Button addToCartButton = findViewById(R.id.buttonAddToCart);

        //Kod podmieniający wszystkie nazwy itp. na te pobrane z bazy

        addToCartButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod odpowiadający za dodanie produktu do koszyka
            }
        });
    }
}