
//INCLUDED LIBRARIES AND FUNCTION PROTOTYPES --------------------------

#ifndef SerialOps_h
#define SerialOps_h

#include <Arduino.h>

class SerialOps {
  public:
    SerialOps();
    char* grabInput();
    void showInput();
    const int inputSize();
    void emptySerial();   
  
  private:
    void recvWithStartEndMarkers(); 
};

#endif
