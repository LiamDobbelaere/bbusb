#include <HX711.h>

#define LCA1_DOUT A1
#define LCA1_SCK A0
#define LCA2_DOUT A3
#define LCA2_SCK A2

#define CALIBRATION_TIME_MAX 5000

HX711 lca1;
HX711 lca2;

long calibration_time;

long lca1_calib;
long lca2_calib;
long center_calib;

bool confirmed_calib;
int calib_rounds;

void setup() {
  calibration_time = millis();
  confirmed_calib = false;
  
  // put your setup code here, to run once:
  lca1.begin(LCA1_DOUT, LCA1_SCK); //DOUT, SCK
  lca1.set_scale();

  lca2.begin(LCA2_DOUT, LCA2_SCK); //DOUT, SCK
  lca2.set_scale();

  Serial.begin(9600);
  Serial.println("bbusb");
}

void loop() {
  long right = lca1.read();
  long left = lca2.read();
  long center = right + left;

  if (millis() - calibration_time < CALIBRATION_TIME_MAX) {
    lca1_calib += right;
    lca2_calib += left;
    center_calib += center;
    calib_rounds++;

    Serial.print(".");
  } else {
    if (!confirmed_calib) {
      lca1_calib = lca1_calib / calib_rounds;
      lca2_calib = lca2_calib / calib_rounds;
      center_calib = center_calib / calib_rounds;

      Serial.println();
      Serial.print("c");
      Serial.print(lca1_calib);
      Serial.print(",");
      Serial.print(lca2_calib);
      Serial.print(",");
      Serial.print(center_calib);
      Serial.print(",");
      Serial.print(calib_rounds);
      Serial.println();
    
      confirmed_calib = true;
    }
    
    long right_v = max(0, right - lca1_calib);
    long left_v = abs(min(0, left - lca2_calib));
    long center_v = center - center_calib;
    
    Serial.print(right_v);
    Serial.print(",");
    Serial.print(left_v);
    Serial.print(",");
    Serial.print(center_v);
    Serial.println();
  }
}
