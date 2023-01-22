package com.example.eblackgold;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class SubmitOrderModel {
    @SerializedName("Login")
    public String Login;
    @SerializedName("ProductOrderModels")
    public List<ProductOrderModel> productOrderModels;

    public SubmitOrderModel(String login, List<ProductOrderModel> items) {
        this.Login = login;
        this.productOrderModels = items;
    }
}
