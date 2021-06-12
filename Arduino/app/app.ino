#include <ArduinoJson.h> //JSON Deserialize işlemi için kullandığım open source bir kütüphane
#include <LiquidCrystal.h> //lcd ekran
int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2; //lcd ekran ayarları
LiquidCrystal lcd(rs, en, d4, d5, d6, d7); //lcd ekran ayarları
int buzzerPin = 13; //buzzer pin tanımlama

String ssid = "FarukIOT"; //wifi ssid
String password = "*"; //wifi şifresi
bool isConnected = false; //internete bağlantı başarılı mı onu tutuyorum. Bu değer true olana kadar buzzer ötüyor

char json[] = "{\"id\":1,\"pin\":\"A0\",\"sensorName\":\"Isı Sensörü\",\"description\":\"Analog Okuma\"}";  //Web Sayfasında yapılan tanımlamanın JSON örneği
String UniqueKey = "ee2faf6a-98bd-4719-a9c1-331bb9166c60"; //Cihaza tanımladığım eşsiz anahtar
DynamicJsonDocument doc(1024); //Json Deserialize için bellekte alan ayırma işlemini yapan dinamik sınıfım

void setup()
{
  pinMode(buzzerPin, OUTPUT); //Buzzer tanımlaması
  lcd.begin(16, 2); //lcd ekranı başlatma
  lcd.clear(); //lcd ekran temizleme
  lcd.setCursor(0, 0); //lcd satır belirtme
  lcd.print("Omer Faruk"); //lcdye adımı yazma
  lcd.setCursor(0, 1); //lcd satır belirtme
  lcd.print("Sahin"); //lcd soyadımı yazma
  delay(2000); //uygulamayı 2 saniye bekletme
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Connecting");  
  //LCD ekranına internete bağlanılıyor yazma işlemi
  deserializeJson(doc, json); //JSON deserialize etme
  if (!startsWith(doc["pin"], "A")) { //Json içerisinde pin analog pin mi onu kontrol ediyorum
    pinMode(doc["pin"], INPUT); //Pin analog pin değilse bu pini INPUT olarak tanımlıyorum.
  }
  Serial.begin(9600); //Serial iletişim başlatıyorum 9600 rate ile
  digitalWrite(buzzerPin, HIGH); //Buzzer ötmesini sağlıyorum.
  //Buradan itibaren 
  Serial.println("Started");
    Serial.begin(115200);
    Serial.println("AT");
    Serial.println("AT Yollandı");
    while (!Serial.find("OK")) {
    Serial.println("AT");
    Serial.println("ESP8266 Bulunamadı.");
    }
    Serial.println("OK Komutu Alındı");
    Serial.println("AT+CWMODE=1");
    while (!Serial.find("OK")) {
    Serial.println("AT+CWMODE=1");
    Serial.println("Ayar Yapılıyor....");
    }
    Serial.println("Client olarak ayarlandı");
    Serial.println("Aga Baglaniliyor...");
    Serial.println("AT+CWJAP=\"" + ssid + "\",\"" + password + "\"");
    while (!Serial.find("OK"));
    Serial.println("Aga Baglandi.");
    //Buraya kadar kod gelebildiyse internet bağlanma işlemi başarılıdır.
    lcd.clear(); //lcd temizleme işlemi
    lcd.setCursor(0, 0); //lcd satır belirtme
    lcd.print("Connected"); //lcdye internete bağlanabildiğimi yazıyorum
    isConnected = true; //internete bağlanabildiğimi değişkene aktarıyorum    

}
void loop()
{
  if (isConnected) { //İnternete bağlı mı kontrol ediyorum.
    lcd.clear(); //lcd ekran temizleme
    digitalWrite(buzzerPin, LOW); //eğer internet bağlantısı varsa buzzer kapatıyorum 
    String sensor = doc["sensorName"]; //Sensörün adını okuyorum
    if (sensor == "Isı Sensörü") { //Eğer sensör lm35 ise buraya giriyor
      const char* pin = doc["pin"]; //Okuma yapılması gereken pini buluyorum
      int oku = analogRead(pin); //pin üzerinden analog read yapıyorum
      float gerilim = oku * 5.0;
      gerilim /= 1024.0;
      float sicaklik = (gerilim - 0.5) * 100 ;
      //lcd ekranı temizliyorum
      lcd.setCursor(0, 0);
      lcd.print("LM35 Sensoru");
      lcd.setCursor(0, 1);
      lcd.print(sicaklik);
      char snum[5]; //gelen değeri stringe dönüştürmek için kullanacağım
      //lcd ekrana sensörün adını ve sensörün değerini basıyorum
      sendData(itoa(sicaklik, snum, 10)); //sensör verisini signalr ile web sayfalarına yönlendirmesi için web isteği yapıyorum.itoa ile veriyi stringe dönüştürüyorum
    } else { //İnternete bağlı değilse tekrar buzzer öttürüyorum kullanıcı bağlantıda bir problem olduğunu farkedebilsin diye.
      digitalWrite(buzzerPin,HIGH);
    }
    delay(2500); //2.5 saniye uygulamayı uyutuyorum.
  }
}

void sendData(String data) {
  String ip = "192.168.2.216"; //Sunucumun local ipsi
  Serial.println("AT+CIPSTART=\"TCP\",\"" + ip + "\",80"); //sunucum ile haberleşmeye başlıyorum.
  if (Serial.find("Error")) {
    Serial.println("AT+CIPSTART Error");
  }
  String veri = "GET http://192.168.2.216/api/device/senddevicedata?uniqueKey="+UniqueKey; //192.168.2.216 sayfasına GET İsteği yapıyorum
  veri += "&deviceDetailId=1"; //sensör idsini veriyorum
  veri += "&data=" + data; //sensör datasını veriyorum
  veri += "\r\n\r\n";
  Serial.print("AT+CIPSEND="); 
  Serial.println(veri.length() + 2);
  delay(2000);
  if (Serial.find(">")) {
    Serial.println(veri);
    Serial.println("Veri gonderildi.");
    delay(1000);
  }
  Serial.println("Baglantı Kapatildi.");
  Serial.println("AT+CIPCLOSE");
  //sensör verisini web sunucusuna gönderdim.
}

bool startsWith(const char *pre, const char *str) //startsWith fonksiyonu hazır bir fonksiyondur. Bir text belirtilen karakter ile başlıyor mu diye kontrol ediyor.
{
  size_t lenpre = strlen(pre),
         lenstr = strlen(str);
  return lenstr < lenpre ? false : memcmp(pre, str, lenpre) == 0;
}
