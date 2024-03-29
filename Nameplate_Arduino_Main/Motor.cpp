// STEPPER MOTOR CONTROL FUNCTIONS

// Includes additional libraries to apply directly to Nameplate machine
// Specifically: TMCStepper.h (for controlling TMC motor drivers - TMC2209 in this case)
//               SpeedyStepper.h (for basic accelleration and decelleration movement of steppers)

// - PUBLIC FUNCTIONS:
// setupAll() - sets all motor pins and constant settings
// updateAll() - sets all variable motor settings (acceleration, microsteps, and velocity)
// yGo(float yInches, float* yAbsPosition) - relative move Y
// xGo(float xInches, float* xAbsPosition) - relative move X
// letterGo(float goDegree, float goalDegree) - relative move letterwheel
// xOff() - disable motor for free movement (same for others below)
// xOn() - enable motor for function (same for others below)
// yOff()
// yOn()
// letterOff()- letterwheel motor
// letterOn()- letterwheel motor
// stampMotorOn()
// stampMotorOff()
// stamp() - stamp once 
// xHome()
// yHome()
// warmUp() - move each motor a bit and rehome to avoid skipped steps on startup
// changeAccelLetter(int accel)
// changeVelocityLetter(int velo)
// changeMicrosteps(int msteps)


#include "Motor.h"

Encoder encoderM;
Estop estopM;

//--- X definitions
const int X_LIMIT_SWITCH = 28;
#define DIR_PIN_X          23    
#define STEP_PIN_X         24    
#define ENABLE_PIN_X       26   
#define SERIAL_PORT_X Serial1     // Due pins (18 & 19)
#define DRIVER_ADDRESS_X 0b00     // TMC2209 Driver address according to MS1 and MS2
#define SENSE_RESISTOR_X 0.11f    // Match to your driver // SilentStepStick series use 0.11
int MOTOR_RMS_CURRENT_X = 1300;    // Range: 0 to ~600mA for small original motors (Y & X motors) (TMCStepper.h)
TMC2209Stepper x_Driver(&SERIAL_PORT_X, SENSE_RESISTOR_X, DRIVER_ADDRESS_X);
SpeedyStepper stepper_X;

//--- Y definitions
const int Y_LIMIT_SWITCH = 30;
#define DIR_PIN_Y          53    
#define STEP_PIN_Y           51 
#define ENABLE_PIN_Y         49   
#define SERIAL_PORT_Y Serial2       // Due pins (16 & 17)
#define DRIVER_ADDRESS_Y 0b00   
#define SENSE_RESISTOR_Y 0.11f 
int MOTOR_RMS_CURRENT_Y = 1300;
TMC2209Stepper y_Driver(&SERIAL_PORT_Y, SENSE_RESISTOR_Y, DRIVER_ADDRESS_Y);
SpeedyStepper stepper_Y;

//--- Letter Wheel definitions
#define DIR_PIN_LETTER        60    
#define STEP_PIN_LETTER       61 
#define ENABLE_PIN_LETTER     62   
#define SERIAL_PORT_LETTER Serial3     // Due pins (14 & 15)
#define DRIVER_ADDRESS_LETTER 0b00   
#define SENSE_RESISTOR_LETTER 0.11f 
int MOTOR_RMS_CURRENT_LETTER = 1300;   
TMC2209Stepper letter_Driver(&SERIAL_PORT_LETTER, SENSE_RESISTOR_LETTER, DRIVER_ADDRESS_LETTER);
SpeedyStepper stepper_Letter;

//--- Z Stamp definitions
const int Z_STAMP_LIMIT_SWITCH = 32;      
const int STAMP_CLUTCH_RELAY = 36;
const int AC_MOTOR_RELAY = 34;
const int STAMP_DELAY = 150;     

//--- Switch state definitions
const char RELAY_ON = HIGH;
const char RELAY_OFF = LOW;
const char Z_STAMPING = LOW;

