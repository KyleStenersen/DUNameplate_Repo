// USED TO CHOOSE A MACHINE ACTION ACCORDING TO RECIEVED SERIAL MESSAGE

// - PUBLIC FUNCTIONS:
// chooseAction(const char* fullInputString)
//    ACTIONS: CHOSEN PER THE FIRST CHAR OF INPUT STRING "actionDefiner"
// (NOTE several of these are not used in standard machine function but only in manual testing by serial inputs
//  stars (*) indicate the ones that are for testing)
//    ‘a’ PRINTONE - parses out location info first, then sends plate text to - plates.printOne(rest of serial input string) - which prints one plate/tag per input
// *‘b’ LED - flip onboard LED on and off
// *‘c’ GOTOLETTER - plates.goToALetter(rest of serial input string [char]) - letter wheel
// *‘d’ SHOW SETTINGS - display GlobalSettings values by serial
// *‘e’ GET ANGLE - encoder.encoder.getAngle() - prints current encoder angle to serial monitor
// *‘f’ CHANGE ACCEL - motor.changeAccelerationLetter(rest of input string [int]) - letter motor
// *‘g’ CHANGE VEL - motor.changeVelocityLetter(rest of input string [int]) - letter motor
//    ‘h’ HOME - plates.xyHome() - build plate home
// *‘i’ CHANGE MS - motor.changeMicrosteps(rest of input string [int]) - for all motors
// *‘j’ LETTER DEGREE ADJUSTMENT - change adder to letter degree in plates go to letter to see effect
// *‘l’ LETTER DEGREES - plates.spinL(rest of input string [float]) - letterwheel move in degrees
//    ‘p’ CHANGE SETTINGS - update GlobalSettings sent over serial from GUI
// *‘s’ STAMP - plates.stampTest() - stamp machine motion once
// *‘x’ MOVE X - plates.spinX(rest of serial input string [float]) - move build plate in x by float inch value
// *‘y’ MOVE Y - plates.spinY(rest of serial input string [float]) - move build plate in y by float inch value


#include "InputResponse.h"

Plates platesIR;
SerialOps serialOpsIR;
Encoder encoderIR;
Motor motorIR;

InputResponse::InputResponse(){}


//PUBLIC FUNCTIONS================================================

