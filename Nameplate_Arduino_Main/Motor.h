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
    void setupAll();
    void updateAll();
    

    void setupXGoNonBlocking(float xInches, float* xAbsPosition = 0);
    void yGo(float yInches, float* yAbsPosition = 0);
    void setupYGoNonBlocking(float yInches, float* yAbsPosition = 0);
    int setupLetterGoNonBlocking(float goDegree);
    void processRetries(float goDegree, float goalDegree, float angle1); 

    void processXAndLetterMovement();
    void processXAndYMovement(); 
    void processXAndYMovementForHome(); 

    void xOff();
    void xOn();
    void yOff();
    void yOn();
    void letterOff();
    void letterOn();
    void stampMotorOn();
    void stampMotorOff();
    
    void stamp();    
    
    void xHome();
    void yHome(); 
    void setupXYSyncGoAlmostHome(float xAbs, float yAbs);  

    void warmUp();

    void changeAccelLetter(int accel);
    void changeVelocityLetter(int velo);
    void changeMicrosteps(int msteps);

// for testing and backwards compatability

    void xGo(float xInches, float* xAbsPosition = 0);
    void letterGo(float goDegree, float goalDegree=0);

  private:
};
  
#endif
