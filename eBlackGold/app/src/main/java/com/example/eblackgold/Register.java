package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Register extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        String emailValidation = "[a-zA-z0-9._-]+@[a-z]+\\.+[a-z]+";
        EditText email = findViewById(R.id.email_register);
        EditText password = findViewById(R.id.password_register);
        EditText passwordR = findViewById(R.id.password_repeated);
        Button register = findViewById(R.id.register);
        TextView login = findViewById(R.id.login_page);
        RadioButton buyer = findViewById(R.id.buyer);
        RadioButton seller = findViewById(R.id.seller);
        //APIInterface apiInterface = APIClient.getClient().create(APIInterface.class);

        register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                APIInterface apiInterface = LoadBalancer.get();
                if ((email.getText().toString().matches(emailValidation) && !email.getText().toString().isEmpty())) {
                    if (password.getText().toString().matches(passwordR.getText().toString())) {
                        // Zapis użytkownika do bazy, przejście do aktywności konto
                        AddCustomerModel customer = new AddCustomerModel(email.getText().toString(), password.getText().toString());
                        Call<AddCustomerModel> call = apiInterface.registerCustomer(customer);

                        if(seller.isChecked()) {
                            call = apiInterface.registerSupplier(customer);
                        }

                        call.enqueue(new Callback<AddCustomerModel>() {
                            @Override
                            public void onResponse(Call<AddCustomerModel> call, Response<AddCustomerModel> response) {
                                if(response.code()==200) {
                                    AddCustomerModel customerResponse = response.body();
                                    Toast.makeText(getApplicationContext(), "Pomyślnie utworzono użytkownika!", Toast.LENGTH_SHORT).show();
                                    Intent intent = new Intent(getBaseContext(), MainActivity.class);
                                    startActivity(intent);
                                } else {
                                    Toast.makeText(getApplicationContext(), "Błąd " + response.code(), Toast.LENGTH_SHORT).show();
                                }
                            }

                            @Override
                            public void onFailure(Call<AddCustomerModel> call, Throwable t) {
                                Toast.makeText(getApplicationContext(), "Błąd przy tworzeniu konta.", Toast.LENGTH_SHORT).show();
                            }
                        });
                    }
                    else {
                        Toast.makeText(getBaseContext(),"Hasła muszą się zgadzać", Toast.LENGTH_SHORT).show();
                    }
                }
                else {
                    Toast.makeText(getBaseContext(),"Nieprawidłowy adres e-mail", Toast.LENGTH_SHORT).show();
                }
            }
        });

        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getBaseContext(), MainActivity.class);
                startActivity(intent);
            }
        });
    }
}