package com.example.eblackgold;

import com.google.gson.annotations.SerializedName;

public class ProductOrderModel {
    @SerializedName("ProductId")
    public int ProductId;
    @SerializedName("Quantity")
    public int Quantity;

    public ProductOrderModel(int id, int quantity) {
        this.ProductId = id;
        this.Quantity = quantity;
    }
}
