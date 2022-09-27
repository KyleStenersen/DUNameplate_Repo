// STEPPER MOTOR CONTROL FUNCTIONS

// Includes additional libraries to apply directly to Nameplate machine
// Specifically: TMCStepper.h (for controlling TMC motor drivers - TMC2209 in this case)
//               SpeedyStepper.h (for basic accelleration and decelleration movement of steppers)

// - PUBLIC FUNCTIONS:
// motorSetupAll() - sets all motor settings
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

//--- Switch state definitions
const char RELAY_ON = HIGH;
const char RELAY_OFF = LOW;
const char Z_STAMPING = LOW;

//--- General Motor definitions
int LETTER_RPM = 200;
int Y_RPM = 180;
int X_RPM = 180;
int ACCEL_MULTIPLIER_XY = 1800;                   // Range:1(uber slow acceleration)-1600ish, acceleration, chosen by testing (~1500 max?)
int ACCEL_MULTIPLIER_LETTER = 1800;               // was 1400 max
int MICROSTEPS = 2;
const int RPM_TO_MICROSTEP_PER_SECOND_CONVERTER = (200/60);  //This is 200steps/rev over 60seconds  


//PUBLIC FUNCTIONS================================================

Motor::Motor(){}

void Motor::motorSetupAll()
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
  x_Driver.TCOOLTHRS(113);           // Essentially velocity threshold, stallguard because doesnt work during acceleration?
  x_Driver.SGTHRS(255);              // 0-255, 0 doesn't stall, 255 would stall at the slightest touch or less. 
  
  stepper_Y.connectToPins(STEP_PIN_Y, DIR_PIN_Y); 
  SERIAL_PORT_Y.begin(115200);        
  y_Driver.begin();                  
  y_Driver.toff(4);                  
  y_Driver.rms_current(MOTOR_RMS_CURRENT_Y); 
  y_Driver.pwm_autoscale(true);          
  y_Driver.TCOOLTHRS(113); 
  y_Driver.SGTHRS(255);

  stepper_Letter.connectToPins(STEP_PIN_LETTER, DIR_PIN_LETTER); 
  SERIAL_PORT_LETTER.begin(115200);        
  letter_Driver.begin();                  
  letter_Driver.toff(5);                  
  letter_Driver.rms_current(MOTOR_RMS_CURRENT_LETTER);
  letter_Driver.pwm_autoscale(true);        

}

// "Go" functions (relative motion) (for x and y) input desired relative distance and reference to current absolute position if available
//                                  (for letterwheel) input desired relative degree and goal degree if available
//-----------------------------------------------------------------------------------------------

void Motor::yGo(float yInches, float* yAbsPosition)
{
  *yAbsPosition = *yAbsPosition + yInches;

  int MAGIC_Y_DISTANCE_CONVERTER =199;
  stepper_Y.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*MICROSTEPS);    // smaller=smoother, (example: 25000-16ms)
	y_Driver.microsteps(MICROSTEPS);                                                       // Microsteps Range: (1,2,4,8,16,32,64,128,256) TMC2209 says up to 64 but beyond is just interp. Speed limitations as go higher
	int yStepsPerSec = Y_RPM*MICROSTEPS*RPM_TO_MICROSTEP_PER_SECOND_CONVERTER;						 // Convert rpm to steps/sec for the speedystepper.h library to use it
	stepper_Y.setSpeedInStepsPerSecond(yStepsPerSec);
	float ySteps = yInches*MAGIC_Y_DISTANCE_CONVERTER*MICROSTEPS;      			                              
	stepper_Y.moveRelativeInSteps(ySteps);    
}

//--------------------------

void Motor::xGo(float xInches, float* xAbsPosition) 
{
  *xAbsPosition = *xAbsPosition + xInches;
  xInches = -xInches;                                                             //This just adjustment so x is always positive from home 

  int MAGIC_X_DISTANCE_CONVERTER = 250;
  stepper_X.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*MICROSTEPS);   
  x_Driver.microsteps(MICROSTEPS);                                                  
  int xStepsPerSec = X_RPM*MICROSTEPS*RPM_TO_MICROSTEP_PER_SECOND_CONVERTER;                                    
  stepper_X.setSpeedInStepsPerSecond(xStepsPerSec);
  float xSteps = xInches*MAGIC_X_DISTANCE_CONVERTER*MICROSTEPS;                                           
  stepper_X.moveRelativeInSteps(xSteps);      
}

//--------------------------

