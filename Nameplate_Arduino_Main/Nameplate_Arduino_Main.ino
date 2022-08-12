
// DOUBLE U HUNTING SUPPLY - NAMEPLATE MACHINE 
// ------------------------------------------------
// This file is the Main Entry-Point for the program and contains: 
// - Some initial setup for machine components,
// - the Main loop that just checks for updates to input, and
// - the stallguard ISR that shuts the machine down if a motor stalls
// ------------------------------------------------
// Code constructed by Kingdom Automation (Kyle Stenersen) - started in 12/2022
// ------------------------------------------------
 
#include <Arduino.h>
#include "Plates.h"
#include "Motor.h"
#include "SerialOps.h"
#include "InputResponse.h"
#include "Encoder.h"
#include "GlobalSettings.h"

Motor motor;
Plates plates;
SerialOps serialOps;
InputResponse inputResponse;
Encoder encoder;
Text text;
int estop_pin = 3;

// ------------------
// Global Machine Setting Variables Initialized (GlobalSettings.h)
// Updated in InputResponse.cpp (case p:) from the GUI 
// On startup and prior to every new printOne() command

float X_OFFSET_GLOBAL = 0;
float Y_OFFSET_GLOBAL = 0;
float X_ABS_PLATE_LOCATION_GLOBAL = 1.86;
float Y_ABS_PLATE_LOCATION_GLOBAL = 0.46;
float LINE_SPACEING_GLOBAL = 0.145;
float LETTER_SPACEING_GLOBAL = 0.095;
bool eStopBit = 0;

// ------------------
void setup() 
{
  Serial.begin(115200);
  delay(100);
  pinMode(13, OUTPUT);
  digitalWrite(13,LOW);
  text.setupHashMap();
  motor.motorSetupAll();
  encoder.encoderSetup();
  motor.warmUp();
  // Set X-Motor DIAG pin to INPUT
  pinMode(10, INPUT);
  // Set Y-Motor DIAG pin to INPUT
  pinMode(4, INPUT);
  // E-STOP interrupt
  pinMode(3, INPUT_PULLUP);
 // attachInterrupt(10,stall,RISING);
 // attachInterrupt(4,stall,RISING);
 attachInterrupt(3,estop,FALLING);
 eStopBit = 0;
}
// ------------------





void loop() 
{
  eStopBit = 0;
  if(Serial.available()) {     
    inputResponse.chooseAction(serialOps.grabInput());
  } 
}
     





//Estop and Stallguard Interrupt Service Routine
// ------------------------------------------------

void estop(){
  Serial.println("z2"); //Send signal to GUI so it can respond to estop condition
  
  plates.killAllMotors();
  eStopBit = 1;
  serialOps.emptySerial();
  plates.motorsOn();

  while (digitalRead(3) == 0)
  {
    //Freeze/do nothing
  }
}
