// PLATE PRINTING FUNCTION AND A FEW OTHER MACHINE ACTIONS

// - PUBLIC FUNCTIONS:
// printOne(char* plateText) - recieves ref to text string to be indented on one tag and does it 
// xyHome() - homes the build plate and sets absolute xy positions to 0 (considering moving to motor.cpp)
// killAllMotors() - disables all the motors making them free to spin manually
// - PRIVATE FUNCTIONS:
// (NOTE several of these are not used in standard machine function but only in manual testing by serial inputs
// stars (*) indicate the ones that are for testing)
//    halfCurrentLine(int lineNumber) - pass in the #chars in a line and return the inch length of half of it
//    motorsOn_GoToPrintStart() - send the work table to the x center and y first line position of the first tag
// *stampTest() - stamp once
// *spinX(float xinch) - move worktable in x relative
// *spinY(float yinch) - move worktable in y relative
// *spinL(float lDeg) - move letterwheel relative degree
// *goToALetter(char* letter) - letterwheel


#include "Plates.h"

float yAbsolute = 0;
float xAbsolute = 0;
float* Y_ABS_POINTER = &yAbsolute;
float* X_ABS_POINTER = &xAbsolute;
float xPlateCenter;
float yRelativePlateLocation;
float xRelativePlateLocation;
int lineLengthArray[5];
int lineNum = 0;
int SWITCH_SIDE = -1;
int plateSide = 1;


#define SPACE_BAR 181
#define NEW_LINE 182


Motor motorP;
Text textP;
Encoder encoderP;

Plates::Plates(){}

//PUBLIC FUNCTIONS================================================================

void Plates::printOne(char* plateText)    //Primary function to increment through characters of a plate/tag and stamp/move for each one
{
  xyHome();

  char copyString[strlen(plateText)+1];   
  strcpy(copyString, plateText);
  
  textP.analyzeInputString(copyString, lineLengthArray);

  Serial.print("line length array: ");
  for (int counter = 0; counter<4; counter++)
  {
    Serial.print(lineLengthArray[counter]);
    Serial.print(",");
  }
  Serial.println("");

  plateSide = 1;      //reset, sign toggled for direction of indenting
  int i = 0;          //reset, counter that updates for each incoming character
  lineNum = 0;        //reset, counter that tracks current line of plate/tag
  xPlateCenter = X_OFFSET_GLOBAL + X_ABS_PLATE_LOCATION_GLOBAL;
  xRelativePlateLocation = (xPlateCenter - halfCurrentLine(lineNum)) - xAbsolute;
  yRelativePlateLocation = (Y_OFFSET_GLOBAL + Y_ABS_PLATE_LOCATION_GLOBAL) - yAbsolute;
  
  motorsOn_GoToPrintStart();
  
  while (i < strlen(plateText))   //loop through plate text chars responding to each individually (stamp or move)
  {
    Serial.println("BEGIN LOOP");
    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 
       
    float angleToMove = textP.relativeAngleFromLetter(plateText[i]);    //get angle to move per letter from text library
    float letterLocation = textP.angleOfLetterFromMap(plateText[i]);   //get destination angle from text.h

    if (lineNum > 3)    //increment and cycle back to start of while loop if there are too many lines for a plate/tag
    {
    Serial.println("ERROR : too many lines for one plate");
    i++;
    continue;
    }
      
    if (angleToMove == SPACE_BAR)   //if empty space, move one letterspace in x
    {
      motorP.xGo(plateSide*LETTER_SPACEING_GLOBAL, X_ABS_POINTER);
      i++;
      continue;
    }

    Serial.print("angleToMove =");
    Serial.println(angleToMove);
    if (angleToMove == NEW_LINE)    //if newline character "!" then move one linespace in y and then go to start of next line from center (direction depends on line #)
    {
      motorP.yGo(LINE_SPACEING_GLOBAL, Y_ABS_POINTER);   //move down a line in y
      lineNum++;
      
      float lineStart = xPlateCenter + (halfCurrentLine(lineNum) * plateSide);   //calc where to start next line in x
      
      Serial.print("lineStart = ");
      Serial.println(lineStart);
      float lineCurrent = xAbsolute;
      Serial.print("lineCurrent = ");
      Serial.println(lineCurrent);
      float moveToLineStart = lineStart - lineCurrent;
      Serial.print("moveToLineStart = ");
      Serial.println(moveToLineStart);      
      
      motorP.xGo(moveToLineStart, X_ABS_POINTER);   //move to start of next line in x
      
      plateSide = plateSide * SWITCH_SIDE;    //flip direction/side of print/plate for next line
      i++;
      continue;
    }
    
    if (angleToMove > 182 or angleToMove < -180)    //Error case where angle to move is out of possible bounds
    {
      Serial.print("ERROR... angleToMove = ");
      Serial.println(angleToMove);
      i++;
      continue;
    }

    encoderP.encoderSetup();
    Serial.print(" Destination = ");
    Serial.print(letterLocation);
    Serial.print(" - ");
    Serial.print(plateText[i]);
    Serial.print(" - angle to move = ");
    Serial.println(angleToMove);
    
    motorP.letterGo(angleToMove, letterLocation);   //Default go to current letter char, stamp, and move over one letterspace for next
    motorP.stamp();
    motorP.xGo((plateSide*LETTER_SPACEING_GLOBAL), X_ABS_POINTER);
    i++;
  } 

    Serial.println("END LOOP");
    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 

    killAllMotors();    //after all platetext is parsed/indented turn off motors.  
}

