//FUNCTION PROTOTYPES --------------------------

#ifndef Encoder_h
#define Encoder_h

#include <Arduino.h>
#include <Wire.h> 

class Encoder {
  public:  //PUBLIC FUNCTION PROTOTYPES FOR THIS CLASS that will be available anywhere with this .h library---
    Encoder();
    float getAngle();
    void encoderSetup();
    
  private:  // Declare variables that will be used in this .cpp only
    void checkMagnetPresence();
};

#endif
