#include <SPI.h>

// rst=D3/ ss(sda)=D8/ sck=D5/ mosi=D7/ miso=D6
// WeMos D1(Retired)
// 변수 및 함수 지정 후 setup(), loop()문

#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN D8
#define RST_PIN D3
int soundM = D2;
 
MFRC522 rfid(SS_PIN, RST_PIN); // Instance of the class

MFRC522::MIFARE_Key key; 

// Init array that will store new NUID 
byte nuidPICC[4];

void setup() { 
  pinMode(soundM, OUTPUT);
  Serial.begin(9600);
  SPI.begin(); // Init SPI bus
  rfid.PCD_Init(); // Init MFRC522 

  for (byte i = 0; i < 6; i++) {
    key.keyByte[i] = 0xFF;
  }

  Serial.println(F("This code scan the MIFARE Classsic NUID."));
  Serial.print(F("Using the following key:"));
  Serial.println();
}
 
void loop() {

  // Look for new cards
  if ( ! rfid.PICC_IsNewCardPresent())
    return;

  // Verify if the NUID has been readed
  if ( ! rfid.PICC_ReadCardSerial())
    return;

  // Serial.print(F("PICC type: "));
  MFRC522::PICC_Type piccType = rfid.PICC_GetType(rfid.uid.sak);
  // Serial.println(rfid.PICC_GetTypeName(piccType));

  // Check is the PICC of Classic MIFARE type
  if (piccType != MFRC522::PICC_TYPE_MIFARE_MINI &&  
    piccType != MFRC522::PICC_TYPE_MIFARE_1K &&
    piccType != MFRC522::PICC_TYPE_MIFARE_4K) {
    Serial.println(F("Your tag is not of type MIFARE Classic."));
    return;
  }

  // if (rfid.uid.uidByte[0] != nuidPICC[0] || 
  //   rfid.uid.uidByte[1] != nuidPICC[1] || 
  //   rfid.uid.uidByte[2] != nuidPICC[2] || 
  //   rfid.uid.uidByte[3] != nuidPICC[3] ) {
  //   Serial.println(F("A new card has been detected."));

    // Store NUID into nuidPICC array
    for (byte i = 0; i < 4; i++) {
      nuidPICC[i] = rfid.uid.uidByte[i];
    }
   
    // Serial.print(F("The NUID tag is : "));
    String cardNumber = "";
    for (byte i = 0; i < rfid.uid.size; i++) {
      cardNumber += String(rfid.uid.uidByte[i] < 0x10 ? "0" : "");
      cardNumber += String(rfid.uid.uidByte[i], HEX);
    }

        // 카드 정보 출력
    printCardInfo(cardNumber);
    digitalWrite(soundM, HIGH);  // 디지털 출력으로 변경
    delay(100);
    digitalWrite(soundM, LOW);  // 디지털 출력으로 변경
    delay(100);
    digitalWrite(soundM, HIGH);  // 디지털 출력으로 변경
    delay(300);
    digitalWrite(soundM, LOW);  // 디지털 출력으로 변경

  // }
  // else Serial.println(F("Card read previously."));

  // Halt PICC
  rfid.PICC_HaltA();

  // Stop encryption on PCD
  rfid.PCD_StopCrypto1();
}

void printCardInfo(String cardNumber) {
  Serial.println(cardNumber);
}
