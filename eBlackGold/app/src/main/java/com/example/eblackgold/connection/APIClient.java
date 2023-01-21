package com.example.eblackgold.connection;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class APIClient {
    private static Retrofit retrofit;
    //private static final String BASE_URL = "https://10.0.2.2:7270";
    private static OkHttpClient client = UnsafeOkHttpClient.getUnsafeOkHttpClient();

    public static Retrofit getClient(String url) {
        if(retrofit == null) {
            retrofit = new Retrofit.Builder()
                    .baseUrl(url)
                    .addConverterFactory(GsonConverterFactory.create())
                    .client(APIClient.client)
                    .build();
        }
        return retrofit;
    }
}
