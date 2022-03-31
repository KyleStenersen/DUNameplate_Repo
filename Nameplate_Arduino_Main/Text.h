
//INCLUDED LIBRARIES AND FUNCTION PROTOTYPES --------------------------

#ifndef Text_h
#define Text_h

#include <Arduino.h>
#include <HashMap.h>
#include "Encoder.h"

class Text {
  public:
    Text();
    void setupHashMap();
    int relativeAngleFromLetter(char letter);
    void analyzeInputString(char* fullPlateString, int* lineLengthArr);
    
  private:
    int angleOfLetter(char letter);
    
};

#endif
