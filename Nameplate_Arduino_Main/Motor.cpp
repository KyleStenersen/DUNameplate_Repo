//LIBRARY FOR STEPPER MOTOR CONTROL FUNCTIONS
//----------------------------------------------
// Includes and adapts additional libraries to apply directly to Nameplate machine
// Specifically: TMCStepper.h (for controlling TMC motor drivers - TMC2209 in this case)
//          SpeedyStepper.h (for basic accelleration and decelleration movement of steppers)


#include "Motor.h"

//--- X definitions
const int X_LIMIT_SWITCH = 28;
#define DIR_PIN_X          23    
#define STEP_PIN_X         24    
#define ENABLE_PIN_X       26   
#define SERIAL_PORT_X Serial1     // Due pins (18 & 19)
#define DRIVER_ADDRESS_X 0b00     // TMC2209 Driver address according to MS1 and MS2
#define SENSE_RESISTOR_X 0.11f    // Match to your driver // SilentStepStick series use 0.11
int MOTOR_RMS_CURRENT_X = 950;    // Range: 0 to ~600mA for small original motors (Y & X motors) (TMCStepper.h)
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
int MOTOR_RMS_CURRENT_Y = 950;
TMC2209Stepper y_Driver(&SERIAL_PORT_Y, SENSE_RESISTOR_Y, DRIVER_ADDRESS_Y);
SpeedyStepper stepper_Y;

//--- Letter Wheel definitions
#define DIR_PIN_LETTER        60    
#define STEP_PIN_LETTER       61 
#define ENABLE_PIN_LETTER     62   
#define SERIAL_PORT_LETTER Serial3     // Due pins (14 & 15)
#define DRIVER_ADDRESS_LETTER 0b00   
#define SENSE_RESISTOR_LETTER 0.11f 
int MOTOR_RMS_CURRENT_LETTER = 1000;   
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
bool shaft = false;                               // ONLY NEEDED FOR CHANGING DIRECTION VIA UART, NO NEED FOR DIR PIN FOR THIS
int ACCEL_MULTIPLIER_XY = 1800;                   // Range:1(uber slow acceleration)-1600ish, acceleration, chosen by testing (~1500 max?)
int ACCEL_MULTIPLIER_LETTER = 1400; 
const int MICROSTEPS = 2;
const int RPM_TO_MICROSTEP_PER_SECOND_CONVERTER = (200/60);  //This is 200steps/rev over 60seconds  


// MOTORSTUFF.H LIBRARY SETUP AND CLASS INITIALIZATION
/////////////////////////////////////////////////////////////////////

Motor::Motor(){} // "Constructor" for Motor class

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

// MOTORSTUFF.H PUBLIC FUNCTIONS - To be used anywhere with motorStuff.h included
/////////////////////////////////////////////////////////////////////

// "Go" functions (relative motion) input desired speed and relative distance
//-------------------------------------------------------------------

void Motor::yGo(float yInches, float* yAbsPosition)
{
  *yAbsPosition = *yAbsPosition + yInches;
  int Y_RPM = 180;
  int MAGIC_Y_DISTANCE_CONVERTER =199;
  stepper_Y.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*MICROSTEPS);    // smaller=smoother, (example: 25000-16ms)
	y_Driver.microsteps(MICROSTEPS);                                                       // Microsteps Range: (1,2,4,8,16,32,64,128,256) TMC2209 says up to 64 but beyond is just interp. Speed limitations as go higher
	int yStepsPerSec = Y_RPM*MICROSTEPS*RPM_TO_MICROSTEP_PER_SECOND_CONVERTER;						 // Convert rpm to steps/sec for the speedystepper.h library to use it
	stepper_Y.setSpeedInStepsPerSecond(yStepsPerSec);
	float ySteps = yInches*MAGIC_Y_DISTANCE_CONVERTER*MICROSTEPS;      			                              
	stepper_Y.moveRelativeInSteps(ySteps);    
}

void Motor::xGo(float xInches, float* xAbsPosition) 
{
  *xAbsPosition = *xAbsPosition + xInches;
  xInches = -xInches;                                                             //This just adjustment so x is always positive from home 
  int X_RPM = 180;
  int MAGIC_X_DISTANCE_CONVERTER = 250;
  stepper_X.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_XY*MICROSTEPS);   
  x_Driver.microsteps(MICROSTEPS);                                                  
  int xStepsPerSec = X_RPM*MICROSTEPS*RPM_TO_MICROSTEP_PER_SECOND_CONVERTER;                                    
  stepper_X.setSpeedInStepsPerSecond(xStepsPerSec);
  float xSteps = xInches*MAGIC_X_DISTANCE_CONVERTER*MICROSTEPS;                                           
  stepper_X.moveRelativeInSteps(xSteps);      
}

void Motor::letterGo(float letterDeg) 
{
  int LETTER_RPM = 200;
  stepper_Letter.setAccelerationInStepsPerSecondPerSecond(ACCEL_MULTIPLIER_LETTER*MICROSTEPS);   
  letter_Driver.microsteps(MICROSTEPS);                                                  
  int letterStepsPerSec = LETTER_RPM*(MICROSTEPS*3.333336);                                    
  stepper_Letter.setSpeedInStepsPerSecond(letterStepsPerSec);
  float letterSteps = (letterDeg/360)*MICROSTEPS*200;                                           
  stepper_Letter.moveRelativeInSteps(letterSteps); 
}

// "ON/OFF" functions to allow turning of motors by hand
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
    digitalWrite(STAMP_CLUTCH_RELAY, RELAY_ON);
    delay(100);
    while (digitalRead(Z_STAMP_LIMIT_SWITCH)== Z_STAMPING){}
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
  letterGo(45);
  letterGo(-90);
  letterGo(180);
  xHome();
  yHome();
  xGo(1);
  yGo(1);
  xHome();
  yHome();
}
