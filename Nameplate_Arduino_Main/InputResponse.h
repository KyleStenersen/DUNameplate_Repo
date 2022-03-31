
//INCLUDED LIBRARIES AND FUNCTION PROTOTYPES --------------------------

#ifndef InputResponse_h
#define InputResponse_h

#include <Arduino.h>
#include "Plates.h"
#include "SerialOps.h"
#include "Encoder.h"


class InputResponse {
  public:
    InputResponse();
    void chooseAction(const char*);  
  
  private:
};

#endif
