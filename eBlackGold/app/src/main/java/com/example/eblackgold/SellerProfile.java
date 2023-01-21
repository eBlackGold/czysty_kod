package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ListView;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SellerProfile extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_seller_profile);

        getSupportActionBar().hide();

        APIInterface apiInterface = LoadBalancer.get();

        List<String> names = new ArrayList<String>();
        List<String> quantity = new ArrayList<String>();
        List<String> prices = new ArrayList<String>();
        List<String> prodTypes = new ArrayList<String>();
        List<Integer> images = new ArrayList<Integer>();

        Call<List<ProductResponse>> call = apiInterface.getAllProductsFromSupplier(TemporaryData.username);

        List<String> finalNames1 = names;
        List<String> finalQuantity1 = quantity;
        List<String> finalPrices1 = prices;
        List<String> finalProdTypes1 = prodTypes;
        List<Integer> finalImages1 = images;
        call.enqueue(new Callback<List<ProductResponse>>() {
            @Override
            public void onResponse(Call<List<ProductResponse>> call, Response<List<ProductResponse>> response) {
                List<ProductResponse> offers = response.body();
                for(int i=0;i<offers.size();i++) {
                    finalNames1.add(offers.get(i).Name);
                    finalQuantity1.add(String.valueOf(offers.get(i).Quantity));
                    finalPrices1.add(offers.get(i).unitPrice);
                    finalProdTypes1.add(offers.get(i).CoalType);
                    finalImages1.add(R.drawable.ic_box);
                }

                int n = finalNames1.size();
                //Na sztywno podane wartości parametrów dla produktów do testowania listy
                String productNamesList[] = new String[n];//{"Produkt1", "Produkt2", "Produkt3"};
                String unitsList[] = new String[n];//{"30", "10", "999"};
                String pricesList[] = new String[n];//{"30zł", "1200zł", "475zł"};
                String typesList[] = new String[n];//{Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
                int imagesList[] = new int[n];//{R.drawable.ic_box, R.drawable.ic_box, R.drawable.ic_box};
                for(int i=0;i<n;i++) {
                    productNamesList[i] = finalNames1.get(i);
                    unitsList[i] = finalQuantity1.get(i);
                    pricesList[i] = finalPrices1.get(i);
                    typesList[i] = finalProdTypes1.get(i);
                    imagesList[i] = finalImages1.get(i);
                }

                ListView history = findViewById(R.id.offer_history);
                OffersListAdapter offersListAdapter = new OffersListAdapter(getApplicationContext(), productNamesList, unitsList, pricesList, typesList, imagesList);
                history.setAdapter(offersListAdapter);

            }

            @Override
            public void onFailure(Call<List<ProductResponse>> call, Throwable t) {

            }
        });

    }
}