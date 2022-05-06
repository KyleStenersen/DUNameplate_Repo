// WORK WITH SERIAL INPUT

// Some of this library adapted from here: https://forum.arduino.cc/t/serial-input-basics-updated/382007/3

// PUBLIC FUNCTIONS:
// grabInput() - which uses recWithEndMarkers() to return a pointer to an array of an incoming serial message
// inputSize() - simply returns the size of the array being used to hold incoming serial messages "numChars"
// emptySerial() - just reads serialbuffer until it is empty.
// PRIVATE FUNCTIONS:
// recWithStartEndMarkers() - adds serial input characters into an array "receivedChars" 1 by 1. Bounded by "<" and ">" start and end signals 

#include "SerialOps.h"

SerialOps::SerialOps(){}

const int NUM_CHARS = 91;
char receivedChars[NUM_CHARS];
boolean newData = false;


//PUBLIC FUNCTIONS========================================

char* SerialOps::grabInput() {  
    recvWithStartEndMarkers();
    if (newData == true) {          
        newData = false;                          
  return receivedChars;
    }
}


const int SerialOps::inputSize() {
    return NUM_CHARS;
}


void SerialOps::emptySerial(){
   while (Serial.available() > 0) {
    Serial.read();
    }    //clear input buffer  
}


//PRIVATE FUNCTIONS========================================

void SerialOps::recvWithStartEndMarkers() {   //result of this is receivedChars[] populated with input
    static boolean recvieveInProgress = false;
    static byte n = 0;
    char startMarker = '<';
    char endMarker = '>';
    char currentChar = 0;
    
    while (Serial.available() && newData == false) {
        currentChar = Serial.read();

        if (recvieveInProgress == true) {
            if (currentChar != endMarker) {
                receivedChars[n] = currentChar;
                n++;
                if (n >= NUM_CHARS) {
                    n = NUM_CHARS - 1;
                }
            }
            else {
                receivedChars[n] = '\0'; // terminate the string
                recvieveInProgress = false;
                n = 0;
                newData = true;
            }
        }

        else if (currentChar == startMarker) {
            recvieveInProgress = true;
        }
    }
}
