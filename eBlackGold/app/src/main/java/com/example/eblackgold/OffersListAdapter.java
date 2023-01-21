package com.example.eblackgold;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class OffersListAdapter extends BaseAdapter {

    Context context;
    String[] productNamesList;
    String[] unitsList;
    String[] pricesList;
    String[] typesList;
    int[] imagesList;

    LayoutInflater inflater;

    public OffersListAdapter(Context context, String[] productNamesList, String[] unitsList, String[] pricesList, String[] typesList, int[] imagesList)
    {
        this.context = context;
        this.productNamesList = productNamesList;
        this.unitsList = unitsList;
        this.pricesList = pricesList;
        this.imagesList = imagesList;
        this.typesList = typesList;
        inflater = LayoutInflater.from(context);
    }

    @Override
    public int getCount() {
        return productNamesList.length;
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        Log.d("VIEW", productNamesList[position]);
        convertView = inflater.inflate(R.layout.data_row_offers, null);
        TextView productName = (TextView) convertView.findViewById(R.id.productNameDataRowOffers);
        TextView units = (TextView) convertView.findViewById(R.id.unitsDataRowOffers);
        TextView price = (TextView) convertView.findViewById(R.id.priceDataRowOffers);
        TextView type = (TextView) convertView.findViewById(R.id.typeDataRowOffers);
        ImageView img = (ImageView) convertView.findViewById(R.id.imageDataRowOffers);

        productName.setText(productNamesList[position]);
        units.setText(unitsList[position]);
        price.setText(pricesList[position]);
        type.setText(typesList[position]);
        img.setImageResource(imagesList[position]);

        return convertView;
    }
}
