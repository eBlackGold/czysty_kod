package com.example.eblackgold;

import com.google.gson.annotations.SerializedName;

public class LoginAuthorizationModel {
    @SerializedName("Login")
    public String login;
    @SerializedName("Password")
    public String password;
    @SerializedName("Role")
    public String role;

    public LoginAuthorizationModel(String login, String password, String role) {
        this.login = login;
        this.password = password;
        this.role = role;
    }
}
