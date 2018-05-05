// MY PROJECT
#define soundPin1 13 // пищалка 1
#define trigPin1 10 // (дальномер 1) податся сигнал, который потом преобразуется и посылается
#define echoPin1 11 // (дальномер 1) куда посылается сигнал 
#define svet1 12 // светодиод 1
#define button1 9 // кнопка переключатель октав 1

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
int duration1, cm1; // нужны для считывания см

int currentOctave1 = 0; // октава в настоящий момент времени
int currentNote1 = -1; // нота в настоящий момент времени

String message; // сообщение 

void loop() {
  digitalWrite(trigPin1, LOW); // удаляем сигнал на 2млсек
  delayMicroseconds(2); 
  digitalWrite(trigPin1, HIGH); // принимаем 10млсек сигнал
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW); // убиарем после 10 млсек
  duration1 = pulseIn(echoPin1, HIGH); // палсиен снимает показания с эхопина (длина сигнала)
  cm1 = duration1 / 58; // получаем величину в см

  if (digitalRead(button1)) // меняем октаву по нажатию кнопки
        delay(50);
        if (digitalRead(button1)){
          if(currentOctave1 == 1)
            currentOctave1 = 0;
          else
            currentOctave1 = 1;
        }

  if(cm1 > 65 || cm1 < 0){
    noTone(soundPin1); // не звучит, если выходит за диапазон 
    digitalWrite(svet1, LOW); // свет не горит
    currentNote = -1; // никакая нота не играет
  }
  else{
      tone(soundPin, notes[currentOctave1][cm1 / 5]); // играет нота
      digitalWrite(svet, HIGH); // горит свет
      currentNote = cm1 / 5; // запоминаем ноту
    }

    message = "s1.currN." + (String)(cm1/5) + "." + butMessage + ".";
    Serial.println(message); // отправяем в форму строку с номером ноты 
  

  delay(100);
}



