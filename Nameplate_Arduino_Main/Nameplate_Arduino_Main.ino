
// DOUBLE U HUNTING SUPPLY - NAMEPLATE MACHINE 
// ------------------------------------------------
// This file contains: 
// Some initial setup for machine components,
// the Main loop that just checks for updates to input, and
// the stallguard ISR that shuts the machine down if a motor stalls
// ------------------------------------------------
// Code constructed by Kingdom Automation (Kyle Stenersen) - started in 12/2022
// ------------------------------------------------
 
#include <Arduino.h>
#include "Plates.h"
#include "Motor.h"
#include "SerialOps.h"
#include "InputResponse.h"
#include "Encoder.h"

Motor motor;
Plates plates;
SerialOps serialOps;
InputResponse inputResponse;
Encoder encoder;


// -----------------
// CODE to setup SERIAL4 for barcode - (4th Serial port on DUE pins A11-TX and D52-RX)
// retrieved from https://forum.arduino.cc/t/arduino-due-txd3-rxd3-to-use-as-serial-ports/252083/6 
RingBuffer rx_buffer5, tx_buffer5;
USARTClass Serial4 (USART2, USART2_IRQn, ID_USART2, &rx_buffer5, &tx_buffer5);
// IT handlers
extern "C" void USART2_Handler(void)
{
  Serial4.IrqHandler();
}
// ------------------

void setup() {
  Serial.begin(115200);
  delay(100);
  pinMode(13, OUTPUT);
  digitalWrite(13,LOW);
  motor.motorSetupAll();
  encoder.encoderSetup();
  pinMode(10, INPUT);
  pinMode(21, INPUT);
 // attachInterrupt(10,stall,RISING);
 // attachInterrupt(21,stall,RISING);

  // ------------------
  // CODE for SERIAL4 (see note above setup)
  // Initialize USART pins for Serial4
  PIO_Configure(PIOB, PIO_PERIPH_A, PIO_PB20A_TXD2 | PIO_PB21A_RXD2, PIO_DEFAULT);
  Serial4.begin(115200);
  // ------------------
}

void loop() 
{
  if(Serial.available()) {     
    inputResponse.chooseAction(serialOps.grabInput());
  } 
}
     


//Stallgaurd Interrupt Service Routine
// ------------------------------------------------

void stall(){
  Serial.println(F("Killing"));
  plates.killAllMotors();
  serialOps.emptySerial();
}