//---------------------

void Plates::xyHome()
{
  motorP.xOn();
  motorP.yOn();
  motorP.yHome();
  motorP.xHome();
  
  xAbsolute = 0;
  yAbsolute = 0; 
}

//---------------------

void Plates::killAllMotors(){
  motorP.stampMotorOff();
  motorP.xOff();
  motorP.yOff();
  motorP.letterOff();
}


//PRIVATE FUNCTIONS==============================================

float Plates::halfCurrentLine(int lineNumber)
{
  if (lineLengthArray[lineNumber] < 2) //case of 1 or zero letters dont move in x
  {
  return 0;
  }
  
  return (((lineLengthArray[lineNumber]-1) * LETTER_SPACEING_GLOBAL) / 2);   //minus 1 is because the machine moves a letterspace in x every letter so it does 1 extra unnecessary move after the last char per line.
}

//-------------------------

void Plates::motorsOn_GoToPrintStart()
{
  motorP.stampMotorOn();
  motorP.xOn();
  motorP.xGo(xRelativePlateLocation, X_ABS_POINTER);  
  motorP.yOn(); 
  motorP.yGo(yRelativePlateLocation, Y_ABS_POINTER); 
  motorP.letterOn();
}


//FUNCTIONS FOR TESTING/MANUAL CONTROL===========================

void Plates::stampTest()
{
  motorP.stampMotorOn();
  delay(500);
  motorP.stamp();
  motorP.stampMotorOff();
}

//-------------------------

void Plates::spinX(float xinch)   // move worktable in x relative
{
  motorP.xOn();
  motorP.xGo(xinch, X_ABS_POINTER);
  motorP.xOff();

  Serial.print("xAbsolute after spinX = ");
  Serial.println(xAbsolute);
}

//-------------------------

void Plates::spinY(float yinch)   // move worktable in y relative
{
  motorP.yOn();
  motorP.yGo(yinch, Y_ABS_POINTER); 
  motorP.yOff();
  Serial.print("yAbsolute after spinY = ");
  Serial.println(yAbsolute);
}

//-------------------------

void Plates::spinL(float lDeg)    // move letterwheel relative degree
{
  motorP.letterOn();
  motorP.letterGo(lDeg); 
  motorP.letterOff();
}

//-------------------------

void Plates::goToALetter(char* letter)   // letter-wheel
{
  motorP.letterOn();
  
  float angleToMove = textP.relativeAngleFromLetter(letter[0]);
  float letterLocation = textP.angleOfLetterFromMap(letter[0]);
  encoderP.encoderSetup();
  float angle1 = encoderP.getAngle();
  motorP.letterGo(angleToMove, letterLocation);
  float angle2 = encoderP.getAngle();
  float angleMoved = angle2 - angle1;
  float diff = angleMoved-angleToMove;
  if (diff>180 || diff<-180) diff = 360-abs(diff);

  Serial.print("angle1= ");
  Serial.print(angle1);
  Serial.print(" . angle2= ");
  Serial.print(angle2);  
  Serial.print(" . Destin= ");
  Serial.print(letterLocation);
  Serial.print(" for-> ");
  Serial.print(letter[0]);
  Serial.print(" . angleToMove = ");
  Serial.print(angleToMove);  
  Serial.print(" . angleMoved= ");
  Serial.print(angleMoved);
  Serial.print(" . diff= ");
  Serial.println(diff);

  motorP.letterOff();
}
