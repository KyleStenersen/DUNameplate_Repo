
//INCLUDED LIBRARIES AND FUNCTION PROTOTYPES --------------------------

#ifndef Plates_h
#define Plates_h

#include <Arduino.h>
#include "Motor.h"
#include "Text.h"
#include "GlobalSettings.h"

class Plates {
  public:
    Plates();
    void printOne(char* plateText);
    void goToALetter(char* letter);
    void xyHome();
    void stampTest();
    void spinX(float xinch);
    void spinY(float yinch);
    void spinL(int lDeg);
    void killAllMotors();
    void homeMachine();
    
  private: 
    float halfCurrentLine(int lineNumber);
    void motorsOn_GoToPrintStart();
    void letterWarmUpAndGo_W();
};

#endif
