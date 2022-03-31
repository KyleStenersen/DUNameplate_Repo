// USED TO CHOOSE A MACHINE ACTION ACCORDING TO RECIEVED SERIAL MESSAGE
// CURRENTLY 1 FUNCTION WITH 8 ACTIONS
// chooseAction(serial message)
// ACTIONS: CHOSEN PER THE FIRST CHAR OF INPUT STRING "actionDefiner"
// ‘a’ plates.printOne(rest of serial input string) - print one tag per input
// ‘c’ plates.goToALetter(rest of serial input string) - letter wheel
// ‘h’ plates.xyHome() - build plate home
// ‘x’ plates.spinX(rest of serial input string) - move build plate in x by float inch value.
// ‘y’ plates.spinY(rest of serial input string) - move build plate in y by float inch value.
// ‘s’ plates.stampTest() - stamp machine motion once
// ‘b’ flip onboard LED on and off
// ‘e’ encoder.encoder.getAngle() - prints current encoder angle to serial monitor


#include "InputResponse.h"

Plates platesIR;
SerialOps serialOpsIR;
Encoder encoderIR;

InputResponse::InputResponse(){}

void InputResponse::chooseAction(const char* fullInputString) 
{
  char actionDefiner = fullInputString[0];
  char actionInfo[serialOpsIR.inputSize()];
  strcpy(actionInfo, fullInputString+1);
  
  switch (actionDefiner)
  {
    case 'a':    
    platesIR.printOne(actionInfo);
    serialOpsIR.emptySerial();
    break;

    case 'c':    
    platesIR.goToALetter(actionInfo);
    serialOpsIR.emptySerial();
    break;
    
    case 'h':
    platesIR.xyHome();
    serialOpsIR.emptySerial();
    break;
    
    case 'x':
    float inchx;
    inchx = atof(actionInfo);
    platesIR.spinX(inchx);
    serialOpsIR.emptySerial();
    break;

    case 'y':
    float inchy;
    inchy = atof(actionInfo);
    platesIR.spinY(inchy);
    serialOpsIR.emptySerial();
    break;

    case 'l':
    int degreeL;
    degreeL = atoi(actionInfo);
    platesIR.spinL(degreeL);
    serialOpsIR.emptySerial();
    break;
    
    case 's':
    platesIR.stampTest();
    serialOpsIR.emptySerial();
    break;

    case 'b':
    if (digitalRead(13)== HIGH)
    {
      digitalWrite(13,LOW);
    } 
    else
    {
      digitalWrite(13,HIGH);
    }
    break;

    case 'e':
    encoderIR.encoderSetup();
    Serial.println(encoderIR.getAngle());
    serialOpsIR.emptySerial();
    break;
  }
}
