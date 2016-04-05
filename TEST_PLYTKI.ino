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
  pinMode(trig1, OUTPUT);
  pinMode(echo1, INPUT);
  pinMode(trig2, OUTPUT);
  pinMode(echo2, INPUT);
  pinMode(dioda1, OUTPUT);
  pinMode(dioda2, OUTPUT);     
}
 
void loop() 
{
  digitalWrite(trig1, LOW);
  delayMicroseconds(2);
  digitalWrite(trig1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig1, LOW);
  EchoTime1 = pulseIn(echo1, HIGH);

  digitalWrite(dioda1, HIGH);  
  delay(Distance1*5);
  digitalWrite(dioda1, LOW); 
  delay(Distance1*5);
  
   Distance1 = EchoTime1 / 58;
 /*
  digitalWrite(trig2, LOW);
  delayMicroseconds(2);
  digitalWrite(trig2, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig2, LOW);
  EchoTime2 = pulseIn(echo2, HIGH);

  Distance2 = EchoTime2 / 58;
  // Obliczamy odległość
 
  
  
  
  digitalWrite(dioda2, HIGH);  
  delay(Distance2*2);
  digitalWrite(dioda2, LOW); 
  delay(Distance2*2);
  */
  delay(50);
}
