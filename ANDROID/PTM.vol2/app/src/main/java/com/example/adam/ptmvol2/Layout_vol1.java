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
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Random;
import java.util.Set;
import java.util.UUID;


public class Layout_vol1 extends AppCompatActivity
{
    ImageButton on_and_off;
    ImageView module_value;
    ListView devicelist;


    ImageView[][] scale = new ImageView[4][4];

    volatile int zmienna_glob;
    volatile int[] value = new int[4];

    int n0 = 0;
    int n1 = 1;
    int n2 = 2;
    int n3 = 3;


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

        founded_devices();

        on_and_off.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Log.i(TAG, "BUTTON HAS BEEN PUSHED!");

                //founded_devices();

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

        devicelist = (ListView)findViewById(R.id.listView);
        final ArrayAdapter adapter = new ArrayAdapter(this,android.R.layout.simple_list_item_1, mArrayAdapter);
        devicelist.setAdapter(adapter);

        devicelist.setOnItemClickListener(myListClickListener);
        Button find_more = (Button) findViewById(R.id.button_find);

        find_more.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                discovering_devices();
            }
        });
    };

    private AdapterView.OnItemClickListener myListClickListener = new AdapterView.OnItemClickListener()
    {
        public void onItemClick (AdapterView<?> av, View v, int arg2, long arg3)
        {
            // Get the device MAC address, the last 17 chars in the View
            String info = ((TextView) v).getText().toString();
            String address = info.substring(info.length() - 17);

           /* // Make an intent to start next activity.
            Intent i = new Intent(DeviceList.this, ledControl.class);

            //Change the activity.
            i.putExtra(EXTRA_ADDRESS, address); //this will be received at ledControl (class) Activity
            startActivity(i);*/
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

        public void run() {
            while (true) {
                Random rand = new Random();
                for(int i=0; i<4; i++)
                {
                    value[i] = rand.nextInt(200);
                }

                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public class ColorThreadtop extends Thread
    {
        private int no=0;

        public void run() {
            while(true) {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {

                        scale[no][0] = (ImageView)findViewById(R.id.imageView_top1);
                        scale[no][1] = (ImageView)findViewById(R.id.imageView_top2);
                        scale[no][2] = (ImageView)findViewById(R.id.imageView_top3);
                        scale[no][3] = (ImageView)findViewById(R.id.imageView_top4);
                        colorchanges(no);
                    }
                });

                try {
                    Thread.sleep(5);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }

        }
    }

    public class ColorThreadbot extends Thread
    {
        private int no=1;
        public void run() {
            while(true) {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {

                        scale[no][0] = (ImageView)findViewById(R.id.imageView_bot1);
                        scale[no][1] = (ImageView)findViewById(R.id.imageView_bot2);
                        scale[no][2] = (ImageView)findViewById(R.id.imageView_bot3);
                        scale[no][3] = (ImageView)findViewById(R.id.imageView_bot4);
                        colorchanges(no);
                    }
                });
                try {
                    Thread.sleep(5);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public class ColorThreadleft extends Thread
    {
        private int no=2;

        public void run() {
            while(true) {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {

                        scale[no][0] = (ImageView)findViewById(R.id.imageView_left1);
                        scale[no][1] = (ImageView)findViewById(R.id.imageView_left2);
                        scale[no][2] = (ImageView)findViewById(R.id.imageView_left3);
                        scale[no][3] = (ImageView)findViewById(R.id.imageView_left4);
                        colorchanges(no);
                    }
                });

                try {
                    Thread.sleep(5);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }

        }
    }

    public class ColorThreadright extends Thread
    {
        private int no=3;

        public void run() {
            while(true) {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {

                        scale[no][0] = (ImageView)findViewById(R.id.imageView_right1);
                        scale[no][1] = (ImageView)findViewById(R.id.imageView_right2);
                        scale[no][2] = (ImageView)findViewById(R.id.imageView_right3);
                        scale[no][3] = (ImageView)findViewById(R.id.imageView_right4);
                        colorchanges(no);
                    }
                });

                try {
                    Thread.sleep(5);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }

        }
    }

    public void push_button(View v)
    {
        Runnable runner;
        Thread thread1;

        runner = new TempThread();
        thread1 = new Thread(runner);
        thread1.start();

        Runnable[] colorchangesrunners = new Runnable[4];
        Thread[] threads = new Thread[4];
        colorchangesrunners[0] = new ColorThreadtop();
        colorchangesrunners[1] = new ColorThreadbot();
        colorchangesrunners[2] = new ColorThreadleft();
        colorchangesrunners[3] = new ColorThreadright();

        for(int i=0; i<4; i++)
        {
            threads[i] = new Thread(colorchangesrunners[i]);
        }
        for(int i=0; i<4; i++)
        {
            threads[i].start();
        }

    }

    void colorchanges(int i)
    {
        /*Log.i(TAG, "COLOR CHANGES!");
        System.out.println(i);*/
        if (value[i] > 175 && value[i] <= 200) {
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.GREEN);
            scale[i][2].setBackgroundColor(Color.GREEN);
            scale[i][3].setBackgroundColor(Color.YELLOW);
            }
        else if (value[i] > 150 && value[i] <= 175) {
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.GREEN);
            scale[i][2].setBackgroundColor(Color.GREEN);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else if (value[i] > 125 && value[i] <= 150) {
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.GREEN);
            scale[i][2].setBackgroundColor(Color.YELLOW);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else if (value[i] > 100 && value[i] <= 125) {
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.GREEN);
            scale[i][2].setBackgroundColor(Color.RED);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else if (value[i] > 75 && value[i] <= 100) {
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.YELLOW);
            scale[i][2].setBackgroundColor(Color.RED);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else if (value[i] > 50 && value[i] <= 75) {
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.RED);
            scale[i][2].setBackgroundColor(Color.RED);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else if (value[i] > 25 && value[i] <= 50) {
            scale[i][0].setBackgroundColor(Color.YELLOW);
            scale[i][1].setBackgroundColor(Color.RED);
            scale[i][2].setBackgroundColor(Color.RED);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else if (value[i] > 0 && value[i] <= 25) {
            scale[i][0].setBackgroundColor(Color.RED);
            scale[i][1].setBackgroundColor(Color.RED);
            scale[i][2].setBackgroundColor(Color.RED);
            scale[i][3].setBackgroundColor(Color.RED);
            }
        else{
            scale[i][0].setBackgroundColor(Color.GREEN);
            scale[i][1].setBackgroundColor(Color.GREEN);
            scale[i][2].setBackgroundColor(Color.GREEN);
            scale[i][3].setBackgroundColor(Color.GREEN);
        }
    }
}


