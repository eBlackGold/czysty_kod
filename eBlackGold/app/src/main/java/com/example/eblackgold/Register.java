package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

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

        register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (email.toString().trim().matches(emailValidation) && !email.toString().isEmpty()) {
                    if (password.toString().matches(passwordR.toString())) {
                        // Zapis użytkownika do bazy, przejście do aktywności konto
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
    }
}