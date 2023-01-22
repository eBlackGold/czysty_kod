package com.example.eblackgold;

import java.util.ArrayList;
import java.util.List;

public class TemporaryData {
    public static String username;
    private static List<ItemModel> cart = new ArrayList<>();
    public static ItemModel selectedItem;
    public static String role;

    public static void AddToCart(ItemModel item) {
        cart.add(item);
    }

    public static List<ItemModel> getCart() {
        return TemporaryData.cart;
    }

    public static List<ProductOrderModel> getOrderCart() {
        List<ProductOrderModel> productOrderModelList = new ArrayList<>();

        for(int i = 0; TemporaryData.cart.size() > i; i++) {
            ItemModel cartItem = TemporaryData.cart.get(i);
            productOrderModelList.add(new ProductOrderModel(cartItem.id, 1));
        }

        return productOrderModelList;
    }

}
