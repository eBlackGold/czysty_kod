package com.example.eblackgold;

import com.google.gson.annotations.SerializedName;

public class ProductResponse {
    @SerializedName("id")
    public long id;
    @SerializedName("productName")
    public String Name;
    @SerializedName("quantiy")
    public int Quantity;
    @SerializedName("unitPrice")
    public String unitPrice;
    @SerializedName("coalType")
    public String CoalType;
}
