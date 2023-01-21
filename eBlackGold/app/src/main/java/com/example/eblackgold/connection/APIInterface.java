package com.example.eblackgold.connection;

import com.example.eblackgold.AddCustomerModel;
import com.example.eblackgold.AddProductModel;
import com.example.eblackgold.LoginAuthorizationModel;
import com.example.eblackgold.ProductResponse;
import com.example.eblackgold.SubmitOrderModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface APIInterface {

    @POST("/api/User/register-customer/")
    Call<AddCustomerModel> registerCustomer(@Body AddCustomerModel customer);

    @POST("/api/Product/add-product/")
    Call<Void> addProduct(@Body AddProductModel product);

    @POST("/api/Authorization/login/")
    Call<Void> authorizeLogin(@Body LoginAuthorizationModel auth);

    @POST("/api/Order/submit-order")
    Call<Void> submitOrder(@Body SubmitOrderModel order);

    @GET("/api/Product/get-all-products/")
    Call<List<ProductResponse>> getAllProducts();
}
