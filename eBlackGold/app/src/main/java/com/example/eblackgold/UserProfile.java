package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListPopupWindow;
import android.widget.ListView;
import android.widget.ScrollView;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class UserProfile extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_profile);

        APIInterface apiInterface = LoadBalancer.get();

        getSupportActionBar().hide();

        EditText name = findViewById(R.id.name);
        EditText surname = findViewById(R.id.surname);
        EditText address = findViewById(R.id.address);

        List<String> names = new ArrayList<String>();
        List<String> quantity = new ArrayList<String>();
        List<String> prices = new ArrayList<String>();
        List<String> prodTypes = new ArrayList<String>();
        List<Integer> images = new ArrayList<Integer>();

        Button buttonBack = findViewById(R.id.buttonBackUser);
        buttonBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intentOffers = new Intent(getBaseContext(), Offers.class);
                startActivity(intentOffers);
            }
        });


        Call<List<ProductResponse>> call = apiInterface.getAllProductsByCustomer(TemporaryData.username);
        call.enqueue(new Callback<List<ProductResponse>>() {
            @Override
            public void onResponse(Call<List<ProductResponse>> call, Response<List<ProductResponse>> response) {
                List<ProductResponse> offers = response.body();
                for(int i=0;i<offers.size();i++) {
                    names.add(offers.get(i).Name);
                    quantity.add(String.valueOf(offers.get(i).Quantity));
                    prices.add(offers.get(i).unitPrice);
                    prodTypes.add(offers.get(i).CoalType);
                    images.add(R.drawable.ic_box);
                }

                int n = names.size();
                //Na sztywno podane wartości parametrów dla produktów do testowania listy
                String productNamesList[] = new String[n];//{"Produkt1", "Produkt2", "Produkt3"};
                String unitsList[] = new String[n];//{"30", "10", "999"};
                String pricesList[] = new String[n];//{"30zł", "1200zł", "475zł"};
                String typesList[] = new String[n];//{Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
                int imagesList[] = new int[n];//{R.drawable.ic_box, R.drawable.ic_box, R.drawable.ic_box};
                for(int i=0;i<n;i++) {
                    productNamesList[i] = names.get(i);
                    unitsList[i] = quantity.get(i);
                    pricesList[i] = prices.get(i);
                    typesList[i] = prodTypes.get(i);
                    imagesList[i] = images.get(i);
                }

                ListView history = findViewById(R.id.history);
                OffersListAdapter offersListAdapter = new OffersListAdapter(getApplicationContext(), productNamesList, unitsList, pricesList, typesList, imagesList);
                history.setAdapter(offersListAdapter);

            }

            @Override
            public void onFailure(Call<List<ProductResponse>> call, Throwable t) {

            }
        });
    }
}