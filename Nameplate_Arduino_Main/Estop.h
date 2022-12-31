#ifndef Estop_h
#define Estop_h

#include <Arduino.h>
#include "GlobalSettings.h"

class Estop {
  public:
    Estop();
    void debounce();
};

#endif