//--- General Motor definitions
int LETTER_RPM = 180;   //was 200
int Y_RPM = 180;    //was 180
int X_RPM = 180;    //was 180
int ACCEL_MULTIPLIER_XY = 1500;         // was 1500          // Range:1 = uber slow acceleration, chosen by testing (~1800 max? at 2 ms)
int ACCEL_MULTIPLIER_LETTER = 5800;               // 6000 max at 16ms?
int XY_MICROSTEPS = 32;    // was 2
int L_MICROSTEPS = 32;    // Was 2 but too slow
const int RPM_TO_MICROSTEP_PER_SECOND_CONVERTER = (200/60);  //This is 200steps/rev over 60seconds
int MAGIC_X_DISTANCE_CONVERTER = 250;
int MAGIC_Y_DISTANCE_CONVERTER =199;  


//PUBLIC FUNCTIONS================================================

Motor::Motor(){}

void Motor::setupAll()
{   
  pinMode(ENABLE_PIN_X, OUTPUT);
  digitalWrite(ENABLE_PIN_X, LOW);
  pinMode(ENABLE_PIN_Y, OUTPUT);
  digitalWrite(ENABLE_PIN_Y, LOW);
  pinMode(ENABLE_PIN_LETTER, OUTPUT);
  digitalWrite(ENABLE_PIN_LETTER, LOW);
  pinMode(STAMP_CLUTCH_RELAY, OUTPUT);
  digitalWrite(STAMP_CLUTCH_RELAY, RELAY_OFF);
  pinMode(AC_MOTOR_RELAY, OUTPUT);
  digitalWrite(AC_MOTOR_RELAY, RELAY_OFF);      
  pinMode(Y_LIMIT_SWITCH, INPUT_PULLUP);
  pinMode(X_LIMIT_SWITCH, INPUT_PULLUP);
  pinMode(Z_STAMP_LIMIT_SWITCH, INPUT);     
    
  stepper_X.connectToPins(STEP_PIN_X, DIR_PIN_X); // INITIALIZE (SpeedyStepper.h) 
  SERIAL_PORT_X.begin(115200);       // INITIALIZE UART TMC2209
  x_Driver.begin();                  // Initialize driver (TMCStepper.h)
  x_Driver.toff(4);                  // Enables driver in software (TMCStepper.h)
  x_Driver.rms_current(MOTOR_RMS_CURRENT_X);
  x_Driver.pwm_autoscale(true);      // Needed for stealthChop (TMCStepper.h) 
  x_Driver.TCOOLTHRS((3089838.00*pow(float((RPM_TO_MICROSTEP_PER_SECOND_CONVERTER*X_RPM)*XY_MICROSTEPS),-1.00161534))*1.5);        //was ~118, Essentially velocity threshold, stallguard because doesnt work during acceleration? from Valar_1000 Daniel Frenkel https://github.com/daniel-frenkel/Valar-Systems/blob/master/Devices/VAL-1000/VAL-1000-Window/Memory.h (3089838.00*pow(float(max_speed_steps_sec*64),-1.00161534))*1.5
  x_Driver.SGTHRS(30);              // 0-255, 0 doesn't stall, 255 would stall at the slightest touch or less. 
  
  stepper_Y.connectToPins(STEP_PIN_Y, DIR_PIN_Y); 
  SERIAL_PORT_Y.begin(115200);        
  y_Driver.begin();                  
  y_Driver.toff(4);                  
  y_Driver.rms_current(MOTOR_RMS_CURRENT_Y); 
  y_Driver.pwm_autoscale(true);          
  y_Driver.TCOOLTHRS((3089838.00*pow(float((RPM_TO_MICROSTEP_PER_SECOND_CONVERTER*Y_RPM)*XY_MICROSTEPS),-1.00161534))*1.5); 
  y_Driver.SGTHRS(30);

  stepper_Letter.connectToPins(STEP_PIN_LETTER, DIR_PIN_LETTER); 
  SERIAL_PORT_LETTER.begin(115200);        
  letter_Driver.begin();                  
  letter_Driver.toff(5);                  
  letter_Driver.rms_current(MOTOR_RMS_CURRENT_LETTER);
  letter_Driver.pwm_autoscale(true);  
}


