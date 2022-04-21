#include "Plates.h"

float yAbsolute = 0;
float xAbsolute = 0;
float* Y_ABS_POINTER = &yAbsolute;
float* X_ABS_POINTER = &xAbsolute;
float X_CENTER_COLUMN_1;
float Y_OFFSET_1;
float xOffset_1;
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

void Plates::printOne(char* plateText)    //Primary function to increment through chars of a plate/tag and stamp/move for each one
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
  X_CENTER_COLUMN_1 = X_OFFSET;
  xOffset_1 = X_CENTER_COLUMN_1 - halfCurrentLine(lineNum);    //starting position in x is half of the current plate line away from the center of the plate/tag
  Y_OFFSET_1 = Y_OFFSET;    //starting position in y
  
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
      motorP.xGo(plateSide*LETTER_SPACEING, X_ABS_POINTER);
      i++;
      continue;
    }

    Serial.print("angleToMove =");
    Serial.println(angleToMove);
    if (angleToMove == NEW_LINE)    //if newline character "!" then move one linespace in y and then go to start of next line from center (direction depends on line #)
    {
      motorP.yGo(LINE_SPACEING, Y_ABS_POINTER);   //move down a line in y
      lineNum++;
      
      float lineStart = X_CENTER_COLUMN_1 + (halfCurrentLine(lineNum) * plateSide);   //calc where to start next line in x
      
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
    motorP.xGo((plateSide*LETTER_SPACEING), X_ABS_POINTER);
    i++;
  } 

    Serial.println("END LOOP");
    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 

    killAllMotors();    //after all platetext is parsed/indented turn off motors.  
}


void Plates::goToALetter(char* letter)
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

void Plates::xyHome()
{
  motorP.xOn();
  motorP.yOn();
  motorP.yHome();
  motorP.xHome();
  
  xAbsolute = 0;
  yAbsolute = 0; 
}

void Plates::stampTest()
{
  motorP.stampMotorOn();
  delay(500);
  motorP.stamp();
  motorP.stampMotorOff();
}

void Plates::spinX(float xinch)
{
  motorP.xOn();
  motorP.xGo(xinch, X_ABS_POINTER);
  motorP.xOff();

  Serial.print("xAbsolute after spinX = ");
  Serial.println(xAbsolute);
}

void Plates::spinY(float yinch)
{
  motorP.yOn();
  motorP.yGo(yinch, Y_ABS_POINTER); 
  motorP.yOff();
  Serial.print("yAbsolute after spinY = ");
  Serial.println(yAbsolute);
}

void Plates::spinL(int lDeg)
{
  motorP.letterOn();
  motorP.letterGo(lDeg); 
  motorP.letterOff();
}

void Plates::killAllMotors(){
  motorP.stampMotorOff();
  motorP.xOff();
  motorP.yOff();
  motorP.letterOff();
}

void Plates::homeMachine(){
  xyHome();
}

//Private Functions-------------------

float Plates::halfCurrentLine(int lineNumber)
{
  if (lineLengthArray[lineNumber] < 2) //case of 1 or zero letters dont move in x
  {
  return 0;
  }
  
  return (((lineLengthArray[lineNumber]-1) * LETTER_SPACEING) / 2);   //minus 1 is because the machine moves a letterspace in x every letter so it does 1 extra unnecessary move after the last char per line.
}

void Plates::motorsOn_GoToPrintStart()
{
  motorP.stampMotorOn();
  motorP.xOn();
  motorP.xGo(xOffset_1, X_ABS_POINTER);  
  motorP.yOn(); 
  motorP.yGo(Y_OFFSET_1, Y_ABS_POINTER); 
  motorP.letterOn();
}
