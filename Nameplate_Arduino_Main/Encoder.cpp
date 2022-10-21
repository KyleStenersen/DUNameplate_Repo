// PARSES AS5600 MAGNETIC ENCODER INPUT

// ADAPTED FROM: https://curiousscientist.tech/blog/as5600-magnetic-position-encoder
// has a lot of magic I2C and conversion from binary to degree angle so can go there for a lot more detail and documentation

// - PUBLIC FUNCTIONS:
// encoderSetup() - start/setup, checkMagnetPresence(), getAngle()
// float getAngle() - reads the raw input from encoder and returns degree location of letter-wheel
// - PRIVATE FUNCTIONS:
// checkMagnetPresence() - checks if the encoder is ready (magnet properly positioned) currently will get stuck waiting if not.

#include "Encoder.h"


//Magnetic sensor things-----------
int magnetStatus = 0;   //value of the status register (MD, ML, MH)
int lowbyte;  //raw angle 7:0
word highbyte;  //raw angle 7:0 and 11:8
float rawAngle;  //final raw angle 
float degAngle;


Encoder::Encoder(){}

//PUBLIC FUNCTIONS================================================

void Encoder::encoderSetup(){ 
  Wire.begin();   //start i2C  
  Wire.setClock(800000L);
  checkMagnetPresence();    //blocks until magnet is found  
  getAngle();   //initial set of current angle
}

//--------------------------

float Encoder::getAngle()
{
delay(11);

//  float check_1 = 400;
//  float check_2 = 500;
//  float check_3 = 600;
//  float check_4 = 700;
//  float check_5 = 800;
//
//  int timer = millis();
//
//  while (check_1 != check_2 && check_2 != check_3 && check_3 != check_4 && check_4 != check_5)
//  {  
    Wire.beginTransmission(0x36);
    Wire.write(0x0D);
    Wire.endTransmission();
    Wire.requestFrom(0x36, 1);
    
    while(Wire.available() == 0){
      Serial.println("stuck waiting for wire...");
    }
    lowbyte = Wire.read(); 
    Wire.beginTransmission(0x36);
    Wire.write(0x0C);
    Wire.endTransmission();
    Wire.requestFrom(0x36, 1);
    
    while(Wire.available() == 0)
    {
      Serial.println("stuck waiting for wire...");  
    }
    highbyte = Wire.read();
    highbyte = highbyte << 8;   //shifting to left 
    rawAngle = highbyte | lowbyte;  //int is 16 bits (as well as the word)
    degAngle = rawAngle * 0.087890625;    //raw angle in degrees = [rawAngle value between 0-4095] * (360/4096)
//    check_5 = check_4;
//    check_4 = check_3;
//    check_3 = check_2;
//    check_2 = check_1;
//    check_1 = degAngle;   
//  }

//  int getAngleTimer = millis() - timer;
//  Serial.print(". getAngleTimer = ");
//  Serial.println(getAngleTimer);
  
  return degAngle;
}

//PRIVATE FUNCTIONS================================================

void Encoder::checkMagnetPresence()
{  
  //This function runs in the setup() and it locks the MCU until the magnet is positioned properly

  while((magnetStatus & 32) != 32)
  {
    magnetStatus = 0;

    Wire.beginTransmission(0x36);
    Wire.write(0x0B);
    Wire.endTransmission();
    Wire.requestFrom(0x36, 1);

    while(Wire.available() == 0){
      Serial.println("magnet not found");
      }
    magnetStatus = Wire.read();
      
  }      
}
