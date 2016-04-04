// Pomiar jednym czujnikiem

#define trigC1 6
#define echoC1 7 
//#define LED1 X

int maximumRange = 200;
int minimumRange = 0;
long duration, distance;

void setup() 
{
	Serial.begin(9600);
	pinMode(trigC1, OUTPUT);
	pinMode(echoC1, INPUT);
	//pinMode(LED1, OUTPUT);									beda diody bedzie ta funkcja
}

void loop() 
{
	
	digitalWrite(trigC1, LOW);  // "ustawia niski stan"
	delayMicroseconds(2);			
	digitalWrite(trigC1, HIGH);  // "emitowanie fali" na 10us
	delayMicroseconds(10);
	digitalWrite(trigC1, LOW);	// "zakonczenie emitowania fali"

	duration = pulseIn(echoC1, HIGH); // pulseIn zwraca wartosc czasu od momentu przejscia echo w stan HIGH do czasu kiedy przejdzie na LOW
	
	distance = duration / 58.2; //z czasu otrzymujemy odleglosc

	/*
	if (distance >= maximumRange || distance <= minimumRange)
	{
		digitalWrite(LED1,HIGH)...
	}
	
	else
	{
		//if(distance...)
		//wysylanie danych przez bluetooth

	}
	*/

	// czekamy przed nastepnym pomiarem
	delay(50);
}