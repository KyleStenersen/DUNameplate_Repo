#include "Text.h"

const byte HASH_SIZE = 45;

HashType<char,int> hashRawChar[HASH_SIZE];
HashMap<char,int> hashMap = HashMap<char,int>(hashRawChar,HASH_SIZE);

Text::Text(){}

void Text::setupHashMap(void)
{
  hashMap[0]('W',4);
  hashMap[1]('S',13);
  hashMap[2]('3',22);
  hashMap[3]('X',30);
  hashMap[4]('E',40);
  hashMap[5]('D',49);
  hashMap[6]('4',58);
  hashMap[7]('C',67);
  hashMap[8]('R',76);
  hashMap[9]('F',85);
  hashMap[10]('5',94);
  hashMap[11]('V',103);
  hashMap[12]('T',112);
  hashMap[13]('G',121);
  hashMap[14]('6',130);
  hashMap[15]('B',139);
  hashMap[16]('Y',148);
  hashMap[17]('H',157);
  hashMap[18](',',166);
  hashMap[19]('N',175);  
  hashMap[20]('7',184);
  hashMap[21]('J',193);
  hashMap[22]('U',202);
  hashMap[23]('M',211);
  hashMap[24]('8',220);
  hashMap[25]('K',229);
  hashMap[26]('I',238);
  hashMap[27]('#',247);
  hashMap[28]('9',256);
  hashMap[29]('L',265);
  hashMap[30]('0',274);
  hashMap[31]('.',283);
  hashMap[32]('P',292);
  hashMap[33]('-',301);
  hashMap[34]('1',310);
  hashMap[35]('/',319);
  hashMap[36]('Q',328);
  hashMap[37]('A',337);
  hashMap[38]('2',346);
  hashMap[39]('Z',355);

  hashMap[40]('O',274);
}


//Public Functions=========================================

Encoder encoderT;

int Text::relativeAngleFromLetter(char letter)
{
  if (letter == ' ')
  {
    return 181;
  }
  if (letter == '!')
  {
    return 182;
  }

  encoderT.encoderSetup();
  int nextAngle = angleOfLetter(letter);
  int currentAngle = encoderT.getAngle();

  int wayOneDeg = nextAngle - currentAngle;
  int wayTwoDeg = 360 - abs(wayOneDeg);
  
  int diffWayOne = abs(wayOneDeg);
  int diffWayTwo = abs(wayTwoDeg);


  if (diffWayOne < 6 or diffWayTwo < 6)
  {
    return 0; 
  }
  else if (diffWayOne < diffWayTwo)
  {
    return wayOneDeg;
  }
  else
  {
    return wayTwoDeg;
  }  
}


void Text::analyzeInputString(char* fullPlateString, int* lineLengthArr)
{
  char copyString[strlen(fullPlateString)];
  strcpy(copyString, fullPlateString);

  char* stringPiece = strtok(copyString,"!"); // this is used by strtok() as an index
  int i = 0;

  Serial.println("stringPieces = ");   
  while (stringPiece != NULL)
  {
    lineLengthArr[i] = strlen(stringPiece);
    Serial.println(lineLengthArr[i]);
    Serial.print(stringPiece);
    Serial.println("...");
    
    stringPiece = strtok(NULL,"!");      // get the first part - the string
    i++;
  }
}


//Private Functions========================================

int Text::angleOfLetter(char letter){
return hashMap.getValueOf(letter); 
}
