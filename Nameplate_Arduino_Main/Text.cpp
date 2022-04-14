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
  
  int nextAngle = angleOfLetterFromMap(letter);
  int currentAngle = encoderT.getAngle();

  int wayOneDeg = nextAngle - currentAngle;
  int oppositeSign = 1;
  if (wayOneDeg > 0) {oppositeSign = -1;}
  int wayTwoDeg = oppositeSign*(360 - abs(wayOneDeg));
  
  int absWayOne = abs(wayOneDeg);
  int absWayTwo = abs(wayTwoDeg);


  if (absWayOne < 8 or absWayTwo < 8)
  {
    return 0; 
  }
  if (absWayOne < 181)
  {
    return wayOneDeg;
  }
    return wayTwoDeg;  
}


void Text::analyzeInputString(char* fullPlateString, int* lineLengthArr)    //pass in platetext string and get a reference to an array of the lengths of each line
{
//  char* copyString;
//  copyString = strcpy(copyString, fullPlateString);    //make a copy to preserve the actual platetext string because strsep changes the string passed to it
  char** pointerCopyString;                            //strsep recieves a char** so must make pointer to copystring
  pointerCopyString = &fullPlateString;
  
  char* stringPiece;
  int i = 0;

  Serial.println("stringPieces = ");   
  while (stringPiece != NULL)   //loop assigning each "string piece" from strsep - "string seperate" to the array of line lengths
  {    
    stringPiece = strsep(pointerCopyString,"!");    //each time through the loop stringPiece is set equal to the next peice of copyString delimited by !
    
    lineLengthArr[i] = strlen(stringPiece);   //set each element of array equal to the length of the current stringpiece
    Serial.println(lineLengthArr[i]);
    Serial.print(stringPiece);
    Serial.println("...");
    
    i++;
  }
}


//Private Functions========================================

int Text::angleOfLetterFromMap(char letter){
return hashMap.getValueOf(letter); 
}
