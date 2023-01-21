package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Offers extends AppCompatActivity {




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_offers);


        APIInterface apiInterface = APIClient.getClient().create(APIInterface.class);

        List<String> names = new ArrayList<String>();
        List<String> quantity = new ArrayList<String>();
        List<String> prices = new ArrayList<String>();
        List<String> prodTypes = new ArrayList<String>();
        List<Integer> images = new ArrayList<Integer>();

        Call<List<ProductResponse>> call = apiInterface.getAllProducts();
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
                ListView offersList = findViewById(R.id.productListOffers);
                OffersListAdapter offersListAdapter = new OffersListAdapter(getApplicationContext(), productNamesList, unitsList, pricesList, typesList, imagesList);
                offersList.setAdapter(offersListAdapter);
                offersList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        //position -> index w liście
                        ProductResponse offer = offers.get(position);
                        //ProductOrderModel item = new ProductOrderModel((int) offer.id, 1);
                        ItemModel item = new ItemModel();
                        item.id = (int) offer.id;
                        item.name = offer.Name;
                        item.quantity = 1;
                        item.unitPrice = Double.parseDouble(offer.unitPrice);

                        TemporaryData.selectedItem = item;
                        Intent intent = new Intent(getBaseContext(), AddToCart.class);
                        startActivity(intent);
                    }
                });
            }

            @Override
            public void onFailure(Call<List<ProductResponse>> call, Throwable t) {
                Toast.makeText(getApplicationContext(), t.getMessage(), Toast.LENGTH_SHORT);
            }
        });

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