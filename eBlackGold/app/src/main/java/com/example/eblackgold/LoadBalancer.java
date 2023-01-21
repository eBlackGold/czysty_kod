package com.example.eblackgold;

import com.example.eblackgold.connection.APIClient;
import com.example.eblackgold.connection.APIInterface;

import java.util.Random;

public class LoadBalancer {
    private static String Url1 = "http://10.0.0.2:5270";
    private static String Url2 = "https://10.0.2.2:7270";
    private static final Random random = new Random();

    public static APIInterface get() {
        if(next()==1) {
            return APIClient.getClient(LoadBalancer.Url1).create(APIInterface.class);
        }
        return APIClient.getClient(LoadBalancer.Url2).create(APIInterface.class);
    }

    private static int next() {
        if (random.nextBoolean()) {
            return 1;
        }
        return 2;
    }
}
