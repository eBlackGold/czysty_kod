package com.example.eblackgold;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AddOffer extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_offer);

        APIInterface apiInterface = APIClient.getClient().create(APIInterface.class);

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
                AddProductModel product = new AddProductModel();
                product.Name = productName.getText().toString();
                product.UnitsInStock = Integer.parseInt(units.getText().toString());
                product.Price = Double.parseDouble(price.getText().toString());

                Call<Void> call = apiInterface.addProduct(product);
                call.enqueue(new Callback<Void>() {
                    @Override
                    public void onResponse(Call<Void> call, Response<Void> response) {

                    }

                    @Override
                    public void onFailure(Call<Void> call, Throwable t) {

                    }
                });
                //Jeśli brakuje, któregoś z podanych paramterów to wyświetl powiadomienie
                Context context = getApplicationContext();
                CharSequence text = "Brakuje parametru oferty";
                int duration = Toast.LENGTH_SHORT;

                Toast toast = Toast.makeText(context, text, duration);
                toast.show();
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
                Intent intentProfile = new Intent(getBaseContext(), UserProfile.class);
                startActivity(intentProfile);
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