package com.example.eblackgold;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface APIInterface {

    @POST("/api/User/register-customer/")
    Call<AddCustomerModel> registerCustomer(@Body AddCustomerModel customer);

    @POST("/api/Product/add-product/")
    Call<AddProductModel> addProduct(@Body AddProductModel product);

    @POST("/api/Authorization/login/")
    Call<LoginAuthorizationModel> authorizeLogin(@Body LoginAuthorizationModel auth);

    @GET("/api/Product/get-all-products/")
    Call<List<AddProductModel>> getAllProducts();
}
