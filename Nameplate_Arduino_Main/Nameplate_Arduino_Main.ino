
// DOUBLE U HUNTING SUPPLY - NAMEPLATE MACHINE 
// ------------------------------------------------
// This file contains: 
// Some initial setup for machine components,
// the Main loop that just checks for updates to input, and
// the stallguard ISR that shuts the machine down if a motor stalls
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

// ------------------
// Global Machine Setting Variables Initialized (GlobalSettings.h)
// Updated in InputResponse.cpp (case p:) from the GUI 
// On startup and prior to every new printOne() command

float X_OFFSET = 1.86;
float Y_OFFSET = 0.46;
float NAMEPLATE_SPACEING = 0.9;
float LINE_SPACEING = 0.145;
float LETTER_SPACEING = 0.095;

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
  pinMode(10, INPUT);
  pinMode(21, INPUT);
 // attachInterrupt(10,stall,RISING);
 // attachInterrupt(21,stall,RISING);
}
// ------------------


void loop() 
{
  if(Serial.available()) {     
    inputResponse.chooseAction(serialOps.grabInput());
  } 
}
     


//Stallgaurd Interrupt Service Routine
// ------------------------------------------------

void stall(){
  Serial.println(F("Killing"));
  plates.killAllMotors();
  serialOps.emptySerial();
}
