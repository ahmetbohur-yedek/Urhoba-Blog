int pin8 = 8; // Dijital pini belirliyoruz

void setup() {
  // Seri haberleşme başlatıyoruz
  Serial.begin(9600);
  // Pin modunu çıkış olarak belirliyoruz
  pinMode(pin8, OUTPUT); 
}

void loop() {
  // Seri bağlantı aktifmi kontrol ediyoruz
  if(Serial.available()){
    String serialData = Serial.readStringUntil('\r'); // Gelen mesajı okuyoruz  
    // Seri haberleşmeden gelen mesaj 8 ise 8 numaralı pini açıyoruz
    if(serialData == "8"){
      digitalWrite(pin8, HIGH); 
    }
    // Seri haberleşmeden gelen mesaj 16 ise 8 numaralı pini kapatıyoruz
    if(serialData == "16"){
    digitalWrite(pin8, LOW);
    }
  }
}
