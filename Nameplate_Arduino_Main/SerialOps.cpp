//USED TO WORK WITH SERIAL INPUT
//Some of this library adapted from here: https://forum.arduino.cc/t/serial-input-basics-updated/382007/3
//CURRENTLY 4 FUNCTIONS:
//grabInput() which uses recWithEndMarkers() to return a pointer to an array of an incoming serial message
//inputSize() simply returns the size of the array being used to hold incoming serial messages "numChars"
//emptySerial() just reads serialbuffer until it is empty.
//recWithStartEndMarkers() adds serial input characters into an array "receivedChars" 1 by 1. Bounded by "<" and ">" start and end signals 

#include "SerialOps.h"

SerialOps::SerialOps(){}

const int NUM_CHARS = 91;
char receivedChars[NUM_CHARS];
boolean newData = false;


//Public Functions===================================

char* SerialOps::grabInput() {  
    recvWithStartEndMarkers();
    if (newData == true) {          
        newData = false;                          
  return receivedChars;
    }
}

//============

const int SerialOps::inputSize() {
    return NUM_CHARS;
}

//============


void SerialOps::emptySerial(){
   while (Serial.available() > 0) {
    Serial.read();
    }    //clear input buffer  
}


//Private Functions====================================

void SerialOps::recvWithStartEndMarkers() {   //result of this is receivedChars[] populated with input
    static boolean recvInProgress = false;
    static byte ndx = 0;
    char startMarker = '<';
    char endMarker = '>';
    char rc = 0;
    while (Serial.available() && newData == false) {
        rc = Serial.read();

        if (recvInProgress == true) {
            if (rc != endMarker) {
                receivedChars[ndx] = rc;
                ndx++;
                if (ndx >= NUM_CHARS) {
                    ndx = NUM_CHARS - 1;
                }
            }
            else {
                receivedChars[ndx] = '\0'; // terminate the string
                recvInProgress = false;
                ndx = 0;
                newData = true;
            }
        }

        else if (rc == startMarker) {
            recvInProgress = true;
        }
    }
}