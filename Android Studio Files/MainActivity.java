package com.example.adam.ptmvol2;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Toast;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Random;
import java.util.Set;
import java.util.UUID;


public class Layout_vol1 extends AppCompatActivity {

    ImageButton on_and_off;
    //ImageView module_value;
    ListView devicelist;

    volatile int zmienna_glob;
    int pushed = 0;

    static final String NAME = "server name lelelel";
    static final UUID MY_UUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");

    private BluetoothAdapter mybluetooth = null;
    final ArrayList mArrayAdapter = new ArrayList();


    static String TAG = "ATTENTION PLOX!:";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_layout_vol1);

        on_and_off = (ImageButton) findViewById(R.id.imageButton);

        mybluetooth = BluetoothAdapter.getDefaultAdapter();

        if(mybluetooth==null)
        {
            Toast.makeText(getApplicationContext(),"BLUETOOTH NOT AVAIABLE", Toast.LENGTH_LONG).show();
            Log.i(TAG, "BLUETOOTH IS NOT AVAIABLE");
        }
        else if (!mybluetooth.isEnabled())
        {
            Intent enableBT = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableBT, 1);
        }



        on_and_off.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Log.i(TAG, "BUTTON HAS BEEN PUSHED!");

                founded_devices();

                push_button(v);

            }
        });
    }


    private void discovering_devices()
    {
        if(mybluetooth.isDiscovering())
        {
            mybluetooth.cancelDiscovery();
        }
        mybluetooth.startDiscovery();

        Intent discoverableIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
        discoverableIntent.putExtra(BluetoothAdapter.EXTRA_DISCOVERABLE_DURATION,300);
        startActivity(discoverableIntent);
    }

    private void founded_devices()
    {
        Set<BluetoothDevice> pairedDevices = mybluetooth.getBondedDevices();
        if(pairedDevices.size()>0) //jesli sa jakies sparowane urzadzenia
        {
            for(BluetoothDevice device : pairedDevices) // for each
            {
                mArrayAdapter.add(device.getName() + "\n" + device.getAddress());
            }
        }
        int i=0;
        for(mArrayAdapter.get(i);i<mArrayAdapter.size();i++)
        {
            System.out.println(mArrayAdapter.get(i));
        }
    };


    private final BroadcastReceiver mReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            String action = intent.getAction();
            //kiedy wyszukiwanie znajdzie urzadzenie
            if(BluetoothDevice.ACTION_FOUND.equals(action)){
                BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
                mArrayAdapter.add(device.getName()+"\n"+device.getAddress());
            }
        }
    };

    private class AcceptThread extends Thread
    {
        private final BluetoothServerSocket mmServerSocket;

        public AcceptThread(){

            BluetoothServerSocket tmp = null;
            try{
                tmp = mybluetooth.listenUsingRfcommWithServiceRecord(NAME, MY_UUID);
            }catch(IOException e)
            {
                Log.e(TAG, "polaczenie servera nieudane");
            }
            mmServerSocket = tmp;
        }

        public void run()
        {
            BluetoothSocket socket = null;
            while(true)
            {
                try{
                    socket = mmServerSocket.accept();
                }catch(IOException e)
                {
                    break;
                }

                if(socket != null)
                {
                    //instrukcje
                    //manageConnectedSocket(socket);
                    try {
                        mmServerSocket.close();
                    } catch (IOException e) {
                        Log.e(TAG, "ServerSocket error");
                    }
                    break;
                }
            }
        }

        public void cancel(){
            try{
                mmServerSocket.close();
            }catch (IOException e)
            {
                Log.e(TAG, "FIN");
            }
        }

    }

    public class TempThread extends Thread
    {
        private int n;
        ImageView module_value;
        //Random rand = new Random();
        public void run() {
            while (true) {
                Random rand = new Random();
                n = rand.nextInt(200);
                zmienna_glob = n;

                Log.i(TAG, "watek");
                System.out.println(zmienna_glob);

                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        module_value = (ImageView) findViewById(R.id.imageView1);
                        module_value.setBackgroundColor(Color.BLACK);
                        colors(module_value);
                    }
                });


                try {
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public void push_button(View v)
    {
        Log.i(TAG, "funkcja!");
        System.out.println(zmienna_glob);


        Runnable runner;
        Thread thread1;

        runner = new TempThread();
        thread1 = new Thread(runner);
        thread1.start();

    }

    void colors(ImageView module_value)
    {
        if (zmienna_glob < 15)
        {
            module_value.setBackgroundColor(Color.RED);
        }
        else if (zmienna_glob >=15 & zmienna_glob<100)
        {
            module_value.setBackgroundColor(Color.YELLOW);
        }
        else
        {
            module_value.setBackgroundColor(Color.GREEN);
        }
    }
}


