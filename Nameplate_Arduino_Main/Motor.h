#ifndef Motor_h
#define Motor_h

#include <Arduino.h>
#include "SpeedyStepper.h"
#include <TMCStepper.h>
#include "Encoder.h"
#include "GlobalSettings.h"

class Motor
{
  public:
    Motor();
    void motorSetupAll();
    
    void xGo(float xInches, float* xAbsPosition = 0);
    void xGoNonBlocking(float xInches, float* xAbsPosition = 0);
    void xOff();
    void xOn();    
    void xHome();
    
    void yGo(float yInches, float* yAbsPosition = 0);
    void yOff();
    void yOn();
    void yHome();

    void letterGo(float goDegree, float goalDegree=0);
    int letterGoNonBlocking(float goDegree); 
    void processRetries(float goDegree, float goalDegree, float angle1); 
    void letterOff();
    void letterOn();

    void stamp();
    void stampMotorOn();
    void stampMotorOff();

    void warmUp();
    void processXAndLetterMovement();

    void changeAccelLetter(int accel);
    void changeVelocityLetter(int velo);
    void changeMicrosteps(int msteps);
    

  private:
};

#endif
