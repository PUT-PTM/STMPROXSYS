#include "TimerOne.h"
int dioda1 = 3;
int dioda2 = 4;   
int trig2 = 7;
int echo2 = 8;
int trig1 = 5;
int echo1 = 6;     
int EchoTime1 = 0; 
int EchoTime2 = 0;   
int Distance1 = 0;
int Distance2 = 0;   



void setup() 
{

  Serial.begin(9600);
  Timer1.initialize(100000);        
  Timer1.attachInterrupt(T1);
  pinMode(trig1, OUTPUT);
  pinMode(echo1, INPUT);
  pinMode(trig2, OUTPUT);
  pinMode(echo2, INPUT);
  pinMode(dioda1, OUTPUT);
  pinMode(dioda2, OUTPUT);     
}

 
void T1()
{
  if(Distance1 < 15) digitalWrite(3, digitalRead(3) ^ 1);
  else digitalWrite(3,LOW);
  if(Distance2 < 15) digitalWrite(4, digitalRead(4) ^ 1);
  else digitalWrite(4,LOW);
}

void loop() 
{
  digitalWrite(trig1, LOW);
  delayMicroseconds(2);
  digitalWrite(trig1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig1, LOW);
  EchoTime1 = pulseIn(echo1, HIGH);

   Distance1 = EchoTime1 / 58;
   Serial.println(Distance1);  

  digitalWrite(trig2, LOW);
  delayMicroseconds(2);
  digitalWrite(trig2, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig2, LOW);
  EchoTime2 = pulseIn(echo2, HIGH);

  Distance2 = EchoTime2 / 58;
  Serial.println(Distance2);

  
  delay(50);
}
