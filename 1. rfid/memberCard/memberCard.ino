// rst=D3/ ss(sda)=D8/ sck=D5/ mosi=D7/ miso=D6
// WeMos D1(Retired)
// 변수 및 함수 지정 후 setup(), loop()문

#include <SPI.h>
#include <MFRC522.h>
#include <ESP8266WiFi.h>

#define SS_PIN D8
#define RST_PIN D3
  int soundM = D2;

MFRC522 rfid(SS_PIN, RST_PIN); // MFRC522 인스턴스 생성
MFRC522::MIFARE_Key key;

const char* ssid = "KT_GiGA_3836";
const char* password = "";
const char* host = "www.poderoser.com";
int port = 80;

WiFiClient client; // WiFi 클라이언트

void connectWifi() {
  Serial.println("Connecting to WiFi...");
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.print(".");
  }
  Serial.println("\nConnected to WiFi");
}

void sendGetRequest(String url) {
  Serial.println("Sending GET request...");
  if (client.connect(host, port)) {
    //(루트)GET 방식, 끝에.php? 겟방식, 개행은 \r\n 주의
    client.print(String("GET /theme/company/dbgo/univLogs.php?") + url + " HTTP/1.1\r\n" +
                 "Host: " + host + "\r\n" +
                 "Connection: close\r\n\r\n");
    Serial.println("GET request sent");
  } else {
    Serial.println("Connection failed");
  }
}

void printCardInfo(String cardNumber) {
  Serial.print("Card Number: ");
  Serial.println(cardNumber);
}

void setup() {
  pinMode(soundM, OUTPUT);
  Serial.begin(9600);
  SPI.begin(); // SPI 버스 초기화
  rfid.PCD_Init(); // MFRC522 초기화
  connectWifi();

  for (byte i = 0; i < 6; i++) {
    key.keyByte[i] = 0xFF;
  }

  Serial.println(F("This code scans the MIFARE Classic NUID."));
  Serial.print(F("Using the following key: "));
  for (byte i = 0; i < MFRC522::MF_KEY_SIZE; i++) {
    Serial.print(key.keyByte[i] < 0x10 ? " 0" : " ");
    Serial.print(key.keyByte[i], HEX);
  }
  Serial.println();

  connectWifi();
}

void loop() {
  // 새로운 카드 확인
  if (!rfid.PICC_IsNewCardPresent())
    return;

  // NUID가 읽혀졌는지 확인
  if (!rfid.PICC_ReadCardSerial())
    return;

  Serial.print(F("PICC type: "));
  MFRC522::PICC_Type piccType = rfid.PICC_GetType(rfid.uid.sak);
  Serial.println(rfid.PICC_GetTypeName(piccType));

  // Classic MIFARE 타입인지 확인
  if (piccType != MFRC522::PICC_TYPE_MIFARE_MINI &&
      piccType != MFRC522::PICC_TYPE_MIFARE_1K &&
      piccType != MFRC522::PICC_TYPE_MIFARE_4K) {
    Serial.println(F("Your tag is not of type MIFARE Classic."));
    return;
  }

  if (rfid.uid.uidByte[0] != 0 ||
      rfid.uid.uidByte[1] != 0 ||
      rfid.uid.uidByte[2] != 0 ||
      rfid.uid.uidByte[3] != 0) {
    Serial.println(F("A new card has been detected."));

    // 카드의 NUID를 문자열로 변환
    String cardNumber = "";
    for (byte i = 0; i < rfid.uid.size; i++) {
      cardNumber += String(rfid.uid.uidByte[i] < 0x10 ? "0" : "");
      cardNumber += String(rfid.uid.uidByte[i], HEX);
    }

    // 카드 정보 출력
    printCardInfo(cardNumber);
    // GET 요청을 보내기 위한 URL 생성
    String url = "cardNumber=" + cardNumber;

    digitalWrite(soundM, HIGH);  // 디지털 출력으로 변경
    delay(100);
    digitalWrite(soundM, LOW);  // 디지털 출력으로 변경
    delay(100);
    digitalWrite(soundM, HIGH);  // 디지털 출력으로 변경
    delay(300);
    digitalWrite(soundM, LOW);  // 디지털 출력으로 변경

    // GET 요청 보내기
    sendGetRequest(url);

    Serial.println("Card number sent via GET request");

  } else {
    Serial.println(F("Card read previously."));
  }

  // PICC 정지
  rfid.PICC_HaltA();

  // PCD에서 암호화 중지
  rfid.PCD_StopCrypto1();

  // delay(2000); // 다음 카드 스캔을 위한 지연
}
