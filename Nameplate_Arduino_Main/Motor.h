#ifndef Motor_h
#define Motor_h

#include <Arduino.h>
#include <SpeedyStepper.h>
#include <TMCStepper.h>

class Motor
{
  public:
    Motor();
    void motorSetupAll();
    
    void xGo(float xInches, float* xAbsPosition = 0);
    void xOff();
    void xOn();    
    void xHome();
    
    void yGo(float yInches, float* yAbsPosition = 0);
    void yOff();
    void yOn();
    void yHome();

    void letterGo(float goDegree, float goalDegree=0);
    void letterOff();
    void letterOn();

    void stamp();
    void stampMotorOn();
    void stampMotorOff();

    void warmUp();

    void changeAccelLetter(int accel);
    void changeVelocityLetter(int velo);
    void changeMicrosteps(int msteps);
    

  private:
};

#endif
