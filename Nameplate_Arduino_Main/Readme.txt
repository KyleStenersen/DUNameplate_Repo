// README -

// DOUBLE U HUNTING SUPPLY - NAMEPLATE MACHINE
// ------------------------------------------------
// These programs are used to control an Automark ACEP Nameplate machine with an Arduino Due microcontroller
// ------------------------------------------------
// The machine is comprised of 4 axis motion: 
// -(3) 1.4A stepper motors for Xmotion & Ymotion of the work table, & rotation of the circular letter stamp wheel 
// -(3) BIGTREETECH TMC2209 SilentStepStick motor drivers for stepper control 
// -(1) AC gearmotor controlled by a solid state relay and clutch to engage momentarily and conduct the stamping Zmotion with a cam.
// -(3) hall effect sensors are used limits/home for X,Y,and Z.
// -(1) magnetic encoder is used to home the letter wheel rotation 