#include <Arduino.h>
#include <SPI.h>

const int slaveSelectPin = 10;
const int PWM1Pin = 9;

byte empfang[4];
int16_t Zielgeschwindigkeit = 0;
int16_t Restzeit = 0;

double Geschwindigkeit = 0;
unsigned long previousMillis = 0;
uint8_t previousMillis_single = 0;
uint8_t count = 0;

#define ZERO_PADDING 16
void SPrintZeroPadBin(uint16_t number) {
char binstr[]="0000000000000000";
uint8_t i=0;
uint16_t n=number;

   while(n>0 && i<ZERO_PADDING){
      binstr[ZERO_PADDING-1-i]=n%2+'0';
      ++i;
      n/=2;
   }
	
   Serial.print(binstr);
}

void execute(byte code){  
  //Für einzelnen Treiber,
  //sonst müssen so viele Transfers durchgeführt werden,
  //wie Treiber vorhanden sind. 
  //Erster Transfer letzter Treiber in der Kette.
  digitalWrite(slaveSelectPin, LOW);
  SPI.transfer(code);
  digitalWrite(slaveSelectPin, HIGH);
}

void enable(){
  execute(0b10111000);
}
void disable(){
  execute(0b10101000);
}
uint16_t getstatus(){
  execute(0b11010000);
  uint16_t result;
  delayMicroseconds(1);
  digitalWrite(slaveSelectPin, LOW);
  result = SPI.transfer(0) << 8;
  digitalWrite(slaveSelectPin, HIGH);
  delayMicroseconds(1);
  digitalWrite(slaveSelectPin, LOW);
  result |= SPI.transfer(0);
  digitalWrite(slaveSelectPin, HIGH);
  return result;
}

int x = 0;

void setup() {
  Serial.begin(115200);
  pinMode(slaveSelectPin, OUTPUT);
  pinMode(8, OUTPUT);
  digitalWrite(8, HIGH);
  SPI.begin();
  delay(100);
  enable();
  DDRD |= (1<<PD7);
}

void set_speed(uint8_t pin, int16_t speed){
  if(speed > 30) {
    tone(pin, (unsigned int)speed);
    digitalWrite(7, LOW);
  } else if (speed < -30) {
    tone(pin, (unsigned int)-speed);
    digitalWrite(7, HIGH);
  } else {
    noTone(pin);
  }
}

void loop() {
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= 1000) {
    previousMillis = currentMillis;
    Serial.print(x++);
    Serial.println(" Status");
    SPrintZeroPadBin(getstatus());
    Serial.println();
    Serial.print("Speed: ");
    Serial.println(Geschwindigkeit);
    Serial.print("Soll: ");
    Serial.println(Zielgeschwindigkeit);
    Serial.print("Restzeit: ");
    Serial.println(Restzeit);
  }
  if ((currentMillis & 0xFF) - previousMillis_single >= 1) {
    previousMillis_single = currentMillis & 0xFF;
    double speed_diff = ((double)Zielgeschwindigkeit - (double)Geschwindigkeit) / (double)Restzeit;
    if(Restzeit != 0)
      Geschwindigkeit += speed_diff;
    else
      Geschwindigkeit = Zielgeschwindigkeit;
    set_speed(PWM1Pin, (double)Geschwindigkeit);
    if(Restzeit > 0)
      Restzeit--;
    else
      Restzeit = 0;
    if(Geschwindigkeit == 0){
      if(count >= 200)
        disable();
      else
        count++;
    } else {      
      count = 0;
      enable();
    }
  }
}

void serialEvent() {
  Serial.readBytes(empfang, 4);
  Restzeit = (empfang[0] << 8) + empfang[1];
  Zielgeschwindigkeit = (empfang[2] << 8) + empfang[3];    
}