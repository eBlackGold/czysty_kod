package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportActionBar().hide();

        String emailValidation = "([a-zA-z0-9._-]+@)([a-z]+)(\\.+[a-z]+)";
        EditText email = findViewById(R.id.email_login);
        EditText password = findViewById(R.id.password_login);
        TextView restorePassword = findViewById(R.id.restore);
        Button login = findViewById(R.id.login);
        TextView register = findViewById(R.id.register_page);
        APIInterface apiInterface = APIClient.getClient().create(APIInterface.class);

        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if ((email.getText().toString().matches(emailValidation) && !email.getText().toString().isEmpty())) {

                    LoginAuthorizationModel customer = new LoginAuthorizationModel(email.getText().toString(), password.getText().toString(), "Customer");
                    Call<Void> call = apiInterface.authorizeLogin(customer);
                    call.enqueue(new Callback<Void>() {
                        @Override
                        public void onResponse(Call<Void> call, Response<Void> response) {
                            if(response.code()==200) {
                                Intent intent = new Intent(getBaseContext(), SellerProfile.class);
                                startActivity(intent);
                            } else {
                                Toast.makeText(getApplicationContext(), "Błąd " + response.code(), Toast.LENGTH_SHORT).show();
                            }
                        }

                        @Override
                        public void onFailure(Call<Void> call, Throwable t) {
                            Toast.makeText(getApplicationContext(), "Błąd logowania. " + t.getMessage(), Toast.LENGTH_SHORT).show();
                        }
                    });
                }
                else {
                    Toast.makeText(getBaseContext(),"Nieprawidłowy adres e-mail", Toast.LENGTH_SHORT).show();
                }
            }
        });

        restorePassword.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Przejście do odzyskiwania hasła
            }
        });

        register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Przejście do rejestracji
                Intent intent = new Intent(getBaseContext(), Register.class);
                startActivity(intent);
            }
        });
    }
}