void Motor::letterGo(float goDegree, float goalDegree) 
{
  float angleToMove = goDegree;
  
  encoderM.encoderSetup();
  float angle1 = encoderM.getAngle();
  
  stepper_Letter.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_LETTER*MICROSTEPS);   
  letter_Driver.microsteps(MICROSTEPS);                                                  
  int letterStepsPerSec = LETTER_RPM*(MICROSTEPS*3.333336);                                    
  stepper_Letter.setSpeedInStepsPerSecond(letterStepsPerSec);  
  float letterSteps = (goDegree/360)*MICROSTEPS*200;                                           
  stepper_Letter.moveRelativeInSteps(letterSteps);


  float angle2 = encoderM.getAngle();

  Serial.print("First angle2 - ");
  Serial.println(angle2);
  
  float angleMoved = angle2 - angle1;
  
  float angleGoal = angleToMove + angle1;
  if (angleGoal>360) angleGoal-=360;
  if (angleGoal<-360) angleGoal+=360;
  if (goalDegree != 0) angleGoal = goalDegree;

  Serial.print("First angleGoal - ");
  Serial.println(angleGoal);  
 
  if (angleMoved > 180 || angleMoved < -180) 
  {
    angleMoved = (360 - abs(angleMoved));

    if (angleToMove<0) angleMoved = -1*angleMoved;
  }
  
  float angleError = abs(abs(angle2) - abs(angleGoal));

  if (angleGoal<angle2) angleError = -1*angleError;

  Serial.print("First angleError ");
  Serial.println(angleError);


  //Crank the speed and accel way down to try additional tries make more accurate?
  int SLOW_LETTER_RPM = 250;    // by testing at 16ms ~max 300   
  int SLOW_LETTER_ACCEL = 1500;    // by testing at 16ms ~max 2000
  int SHARPER_MICROSTEPS = 32;
  stepper_Letter.setAccelerationInStepsPerSecondPerSecond(SLOW_LETTER_ACCEL*MICROSTEPS);   
  letter_Driver.microsteps(SHARPER_MICROSTEPS);                                                  
  letterStepsPerSec = SLOW_LETTER_RPM*(SHARPER_MICROSTEPS*3.333336);                                    
  stepper_Letter.setSpeedInStepsPerSecond(letterStepsPerSec);
  
   
  int tooManyTries = 0;
  while (angleError>0.2 || angleError<-0.2)   //Loop to retry and get closer to the target angle
  {     
    angle1 = encoderM.getAngle();

    Serial.print("Retry, angle1 = ");
    Serial.print(angle1);
    
    angleToMove = angleError;

    Serial.print(", still go ");
    Serial.print(angleToMove);
      
    letterSteps = (angleToMove/360)*SHARPER_MICROSTEPS*200;                                    
    stepper_Letter.moveRelativeInSteps(letterSteps);

    angle2 = encoderM.getAngle();

    Serial.print(", angle2 = ");
    Serial.print(angle2);
     
    angleMoved = angle2 - angle1;

    Serial.print(", went ");
    Serial.print(angleMoved);
   
    angleError = abs(abs(angle2) - abs(angleGoal));

    Serial.print(", angleError before = ");
    Serial.print(angleError);
    
    if(angleError>360 || angleError<-360)
    {
      angleError = (360- abs(angleError));
      
      if (angleToMove<0) angleError = -1*angleError;
    }
  
    if (angleGoal<angle2) angleError = -1*angleError;
    
    Serial.print(", angleError = ");
    Serial.println(angleError);
    
    tooManyTries++;
    if (tooManyTries > 10) 
    {
      Serial.println("too Many tries, abort");
      return;  
    }
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
    if (eStopBit == 1) exit; 
      
    digitalWrite(STAMP_CLUTCH_RELAY, RELAY_ON);
    delay(100);
    
    int timer_1 = millis(); // Initiate timeout to check/abort if estop button has been pressed causing infinite loop here
    while (digitalRead(Z_STAMP_LIMIT_SWITCH)== Z_STAMPING)
    { 
      int timer_2 = millis();
      if ((timer_2 - timer_1)> 100) eStopBit = 1;
      if (eStopBit == 1) break;
    }
    
    digitalWrite(STAMP_CLUTCH_RELAY, RELAY_OFF);
    delay(10);   
}

// "HOME" functions
//------------------------------------------------------------------- 

void Motor::xHome()
{
  stepper_X.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*MICROSTEPS);    
  x_Driver.microsteps(MICROSTEPS);                                                                                     
  stepper_X.moveToHomeInSteps(1,600,100000,X_LIMIT_SWITCH);
}

void Motor::yHome()
{
  stepper_Y.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*MICROSTEPS);    
  y_Driver.microsteps(MICROSTEPS);                                                                                     
  stepper_Y.moveToHomeInSteps(-1,600,20000,Y_LIMIT_SWITCH);
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
}


void Motor::changeVelocityLetter(int velo)
{
  LETTER_RPM = velo; 
}


void Motor::changeMicrosteps(int msteps)
{
  MICROSTEPS = msteps; 
}