//-------------------------------
void Motor::updateAll()
{
  stepper_Y.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*XY_MICROSTEPS);    // smaller=smoother, (example: 25000-16ms)
  y_Driver.microsteps(XY_MICROSTEPS);                                                       // Microsteps Range: (1,2,4,8,16,32,64,128,256) TMC2209 says up to 64 but beyond is just interp. Speed limitations as go higher
  int yStepsPerSec = Y_RPM*XY_MICROSTEPS*RPM_TO_MICROSTEP_PER_SECOND_CONVERTER;            // Convert rpm to steps/sec for the speedystepper.h library to use it
  stepper_Y.setSpeedInStepsPerSecond(yStepsPerSec);

  stepper_X.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*XY_MICROSTEPS);   
  x_Driver.microsteps(XY_MICROSTEPS);                                                  
  int xStepsPerSec = X_RPM*XY_MICROSTEPS*RPM_TO_MICROSTEP_PER_SECOND_CONVERTER;                                    
  stepper_X.setSpeedInStepsPerSecond(xStepsPerSec);

  stepper_Letter.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_LETTER*L_MICROSTEPS);   
  letter_Driver.microsteps(L_MICROSTEPS);                                                  
  int letterStepsPerSec = LETTER_RPM*(L_MICROSTEPS*3.333336);                                    
  stepper_Letter.setSpeedInStepsPerSecond(letterStepsPerSec);
} 




// "Go" functions (relative motion) (for x and y) input desired relative distance and reference to current absolute position if available
//                                  (for letterwheel) input desired relative degree and goal degree if available
//-----------------------------------------------------------------------------------------------


void Motor::setupXGoNonBlocking(float xInches, float* xAbsPosition) 
{
  *xAbsPosition = *xAbsPosition + xInches;

  if(*xAbsPosition < 0 || *xAbsPosition > 7.5) eStopBit = 1;                      //Quick check if we are telling it to go beyond it's limits.
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;

  float xSteps = xInches*MAGIC_X_DISTANCE_CONVERTER*XY_MICROSTEPS;                                           
  stepper_X.setupRelativeMoveInSteps(xSteps);      
}


//--------------------------
void Motor::yGo(float yInches, float* yAbsPosition)
{
  *yAbsPosition = *yAbsPosition + yInches;

  if(*yAbsPosition < 0 || *yAbsPosition > 5) eStopBit = 1;  //Quick check if we are telling it to go beyond it's limits.
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;

  float ySteps = yInches*MAGIC_Y_DISTANCE_CONVERTER*XY_MICROSTEPS;       			                              
	stepper_Y.moveRelativeInSteps(ySteps);    
}


//--------------------------
void Motor::setupYGoNonBlocking(float yInches, float* yAbsPosition)
{
  *yAbsPosition = *yAbsPosition + yInches;

  if(*yAbsPosition < 0 || *yAbsPosition > 5) eStopBit = 1;                       //Quick check if we are telling it to go beyond it's limits.
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;

  float ySteps = yInches*MAGIC_Y_DISTANCE_CONVERTER*XY_MICROSTEPS;                                       
  stepper_Y.setupRelativeMoveInSteps(ySteps);    
}


// "NON-BLOCKING LETTER GO"
//-------------------------------------------------------------------

int Motor::setupLetterGoNonBlocking(float goDegree) 
{
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return 0;
  
  float angleToMove = goDegree;
  
  encoderM.encoderSetup();
  float angle1 = encoderM.getAngle();
   
  float letterSteps = (goDegree/360)*L_MICROSTEPS*200;                                           
  stepper_Letter.setupRelativeMoveInSteps(letterSteps);

  return angle1;
}



//-------------------------------------------------------------------

