package com.example.eblackgold;

import com.google.gson.annotations.SerializedName;

public class AddProductModel {
    @SerializedName("Login")
    public String Login;
    @SerializedName("Name")
    public String Name;
    @SerializedName("Price")
    public double Price;
    @SerializedName("UnitsInStock")
    public int UnitsInStock;
    @SerializedName("CoalType")
    public String CoalType;

}
