#include "TimerOne.h" // timer 
#include <SoftwareSerial.h> // bluetooth

SoftwareSerial Bluetooth(8, 9); // piny bt
int d = 7;
int trig = A3;
int echo = A2;
int czas = 0;
int odl = 0;
int dane;
int pom = 0;

void setup() {
  Serial.begin(9600);
  Bluetooth.begin(9600);
  //Timer1.initialize(100000);        
  //Timer1.attachInterrupt(T1);
  pinMode(d,OUTPUT);
  pinMode(trig, OUTPUT);
  pinMode(echo, INPUT);
  
}

/*void T1()
{
  pom = pom ^ 1;
  if(pom == 1) digitalWrite(d,digitalRead(d)^1);
}
*/

void loop() {
  digitalWrite(trig, LOW);
  delayMicroseconds(2);
  digitalWrite(trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig, LOW);
  czas = pulseIn(echo, HIGH);
  odl = czas / 58;
  Serial.println(czas);

  Serial.println(odl);

  dane = odl;
  Bluetooth.println(dane);
  delay(1000);
}
