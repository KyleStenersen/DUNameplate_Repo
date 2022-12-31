#include "Estop.h"

Estop::Estop(){}



//PUBLIC FUNCTIONS========================================

void Estop::debounce() 
{
  Serial.println("bounced");
  delay(1);
  if (digitalRead(ESTOP_PIN) == LOW) eStopBit = 1;
  ESTOP_INTERRUPT_FLAG = 0;  
}
    
