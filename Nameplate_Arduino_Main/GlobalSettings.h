// STORES GLOBAL MACHINE SETTINGS
 
// Updated in InputResponse.cpp (case p:) from the GUI 
// On startup and prior to every new printOne() command

#ifndef GlobalSettings_h
#define GlobalSettings_h

#include <Arduino.h>

extern float X_OFFSET_GLOBAL;
extern float Y_OFFSET_GLOBAL;
extern float X_ABS_PLATE_LOCATION_GLOBAL;
extern float Y_ABS_PLATE_LOCATION_GLOBAL;
extern float LINE_SPACEING_GLOBAL;
extern float LETTER_SPACEING_GLOBAL;
extern int STAMP_DELAY_GLOBAL;
extern bool eStopBit;

#endif
