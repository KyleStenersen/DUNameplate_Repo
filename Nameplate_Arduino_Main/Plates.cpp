#include "Plates.h"

float yAbsolute = 0;
float xAbsolute = 0;
float* Y_ABS_POINTER = &yAbsolute;
float* X_ABS_POINTER = &xAbsolute;
float X_CENTER_COLUMN_1 = X_OFFSET;
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

Plates::Plates(){}

void Plates::printOne(char* plateText)
{
  xyHome();
  textP.analyzeInputString(plateText, lineLengthArray);

  plateSide = 1;      //sign toggled for direction of indenting
  int i = 0;          //counter that updates for each incoming character
  xOffset_1 = X_CENTER_COLUMN_1 - halfCurrentLine(lineNum);    //starting position in x is half of the current tagline away from the center of the tag
  Y_OFFSET_1 = Y_OFFSET;    //starting position in y
  
  motorsOn_GoToPrintStart();
  
  while (i < strlen(plateText))
  {
    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 
       
    int angleToMove = textP.relativeAngleFromLetter(plateText[i]);
      
    if (angleToMove == SPACE_BAR) 
    {
      motorP.xGo(plateSide*LETTER_SPACEING, X_ABS_POINTER);
      i++;
      continue;
    }
    if (angleToMove == NEW_LINE)
    {
      motorP.yGo(LINE_SPACEING, Y_ABS_POINTER);
      lineNum++;
      
      float lineStart = X_CENTER_COLUMN_1 + (halfCurrentLine(lineNum) * plateSide);
      float lineCurrent = xAbsolute;
      float moveToLineStart = lineStart - lineCurrent;
      
      motorP.xGo(moveToLineStart, X_ABS_POINTER);
      plateSide = plateSide * SWITCH_SIDE;
      i++;
      continue;
    }
    if (angleToMove > 182 or angleToMove < -180) 
    {
      Serial.print("ERROR... angleToMove = ");
      Serial.println(angleToMove);
      continue;
    }
    
    motorP.letterGo(angleToMove);
    motorP.stamp();
    motorP.xGo((plateSide*LETTER_SPACEING), X_ABS_POINTER);
    i++;
  } 

    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 

    killAllMotors();   
}


void Plates::goToALetter(char* letter)
{
  int angleToMove = textP.relativeAngleFromLetter(letter[0]);
  Serial.print(" ... angleToMove = ");
  Serial.print(angleToMove);
  motorP.letterGo(angleToMove);
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
  letterWarmUpAndGo_W();
}

//Private Functions-------------------

float Plates::halfCurrentLine(int lineNumber)
{
  return (((lineLengthArray[lineNumber]-1) * LETTER_SPACEING) / 2);
}

void Plates::letterWarmUpAndGo_W()
{
  motorP.letterOn();
  motorP.letterGo(45);
  motorP.letterGo(-90);
  motorP.letterGo(180);
  goToALetter("W");
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