void InputResponse::chooseAction(const char* fullInputString) 
{
  char actionDefiner = fullInputString[0];
  char actionInfo[serialOpsIR.inputSize()];
  strcpy(actionInfo, fullInputString+1);
  
  switch (actionDefiner)
  {
    case 'a':{  //PRINTONE
    char * stringTokenIndex;    //First parse out location info    
    
    stringTokenIndex = strtok(actionInfo,"^");
    X_ABS_PLATE_LOCATION_GLOBAL = atof(stringTokenIndex);  

    stringTokenIndex = strtok(NULL, "^");
    Y_ABS_PLATE_LOCATION_GLOBAL = atof(stringTokenIndex);

    stringTokenIndex = strtok(NULL, "^");
    strcpy(actionInfo, stringTokenIndex);

    Serial.println(actionInfo);
          
    platesIR.printOne(actionInfo);    //Then send remaining platetext to printOne function
    serialOpsIR.emptySerial();

    if (eStopBit == 1) break; //Don't send plate done signal if estopped.
            
    Serial.println("z1");   //Send "z" (signal) to GUI and "1" to say that a plate is done
    break;}
//--------------------------
    case 'b':{  // LED
    if (digitalRead(13)== HIGH)
    {
      digitalWrite(13,LOW);
    } 
    else
    {
      digitalWrite(13,HIGH);
    }
    break;}
//--------------------------
    case 'c':{  // GO LETTER   
    platesIR.goToALetter(actionInfo);
    serialOpsIR.emptySerial();
    break;}
//--------------------------
    case 'd':{  //SHOW SETTINGS
    Serial.println("...");
    Serial.print("X_OFFSET_GLOBAL = ");
    Serial.println(X_OFFSET_GLOBAL);
    Serial.print("Y_OFFSET_GLOBAL = ");
    Serial.println(Y_OFFSET_GLOBAL);
    Serial.print("X_ABS_PLATE_LOCATION_GLOBAL = ");
    Serial.println(X_ABS_PLATE_LOCATION_GLOBAL);
    Serial.print("Y_ABS_PLATE_LOCATION_GLOBAL = ");
    Serial.println(Y_ABS_PLATE_LOCATION_GLOBAL);    
    Serial.print("LINE_SPACEING_GLOBAL = ");
    Serial.println(LINE_SPACEING_GLOBAL);
    Serial.print("LETTER_SPACEING_GLOBAL = ");
    Serial.println(LETTER_SPACEING_GLOBAL);
    Serial.println("...");    
    break;}
//--------------------------//GET ANGLE
    case 'e':{  
    encoderIR.encoderSetup();
    Serial.println(encoderIR.getAngle());
    break;}
//--------------------------//CHANGE ACCEL
    case 'f':{  
    int acceleration = atoi(actionInfo);
    motorIR.changeAccelLetter(acceleration);
    serialOpsIR.emptySerial();
    Serial.print("UPDATED ACCEL_L = ");
    Serial.println(acceleration);    
    break;}
//--------------------------//CHANGE VEL
    case 'g':{  
    int velocity = atoi(actionInfo);
    motorIR.changeVelocityLetter(velocity);
    serialOpsIR.emptySerial();
    Serial.print("UPDATED VEL_L = ");
    Serial.println(velocity); 
    break;}
//--------------------------//HOME    
    case 'h':{  
    platesIR.xyHome();
    serialOpsIR.emptySerial();
    Serial.println("z3");
    break;}
//--------------------------//CHANGE MICROSTEPS
    case 'i':{
    int msteps = atoi(actionInfo);
    motorIR.changeMicrosteps(msteps);
    serialOpsIR.emptySerial();
    Serial.print("UPDATED MICRO = ");
    Serial.println(msteps);
    break;}
//--------------------------//LETTER DEGREE ADJUST   
    case 'j':{
    float adjustment = atof(actionInfo);
    platesIR.changeLetterDegreeAdjustment(adjustment);
    serialOpsIR.emptySerial();
    Serial.print("UPDATED LETTER DEGREE ADJUSTMENT= ");
    Serial.println(adjustment); 
    break;}
//--------------------------//CHECK IF OK TO RECEIVE
    case 'k':{
    Serial.print("__");
    break;
    }
//--------------------------//LETTER DEGREE
    case 'l':{
    float degreeL;
    degreeL = atof(actionInfo);
    platesIR.spinL(degreeL);
    serialOpsIR.emptySerial();
    break;}
//--------------------------//CHANGE SETTINGS
    case 'p':{    
    char * stringTokenIndex;
  
    stringTokenIndex = strtok(actionInfo,",");
    X_OFFSET_GLOBAL = atof(stringTokenIndex);  
 
    stringTokenIndex = strtok(NULL, ","); 
    Y_OFFSET_GLOBAL = atof(stringTokenIndex);    

    stringTokenIndex = strtok(NULL, ",");
    LINE_SPACEING_GLOBAL = atof(stringTokenIndex);

    stringTokenIndex = strtok(NULL, ",");
    LETTER_SPACEING_GLOBAL = atof(stringTokenIndex);
     
    serialOpsIR.emptySerial();
    break;}
//--------------------------//STAMP
    case 's':{  
    platesIR.stampTest();
    serialOpsIR.emptySerial();
    break;}
//--------------------------//X MOVE  
    case 'x':{
    float inchx;
    inchx = atof(actionInfo);
    platesIR.spinX(inchx);
    serialOpsIR.emptySerial();
    break;}
//--------------------------//Y MOVE
    case 'y':{
    float inchy;
    inchy = atof(actionInfo);
    platesIR.spinY(inchy);
    serialOpsIR.emptySerial();
    break;}
   
  }
}
