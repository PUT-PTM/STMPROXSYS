package com.example.adam.ptmvol2;

import android.util.Log;

import java.util.Random;

public class Threads_god_halph extends Layout_vol1 implements Runnable
{

    private int n;
    Random rand = new Random();
    //ImageView thread_view;
    public Threads_god_halph()
    {
        //this.n=n;
        //this.thread_view = thread_view;
    }

    @Override
    public void run()    {
        while(true)
        {
           // Random rand = new Random();
            n = rand.nextInt(200);
            zmienna_glob = n;

            Log.i(TAG, "watek");
            System.out.println(zmienna_glob);


            try{
                Thread.sleep(500);
            }catch (InterruptedException e)  {
                e.printStackTrace();
            }
        }
    }
}
