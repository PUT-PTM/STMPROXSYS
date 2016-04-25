#include <SoftwareSerial.h>

SoftwareSerial Bluetooth(10, 11);
char BluetoothData = ' ';

void setup() {
  Serial.begin(9600);
  Serial.println("ARDUINO GOTOWE");
  Bluetooth.begin(9600);
  Bluetooth.println("BLUETOOTH GOTOWY");
  Bluetooth.println("CZEKAM NA WIADOMOSC");
}

void loop() 
{
   if (Bluetooth.available())
   {
       BluetoothData=Bluetooth.read();
       Serial.write(BluetoothData);
   }
   if (Serial.available())
   {
       BluetoothData =  Serial.read();
       Bluetooth.println(BluetoothData);  
    }
}