void Motor::processRetries(float goDegree, float goalDegree, float angle1) 
{
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;
  
  float angleToMove = goDegree;
  
 // encoderM.encoderSetup(); 
                                             
  //int letterStepsPerSec = LETTER_RPM*(L_MICROSTEPS*3.333336);                                    
  float letterSteps = (goDegree/360)*L_MICROSTEPS*200;        

  float angle2 = encoderM.getAngle();
  
  float angleMoved = angle2 - angle1;
  
  float angleGoal = angleToMove + angle1;
  if (angleGoal>360) angleGoal-=360;
  if (angleGoal<-360) angleGoal+=360;
  if (goalDegree != 0) angleGoal = goalDegree;
 
  if (angleMoved > 180 || angleMoved < -180) 
  {
    angleMoved = (360 - abs(angleMoved));

    if (angleToMove<0) angleMoved = -1*angleMoved;
  }
  
  float angleError = abs(abs(angle2) - abs(angleGoal));

  if (angleGoal<angle2) angleError = -1*angleError;

// SERIAL FOR TESTING ------
//  Serial.print("First angle2 - ");
//  Serial.print(angle2);
//  Serial.print("First angleGoal - ");
//  Serial.print(angleGoal); 
//  Serial.print("First angleError ");
//  Serial.println(angleError);
//  --------

  //Crank the speed and accel way down to try additional tries make more accurate?
  int SLOW_LETTER_RPM = 150; 
  int SLOW_LETTER_ACCEL = 3000;
  int SHARPER_MICROSTEPS = 64;
  stepper_Letter.setAccelerationInStepsPerSecondPerSecond(SLOW_LETTER_ACCEL*L_MICROSTEPS);   
  letter_Driver.microsteps(SHARPER_MICROSTEPS);                                                  
  int letterStepsPerSec = SLOW_LETTER_RPM*(SHARPER_MICROSTEPS*3.333336);                                    
  stepper_Letter.setSpeedInStepsPerSecond(letterStepsPerSec);
  
   
  int tooManyTries = 0;
  while (angleError>0.15 || angleError<-0.15)   //Loop to retry and get closer to the target angle
  {     
    angle1 = encoderM.getAngle();
  
    angleToMove = angleError;
      
    letterSteps = (angleToMove/360)*SHARPER_MICROSTEPS*200;                                    
    stepper_Letter.moveRelativeInSteps(letterSteps);

    angle2 = encoderM.getAngle();
      
    angleMoved = angle2 - angle1;
   
    angleError = abs(abs(angle2) - abs(angleGoal));

// SERIAL FOR TESTING ---------
//    Serial.print("Retry, angle1 = ");
//    Serial.print(angle1);
//    Serial.print(", still go ");
//    Serial.print(angleToMove);
//    Serial.print(", angle2 = ");
//    Serial.print(angle2);
//    Serial.print(", went ");
//    Serial.print(angleMoved);
//    Serial.print(", angleError before = ");
//    Serial.print(angleError);
// ----------
    
    if(angleError>360 || angleError<-360)
    {
      angleError = (360- abs(angleError));
      
      if (angleToMove<0) angleError = -1*angleError;
    }
  
    if (angleGoal<angle2) angleError = -1*angleError;

// SERIAL FOR TESTING --------
//    Serial.print(", angleError = ");
//    Serial.println(angleError);
//--------------
  
    tooManyTries++;
    if (tooManyTries > 10) 
    {
      Serial.println("too Many tries, abort");
      return;  
    }
  }

  Serial.print(" Retries  ");
  Serial.println(tooManyTries);
  
  updateAll();
}



// "PROCESS SYNCHRONOUS MOVEMENTS"
//------------------------------------------  
void Motor::processXAndLetterMovement() 
{
  while(!stepper_Letter.motionComplete() || !stepper_X.motionComplete()) 
  {
    if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
    if (eStopBit == 1) return;
    stepper_Letter.processMovement();
    stepper_X.processMovement();
  }
}

//------------------------------------------
void Motor::processXAndYMovement() 
{
  while(!stepper_X.motionComplete() || !stepper_Y.motionComplete())
  {
    if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
    if(eStopBit == 1) return;
    
    stepper_X.processMovement();
    stepper_Y.processMovement();   
  } 
}

void Motor::processXAndYMovementForHome() 
{
  while(!stepper_X.motionComplete() || !stepper_Y.motionComplete())
  {
    if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
    if(eStopBit == 1) return;
    
    if (digitalRead(X_LIMIT_SWITCH) == LOW || digitalRead(Y_LIMIT_SWITCH) == LOW) {
      return;
    }
    
    stepper_X.processMovement();
    stepper_Y.processMovement();   
  } 
}



