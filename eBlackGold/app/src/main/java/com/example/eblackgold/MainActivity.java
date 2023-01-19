package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportActionBar().hide();

        String emailValidation = "[a-zA-z0-9._-]+@[a-z]+\\.+[a-z]+";
        EditText email = findViewById(R.id.email_login);
        EditText password = findViewById(R.id.password_login);
        TextView restorePassword = findViewById(R.id.restore);
        Button login = findViewById(R.id.login);
        TextView register = findViewById(R.id.register_page);

        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Tu musi być jeszcze && walidacja z bazy
                if (email.toString().matches(emailValidation) && !email.toString().isEmpty()) {
                    // Walidacja hasła z bazy
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
                Intent intent = new Intent(getBaseContext(), Offers.class);
                startActivity(intent);
            }
        });
    }
}