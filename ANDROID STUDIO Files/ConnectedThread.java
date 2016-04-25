package com.example.adam.ptmvol2;

import android.bluetooth.BluetoothSocket;
import android.util.Log;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.StringWriter;

public class ConnectedThread {


    BluetoothSocket mmSocket;
    InputStream mmInStream;
    OutputStream mmOutStream;

    BufferedReader bufferRead;
    String msg;
    int n;

    static String TAG2 = "BLUETOOTH";

    public ConnectedThread(BluetoothSocket socket)
    {
        mmSocket = socket;

        InputStream tmpIn = null;
        OutputStream tmpOut = null;

        try{
            tmpIn = mmSocket.getInputStream();
            tmpOut  = mmSocket.getOutputStream();
        }catch (IOException e) {
            Log.e(TAG2, "ERROR");
        }

        mmInStream = tmpIn;
        mmOutStream = tmpOut;
    }

    public void run(){

        while(true){
            try{
                StringWriter writer = new StringWriter();
                char[] buffer = new char[16];
                Log.i(TAG2, "omg jestem w bluetoothu");
                bufferRead = new BufferedReader(new InputStreamReader(mmInStream, "UTF8"));


                while((n = bufferRead.read(buffer)) != -1 && n<buffer.length)
                {
                    writer.write(buffer, 0, n);
                    if(writer.getBuffer().indexOf("%")!= -1)
                    {
                        break;
                    }
                }

                msg = writer.toString();

                writer.getBuffer().setLength(0);

            }catch (IOException e)
            {
                Log.e(TAG2, "connection lost");
                break;
            }
        }
    }

}