// "ON/OFF" functions to allow motors to turn by hand
//-------------------------------------------------------------------

void Motor::xOff()
{digitalWrite(ENABLE_PIN_X, HIGH);  }
void Motor::xOn()
{digitalWrite(ENABLE_PIN_X, LOW);  }

void Motor::yOff()
{digitalWrite(ENABLE_PIN_Y, HIGH);  }
void Motor::yOn()
{digitalWrite(ENABLE_PIN_Y, LOW);  }

void Motor::letterOff()
{digitalWrite(ENABLE_PIN_LETTER, HIGH);  }
void Motor::letterOn()
{digitalWrite(ENABLE_PIN_LETTER, LOW);  }

void Motor::stampMotorOn()
{digitalWrite(AC_MOTOR_RELAY, RELAY_ON);}
void Motor::stampMotorOff()
{digitalWrite(AC_MOTOR_RELAY, RELAY_OFF);} 



// "Z STAMP" function
//-------------------------------------------------------------------       

void Motor::stamp(){
    if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
    if (eStopBit == 1) return; 
      
    digitalWrite(STAMP_CLUTCH_RELAY, RELAY_ON);
    delay(STAMP_DELAY);
    
    int timer_1 = millis(); // Initiate timeout to check/abort if estop button has been pressed causing infinite loop here
    while (digitalRead(Z_STAMP_LIMIT_SWITCH)== Z_STAMPING)
    { 
      int timer_2 = millis();
      if ((timer_2 - timer_1)> (STAMP_DELAY+100)) eStopBit = 1;
      if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
      if (eStopBit == 1) break;
      Serial.println("in stamp");
    }
    
    digitalWrite(STAMP_CLUTCH_RELAY, RELAY_OFF);
    delay(10);   
}



// "HOME" functions
//------------------------------------------------------------------- 

void Motor::xHome()
{
  int maxSteps = (XY_MICROSTEPS * 50000);
  int homeSpeed = (XY_MICROSTEPS * 500);                                                                                   
  stepper_X.moveToHomeInSteps(-1,homeSpeed,maxSteps,X_LIMIT_SWITCH);
  updateAll();
}

void Motor::yHome()
{ 
  int maxSteps = (XY_MICROSTEPS * 10000);
  int homeSpeed = (XY_MICROSTEPS * 500);                                                                                  
  stepper_Y.moveToHomeInSteps(-1,homeSpeed,maxSteps,Y_LIMIT_SWITCH);
  updateAll();
}

void Motor::setupXYSyncGoAlmostHome(float xAbs, float yAbs)
{ 
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;

  float xSteps = -xAbs*0.99*MAGIC_X_DISTANCE_CONVERTER*XY_MICROSTEPS;                                           
  stepper_X.setupRelativeMoveInSteps(xSteps);
    
  float ySteps = -yAbs*0.99*MAGIC_Y_DISTANCE_CONVERTER*XY_MICROSTEPS;                                          
  stepper_Y.setupRelativeMoveInSteps(ySteps); 
}



// "WARMUP"
//------------------------------------------------------------------- 

void Motor::warmUp()
{
  letterOn();
  letterGo(180);
  xHome();
  yHome();
  xGo(.25);
  yGo(.25);
  xHome();
  yHome();
}



// CHANGE VALUES FOR TESTING
//------------------------------------------------------------------- 

void Motor::changeAccelLetter(int accel)
{
  ACCEL_MULTIPLIER_LETTER = accel;
  updateAll(); 
}


void Motor::changeVelocityLetter(int velo)
{
  LETTER_RPM = velo;
  updateAll(); 
}


void Motor::changeMicrosteps(int msteps)
{
  L_MICROSTEPS = msteps;
  updateAll(); 
}














///////////////////////////////////////////////////////////////////////////
// BLOCKING X AND LETTER MOVES KEPT FOR TESTING AND BACKWARDS COMPATABILITY
//--------------------------

