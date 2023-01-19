package com.example.eblackgold;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.EditText;
import android.widget.ScrollView;

public class UserProfile extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_profile);

        getSupportActionBar().hide();

        EditText name = findViewById(R.id.name);
        EditText surname = findViewById(R.id.surname);
        EditText address = findViewById(R.id.address);

        ScrollView history = findViewById(R.id.history);
    }
}