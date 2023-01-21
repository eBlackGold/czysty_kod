package com.example.eblackgold;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Cart extends AppCompatActivity {

    APIInterface apiInterface = APIClient.getClient().create(APIInterface.class);

    //Na sztywno podane wartości parametrów dla produktów do testowania listy
//    String productNamesList[] = {"Produkt1", "Produkt2", "Produkt3"};
//    String unitsList[] = {"30", "10", "999"};
//    String pricesList[] = {"30zł", "1200zł", "475zł"};
//    String typesList[] = {Integer.toString(R.string.typ1), Integer.toString(R.string.typ2), Integer.toString(R.string.typ3)};
//    int imagesList[] = {R.drawable.ic_box, R.drawable.ic_box, R.drawable.ic_box};

    List<String> names = new ArrayList<String>();
    List<String> quantity = new ArrayList<String>();
    List<String> prices = new ArrayList<String>();
    List<String> prodTypes = new ArrayList<String>();
    List<Integer> images = new ArrayList<Integer>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart);

        List<ItemModel> offers = TemporaryData.getCart();
        for(int i=0;i<offers.size();i++) {
            names.add(offers.get(i).name);
            quantity.add(String.valueOf(offers.get(i).quantity));
            prices.add(String.valueOf(offers.get(i).unitPrice));
            //prodTypes.add(offers.get(i).CoalType);
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
            //typesList[i] = prodTypes.get(i);
            imagesList[i] = images.get(i);
        }


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
                List<ProductOrderModel> orderItems = TemporaryData.getOrderCart(); // tu przypisać rzeczy z koszyka i je usunąć
                SubmitOrderModel order = new SubmitOrderModel(TemporaryData.username, orderItems);
                Call<Void> call = apiInterface.submitOrder(order);
                call.enqueue(new Callback<Void>() {
                    @Override
                    public void onResponse(Call<Void> call, Response<Void> response) {
                        Intent intent = new Intent(getBaseContext(), Offers.class);
                        startActivity(intent);
                    }

                    @Override
                    public void onFailure(Call<Void> call, Throwable t) {

                    }
                });

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