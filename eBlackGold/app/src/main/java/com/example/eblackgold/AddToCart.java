package com.example.eblackgold;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

public class AddToCart extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_to_cart);

        ImageView imgOfProduct = findViewById(R.id.imgAddToCart);

        TextView productName = findViewById(R.id.productNameAddToCart);
        TextView sellerName = findViewById(R.id.sellerNameAddToCart);
        TextView unitsInStock = findViewById(R.id.unitsInStockAddToCart);
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
                TemporaryData.AddToCart(TemporaryData.selectedItem);

                Intent intent = new Intent(getBaseContext(), Cart.class);
                startActivity(intent);
                Toast.makeText(getBaseContext(), "Dodano do koszyka", Toast.LENGTH_SHORT);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        getMenuInflater().inflate(R.menu.home_menu, menu);

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {

        switch(item.getItemId())
        {
            case R.id.buttonProfile:
                if(true) //jest użytkownikiem
                {
                    Intent intentUserProfile = new Intent(getBaseContext(), UserProfile.class);
                    startActivity(intentUserProfile);
                }
                else //jest sprzedawcą
                {
                    Intent intentSellerProfile = new Intent(getBaseContext(), UserProfile.class);
                    startActivity(intentSellerProfile);
                }
                break;

            case R.id.buttonCart:
                Intent intentCart = new Intent(getBaseContext(), Cart.class);
                startActivity(intentCart);
                break;

            case R.id.logout:
                //Wylogowanie użytkownika
                Intent intentLogin = new Intent(getBaseContext(), MainActivity.class);
                startActivity(intentLogin);
                break;

            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
}