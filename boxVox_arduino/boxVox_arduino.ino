// MY PROJECT
#define soundPin 13 // пищалка
#define trigPin 10 // (дальномер) податся сигнал, который потом преобразуется и посылается
#define echoPin 11 // (дальномер) куда посылается сигнал 
#define svet 12 // светодиод
#define button 9 // кнопка переключатель октав

void setup() {
  pinMode(soundPin, OUTPUT);

  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);

  pinMode(button, INPUT);

  Serial.begin(9600);
}

// массив частот нот
int notes[2][13] = {{261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 494, 523}, // первая октава
                    {523, 554, 587, 622, 659, 698, 740, 784, 830, 880, 932, 988, 523}}; // вторая октава

String notesNames[] = {"C", "C#", "D", "D#", "E", "F", "F#", "F", "G", "G#", "A", "B", "H", "C"}; // названия нот
int duration, cm; // нужны для считывания см

//int oc1Duration = 0; // длина звучания ноты (в млсек)
long long current = 0;
int frequency = 0;

int currentOctave = 0; // октава в настоящий момент времени

String message; // сообщение 
String butMessage = "currOc.0"; // сообщение о перемене октавы

void loop() {
  digitalWrite(trigPin, LOW); // удаляем сигнал на 2млсек
  delayMicroseconds(2); 
  digitalWrite(trigPin, HIGH); // принимаем 10млсек сигнал
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW); // убиарем после 10 млсек
  duration = pulseIn(echoPin, HIGH); // палсиен снимает показания с эхопина (длина сигнала)
  cm = duration / 58; // получаем величину в см

  if(Serial.available()){
    //String message = Serial.readString();
    //Serial.println(message);

    //if(message[0]== '1') // первый датчик меняет частоту звучания нот
    //{
      frequency  = Serial.read();
    //}
  }

  if (digitalRead(button)) // меняем октаву по нажатию кнопки
        delay(50);
        if (digitalRead(button)){
          if(currentOctave == 1)
            currentOctave = 0;
          else
            currentOctave = 1;

          butMessage = "currOc." + (String)currentOctave;
        }

  if(cm > 65 || cm < 0){
    noTone(soundPin); // не звучит, если выходит за диапазон 
    digitalWrite(svet, LOW);
    Serial.println("_"); // отправляем в форму пустую строку
  }
  else{
    /*if(oc1Duration == 0){ // Если не задана длительность ноты
    tone(soundPin, notes[currentOctave][cm / 5]);
    digitalWrite(svet, HIGH);
    }
    else{ // если длительность ноты задана
      tone(soundPin, notes[currentOctave][cm / 5]);
      digitalWrite(svet, HIGH);
      delay(oc1Duration); // длительность звучания ноты
      noTone(soundPin);*/

      if(millis() - current >= frequency){
        tone(soundPin, notes[currentOctave][cm / 5]);
        digitalWrite(svet, HIGH);
        current = millis();
      }
      else
        noTone(soundPin);
    }

    message = "s1.currN." + (String)(cm/5) + "." + butMessage + ".";
    Serial.println(message); // отправяем в форму строку с номером ноты 
  

  delay(100);
}



