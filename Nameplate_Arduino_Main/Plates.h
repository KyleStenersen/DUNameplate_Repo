#ifndef Plates_h
#define Plates_h

#include <Arduino.h>
#include "Motor.h"
#include "Text.h"
#include "GlobalSettings.h"
#include "Estop.h"

class Plates {
  public:
    Plates();
    void printOne(char* plateText);
    void goToALetter(char* letter);
    void xyHome();
    void stampTest();
    void spinX(float xinch);
    void spinY(float yinch);
    void spinL(float lDeg);
    void killAllMotors();
    void motorsOn();
    void changeLetterDegreeAdjustment(float degAdjustment);
    
  private: 
    float halfCurrentLine(int lineNumber);
    void motorsOn_GoToPrintStart();
};

#endif
