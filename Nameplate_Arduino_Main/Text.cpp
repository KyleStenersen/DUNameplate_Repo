// HANDLE THE STRINGS OF TAGTEXT SENT FROM GUI

// PUBLIC FUNCTIONS:
// setupHashMap() - stores hardcoded locations of each letter on letterwheel
// float relativeAngleFromLetter(char letter)
// analyzeInputString(char* fullPlateString, int* lineLengthArr) - pass in platetext string and get a reference to an array of the lengths of each line
// float angleOfLetterFromMap(char letter)



#include "Text.h"
Encoder encoderT;

const byte HASH_SIZE = 45;
HashType<char,float> hashRawChar[HASH_SIZE];
HashMap<char,float> hashMap = HashMap<char,float>(hashRawChar,HASH_SIZE);

Text::Text(){}

void Text::setupHashMap(void)
{
  //Adjustment: [(+) <--],[(-) -->)]... very roughly: 1deg = ~0.047" and 0.5deg = ~.028" 
hashMap[0]('W',69.5);
hashMap[1]('S',78.75);
hashMap[2]('3',87.9);
hashMap[3]('X',97);
hashMap[4]('E',105.95);
hashMap[5]('D',114.95);
hashMap[6]('4',123.5);
hashMap[7]('C',132.35);
hashMap[8]('R',141.2);
hashMap[9]('F',149.5);
hashMap[10]('5',158.5);
hashMap[11]('V',167);
hashMap[12]('T',175.75);
hashMap[13]('G',184.75);
hashMap[14]('6',194.1);
hashMap[15]('B',202.75);
hashMap[16]('Y',211.8);
hashMap[17]('H',221.2);
hashMap[18](',',230.65);
hashMap[19]('N',239.9);
hashMap[20]('7',249.25);
hashMap[21]('J',258.5);
hashMap[22]('U',267.5);
hashMap[23]('M',276.5);
hashMap[24]('8',285.6);
hashMap[25]('K',294.35);
hashMap[26]('I',303.25);
hashMap[27]('#',311.75);
hashMap[28]('9',320.6);
hashMap[29]('L',329.1);
hashMap[30]('0',338);
hashMap[31]('.',347.05);
hashMap[32]('P',355.75);
hashMap[33]('-',4.75);
hashMap[34]('1',13.9);
hashMap[35]('/',23.05);
hashMap[36]('Q',32.15);
hashMap[37]('A',41.3);
hashMap[38]('2',50.75);
hashMap[39]('Z',60.05);

hashMap[40]('O',338);
}

//--------------------------

float Text::relativeAngleFromLetter(char letter)
{
  if (letter == ' ')
  {
    return 200;
  }
  if (letter == '!')
  {
    return 202;
  }
  
  encoderT.encoderSetup();
  
  float nextAngle = angleOfLetterFromMap(letter);
  float currentAngle = encoderT.getAngle();

  float wayOneDeg = nextAngle - currentAngle;
  float oppositeSign = 1;
  if (wayOneDeg > 0) {oppositeSign = -1;}
  float wayTwoDeg = oppositeSign*(360 - abs(wayOneDeg));
  
  float absWayOne = abs(wayOneDeg);
  float absWayTwo = abs(wayTwoDeg);


  if (absWayOne < 1 or absWayTwo < 1)
  {
    return 0; 
  }
  if (absWayOne < 181)
  {
    return wayOneDeg;
  }
    return wayTwoDeg;  
}

//--------------------------

void Text::analyzeInputString(char* fullPlateString, int* lineLengthArr)    //pass in platetext string and get a reference to an array of the lengths of each line
{
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

//--------------------------

float Text::angleOfLetterFromMap(char letter){

  return hashMap.getValueOf(letter); 
}
