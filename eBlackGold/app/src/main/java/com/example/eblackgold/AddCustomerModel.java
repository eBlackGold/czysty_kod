package com.example.eblackgold;

import com.google.gson.annotations.SerializedName;

public class AddCustomerModel {

    @SerializedName("Id")
    public int Id;
    @SerializedName("Login")
    public String Login;
    @SerializedName("Password")
    public String Password;
    @SerializedName("Name")
    public String Name;
    @SerializedName("Surname")
    public String Surname;
    @SerializedName("Address")
    public String Address;

    public AddCustomerModel(String login, String password) {
        this.Login = login;
        this.Password = password;
    }
}
