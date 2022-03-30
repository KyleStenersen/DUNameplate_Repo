#include "Plates.h"

float yAbsolute = 0;
float xAbsolute = 0;
float* Y_ABS_POINTER = &yAbsolute;
float* X_ABS_POINTER = &xAbsolute;
float X_CENTER_COLUMN_1 = 1.8;
int lineLengthArray[5];
int lineNum = 0;
float LETTER_SPACING = 0.11;
float LINE_SPACING = 0.14;
int SWITCH_SIDE = -1;
int plateSide = 1;


#define SPACE_BAR 181
#define NEW_LINE 182


Motor motorP;
Text textP;

Plates::Plates(){
  //letterWarmUpAndGo_W();
}

void Plates::printOne(char* plateText)
{
  textP.setupHashMap();
  textP.analyzeInputString(plateText, lineLengthArray);

  plateSide = 1;
  int i = 0;
  float xOffset1 = X_CENTER_COLUMN_1 - halfCurrentLine(lineNum);
  float yOffset1 = .6;
  
  motorP.stampMotorOn();
  motorP.xOn();
  motorP.xGo(xOffset1, X_ABS_POINTER);  
  motorP.yOn(); 
  motorP.yGo(yOffset1, Y_ABS_POINTER); 
  motorP.letterOn();
  
  while (i < strlen(plateText))
  {
    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 
       
    int angleToMove = textP.relativeAngleFromLetter(plateText[i]);
      
    if (angleToMove == SPACE_BAR) 
    {
      motorP.xGo(plateSide*LETTER_SPACING, X_ABS_POINTER);
      i++;
      continue;
    }
    if (angleToMove == NEW_LINE)
    {
      motorP.yGo(LINE_SPACING, Y_ABS_POINTER);
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
    motorP.xGo((plateSide*LETTER_SPACING), X_ABS_POINTER);
    i++;
  } 

    Serial.print("xAbsolute = ");
    Serial.println(xAbsolute);
    Serial.print("yAbsolute = ");
    Serial.println(yAbsolute); 
       
  
  motorP.xOff();
  motorP.yOff();
  motorP.letterOff();
  //-------
  motorP.stampMotorOff();
}


void Plates::goToALetter(char* letter)
{
  textP.setupHashMap();
  int angleToMove = textP.relativeAngleFromLetter(letter[0]);
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
  //motorP.stampMotorOff();
  motorP.xOff();
  motorP.yOff();
  motorP.letterOff();
}

//Private Functions-------------------

float Plates::halfCurrentLine(int lineNumber)
{
  return (((lineLengthArray[lineNumber]-1) * LETTER_SPACING) / 2);
}

//void Plates::letterWarmUpAndGo_W()
//{
//  motorP.letterOn();
//  motorP.letterGo(45);
//  motorP.letterGo(-90);
//  motorP.letterGo(180);
//  int angleToMove = textP.relativeAngleFromLetter('W');
//  motorP.letterGo(angleToMove);
//}
