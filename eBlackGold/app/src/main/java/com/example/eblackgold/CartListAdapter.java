package com.example.eblackgold;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class CartListAdapter extends BaseAdapter {

    Context context;
    String[] productNamesList;
    String[] unitsList;
    String[] pricesList;
    String[] typesList;
    int[] imagesList;

    LayoutInflater inflater;

    public CartListAdapter(Context context, String[] productNamesList, String[] unitsList, String[] pricesList, String[] typesList, int[] imagesList)
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
        convertView = inflater.inflate(R.layout.data_row_cart, null);
        TextView productName = (TextView) convertView.findViewById(R.id.productNameDataRowCart);
        TextView units = (TextView) convertView.findViewById(R.id.unitsDataRowCart);
        TextView price = (TextView) convertView.findViewById(R.id.priceDataRowCart);
        TextView type = (TextView) convertView.findViewById(R.id.typeDataRowCart);
        ImageView img = (ImageView) convertView.findViewById(R.id.imageDataRowCart);

        productName.setText(productNamesList[position]);
        units.setText(unitsList[position]);
        price.setText(pricesList[position]);
        type.setText(typesList[position]);
        img.setImageResource(imagesList[position]);

        Button edit = (Button) convertView.findViewById(R.id.buttonEdit);
        Button delete = (Button) convertView.findViewById(R.id.buttonDelete);

        edit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod edytujący zamówienie
                CharSequence text = "edit button";
                int duration = Toast.LENGTH_SHORT;

                Toast toast = Toast.makeText(context, text, duration);
                toast.show();
            }
        });

        delete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Kod usuwający zamówienie zlisty kupującego
                CharSequence text = "delete button";
                int duration = Toast.LENGTH_SHORT;

                Toast toast = Toast.makeText(context, text, duration);
                toast.show();
            }
        });

        return convertView;
    }
}
