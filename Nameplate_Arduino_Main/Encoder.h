#ifndef Encoder_h
#define Encoder_h

#include <Arduino.h>
#include <Wire.h> 

class Encoder {
  public:
    Encoder();
    float getAngle();
    void encoderSetup();
    
  private:
    void checkMagnetPresence();
};

#endif
