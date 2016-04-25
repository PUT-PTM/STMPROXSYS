#include "TimerOne.h"
int d1 = A0;
int d2 = A1;
int d3 = A2;
int d4 = A3;
int d5 = A4;   
int t1 = 2;
int e1 = 3;
int t2 = 4;
int e2 = 5;
int t3 = 6;
int e3 = 7;
int t4 = 8;
int e4 = 9;  
int czas1 = 0;
int czas2 = 0;
int czas3 = 0;
int czas4 = 0;
int od1 = 0;
int od2 = 0;
int od3 = 0;
int od4 = 0;
bool blisko = false;

int pom = 0;

void setup() 
{

  Serial.begin(9600);
  Timer1.initialize(100000);        
  Timer1.attachInterrupt(T1);
    pinMode(d1,OUTPUT); 
    pinMode(d2,OUTPUT);  
    pinMode(d3,OUTPUT);  
    pinMode(d4,OUTPUT);  
    pinMode(d5,OUTPUT);  
    pinMode(t1,OUTPUT);  
    pinMode(t2,OUTPUT);  
    pinMode(t3,OUTPUT);  
    pinMode(t4,OUTPUT);
    pinMode(e1,INPUT); 
    pinMode(e2,INPUT); 
    pinMode(e3,INPUT); 
    pinMode(e4,INPUT);   
}

 
void T1()
{ pom = pom ^ 1;
  if(pom == 1)
  {
    if((od1 < 15) && (od1 > 5)) digitalWrite(d1, digitalRead(d1) ^ 1);
    if(od1 >= 15) digitalWrite(d1,LOW);
    if((od2 < 15) && (od2 > 5)) digitalWrite(d2, digitalRead(d2) ^ 1);
    if(od2 >= 15) digitalWrite(d2,LOW);
    if((od3 < 15) && (od3 > 5)) digitalWrite(d3, digitalRead(d3) ^ 1);
    if(od3 >= 15) digitalWrite(d3,LOW);
    if((od4 < 15) && (od4 > 5)) digitalWrite(d4, digitalRead(d4) ^ 1);
    if(od4 >= 15) digitalWrite(d4,LOW);
  }
  if((od1 <= 5) || (od2 <= 5)  || (od3 <= 5)  || (od4 <= 5)) blisko = true;
  else  blisko = false;
  if(od1 <= 5) digitalWrite(d1, HIGH);
  if(od2 <= 5) digitalWrite(d2, HIGH);
  if(od3 <= 5) digitalWrite(d3, HIGH);
  if(od4 <= 5) digitalWrite(d4, HIGH);
  if(blisko == true) digitalWrite(d5, digitalRead(d5) ^ 1);
  else digitalWrite(d5,LOW);
}
void loop() 
{
  //CZUJNIK 1
  digitalWrite(t1, LOW);
  delayMicroseconds(2);
  digitalWrite(t1, HIGH);
  delayMicroseconds(10);
  digitalWrite(t1, LOW);
  czas1 = pulseIn(e1, HIGH);
  od1 = czas1 / 58;
  Serial.println("Czujnik 1: ");  Serial.println(od1); 
   
  //CZUJNIK 2
  digitalWrite(t2, LOW);
  delayMicroseconds(2);
  digitalWrite(t2, HIGH);
  delayMicroseconds(10);
  digitalWrite(t2, LOW);
  czas2 = pulseIn(e2, HIGH);
  od2 = czas2 / 58;
  Serial.println("Czujnik 2: "); Serial.println(od2);

  //CZUJNIK 3
  digitalWrite(t3, LOW);
  delayMicroseconds(2);
  digitalWrite(t3, HIGH);
  delayMicroseconds(10);
  digitalWrite(t3, LOW);
  czas3 = pulseIn(e3, HIGH);
  od3 = czas3  / 58;
  Serial.println("Czujnik 3: "); Serial.println(od3);

  // CZUJNIK 4
  digitalWrite(t4, LOW);
  delayMicroseconds(2);
  digitalWrite(t4, HIGH);
  delayMicroseconds(10);
  digitalWrite(t4, LOW);
  czas4 = pulseIn(e4, HIGH);
  od4 = czas4  / 58;
  Serial.println("Czujnik 4: "); Serial.println(od4);
  
  delay(50);
}