void Motor::xGo(float xInches, float* xAbsPosition) 
{
//  Serial.print("xAbsPosition before: ");
//  Serial.println(*xAbsPosition);
  *xAbsPosition = *xAbsPosition + xInches;
//  Serial.print("xAbsPosition after: ");
//  Serial.println(*xAbsPosition);

  if(*xAbsPosition < 0 || *xAbsPosition > 7.5) eStopBit = 1;                      //Quick check if we are telling it to go beyond it's limits.
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;

  float xSteps = xInches*MAGIC_X_DISTANCE_CONVERTER*XY_MICROSTEPS;                                           
  stepper_X.moveRelativeInSteps(xSteps);      
}

//--------------------------

void Motor::letterGo(float goDegree, float goalDegree) 
{ 
  if(ESTOP_INTERRUPT_FLAG == 1) estopM.debounce();
  if(eStopBit == 1) return;
  
  float angleToMove = goDegree;
  
  //encoderM.encoderSetup();
  float angle1 = encoderM.getAngle();
   
  float letterSteps = (goDegree/360)*L_MICROSTEPS*200;                                           
  stepper_Letter.moveRelativeInSteps(letterSteps);

  float angle2 = encoderM.getAngle();
  
  float angleMoved = angle2 - angle1;
  
  float angleGoal = angleToMove + angle1;
  if (angleGoal>360) angleGoal-=360;
  if (angleGoal<-360) angleGoal+=360;
  if (goalDegree != 0) angleGoal = goalDegree;  
 
  if (angleMoved > 180 || angleMoved < -180) 
  {
    angleMoved = (360 - abs(angleMoved));

    if (angleToMove<0) angleMoved = -1*angleMoved;
  }
  
  float angleError = abs(abs(angle2) - abs(angleGoal));

  if (angleGoal<angle2) angleError = -1*angleError;


// SERIAL FOR TESTING --------------------
//  Serial.print("First angle2 - ");
//  Serial.print(angle2);
//  Serial.print("First angleGoal - ");
//  Serial.print(angleGoal);
//  Serial.print("First angleError ");
//  Serial.println(angleError);
//-----------------------------------------


  //Crank the speed and accel way down to try additional tries make more accurate?
  int SLOW_LETTER_RPM = 100; 
  int SLOW_LETTER_ACCEL = 2000;
  int SHARPER_MICROSTEPS = 64;
  stepper_Letter.setAccelerationInStepsPerSecondPerSecond(SLOW_LETTER_ACCEL*L_MICROSTEPS);   
  letter_Driver.microsteps(SHARPER_MICROSTEPS);                                                  
  int letterStepsPerSec = SLOW_LETTER_RPM*(SHARPER_MICROSTEPS*3.333336);                                    
  stepper_Letter.setSpeedInStepsPerSecond(letterStepsPerSec);
  
   
  int tooManyTries = 0;
  while (angleError>0.2 || angleError<-0.2)   //Loop to retry and get closer to the target angle
  {     
    angle1 = encoderM.getAngle();
    
    angleToMove = angleError;
      
    letterSteps = (angleToMove/360)*SHARPER_MICROSTEPS*200;                                    
    stepper_Letter.moveRelativeInSteps(letterSteps);

    angle2 = encoderM.getAngle();
     
    angleMoved = angle2 - angle1;
   
    angleError = abs(abs(angle2) - abs(angleGoal));

// SERIAL FOR TESTING ----------------------
//    Serial.print("Retry, angle1 = ");
//    Serial.print(angle1);
//    Serial.print(", still go ");
//    Serial.print(angleToMove);
//    Serial.print(", angle2 = ");
//    Serial.print(angle2);
//    Serial.print(", went ");
//    Serial.print(angleMoved);
//    Serial.print(", angleError before = ");
//    Serial.print(angleError);
// -----------------------------------------
    
    if(angleError>360 || angleError<-360)
    {
      angleError = (360- abs(angleError));
      
      if (angleToMove<0) angleError = -1*angleError;
    }
  
    if (angleGoal<angle2) angleError = -1*angleError;

// SERIAL FOR TESTING ----------------------
//    Serial.print(", angleError = ");
//    Serial.println(angleError);
// -----------------------------------------
    
    tooManyTries++;
    if (tooManyTries > 10) 
    {
      Serial.println("too Many tries, abort");
      return;  
    }
  }
  updateAll();
}
