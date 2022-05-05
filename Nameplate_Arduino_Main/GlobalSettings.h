// STORES GLOBAL MACHINE SETTINGS
 
// Updated in InputResponse.cpp (case p:) from the GUI 
// On startup and prior to every new printOne() command

#ifndef GlobalSettings_h
#define GlobalSettings_h

#include <Arduino.h>

extern float X_OFFSET;
extern float Y_OFFSET;
extern float NAMEPLATE_SPACEING;
extern float LINE_SPACEING;
extern float LETTER_SPACEING;

#endif
