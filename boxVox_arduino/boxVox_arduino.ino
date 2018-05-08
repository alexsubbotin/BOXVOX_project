// MY PROJECT
#include <Thread.h>  // подключение библиотеки ArduinoThread
#include <Tone.h>
#define soundPin1 13 // пищалка 1
#define svet1 12 // светодиод 1
#define echoPin1 11 // (дальномер 1) куда посылается сигнал 
#define trigPin1 10 // (дальномер 1) податся сигнал, который потом преобразуется и посылается
#define button1 9 // кнопка переключатель октав 1

#define soundPin2 8 // пищалка 2
#define svet2 7 // светодиод 2
#define echoPin2 6 // (дальномер 2) куда посылается сигнал 
#define trigPin2 5 // (дальномер 2) податся сигнал, который потом преобразуется и посылается
#define button2 4 // кнопка переключатель октав 2

Tone tone1, tone2;


// массив частот нот
int notes[2][13] = {{261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 494, 523}, // первая октава
                    {523, 554, 587, 622, 659, 698, 740, 784, 830, 880, 932, 988, 523}}; // вторая октава

String notesNames[] = {"C", "C#", "D", "D#", "E", "F", "F#", "F", "G", "G#", "A", "B", "H", "C"}; // названия нот
int duration1, cm1, duration2, cm2; // нужны для считывания см

int currentOctave1 = 0; // октава в настоящий момент времени
int currentNote1 = -1; // нота в настоящий момент времени
int currentOctave2 = 1; // октава в настоящий момент времени
int currentNote2 = -1; // нота в настоящий момент времени

int del = 25;

String message; // сообщение 

Thread thread1 = Thread(); // создаём поток управления светодиодом
Thread thread2 = Thread(); // создаём поток управления сиреной

void setup() {
  pinMode(soundPin1, OUTPUT);
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  pinMode(button1, INPUT);
  pinMode(svet1, OUTPUT);

  pinMode(soundPin2, OUTPUT);
  pinMode(trigPin2, OUTPUT);
  pinMode(echoPin2, INPUT);
  pinMode(button2, INPUT);
  pinMode(svet2, OUTPUT);

  tone1.begin(soundPin1);
  tone2.begin(soundPin2);
  
  Serial.begin(9600);
}


void loop() {     
  if (digitalRead(button1)) // меняем октаву по нажатию кнопки
        delay(50);
        if (digitalRead(button1)){
          if(currentOctave1 == 1)
            currentOctave1 = 0;
          else
            currentOctave1 = 1;
        }

     
  if (digitalRead(button2)) // меняем октаву по нажатию кнопки
        delay(50);
        if (digitalRead(button2)){
          if(currentOctave2 == 1)
            currentOctave2 = 0;
          else
            currentOctave2 = 1;
        } 

          
  // ПЕРВАЯ РУКА
  digitalWrite(trigPin1, LOW); // удаляем сигнал на 2млсек
  delayMicroseconds(2); 
  digitalWrite(trigPin1, HIGH); // принимаем 10млсек сигнал
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW); // убиарем после 10 млсек
  //Serial.println("жду 1");
  duration1 = pulseIn(echoPin1, HIGH); // палсиен снимает показания с эхопина (длина сигнала)
  //Serial.println("принял 1");
  cm1 = duration1 / 58; // получаем величину в см


  if(cm1 > 65 || cm1 < 0){
    //noTone(soundPin1); // не звучит, если выходит за диапазон 
    tone1.stop();
    digitalWrite(svet1, LOW); // свет не горит
    currentNote1 = -1; // никакая нота не играет
  }
  else{
      //tone(soundPin1, notes[currentOctave1][cm1 / 5]); // играет нота
      tone1.play(notes[currentOctave1][cm1 / 5]);
      digitalWrite(svet1, HIGH); // горит свет
      currentNote1 = cm1 / 5; // запоминаем ноту
    }

  message = "1." + (String)currentNote1 + "." + (String)currentOctave1 + ".";
  Serial.println(message); // отправяем в форму
  //delay(del);

  // ВТОРАЯ РУКА
  digitalWrite(trigPin2, LOW); // удаляем сигнал на 2млсек
  delayMicroseconds(2); 
  digitalWrite(trigPin2, HIGH); // принимаем 10млсек сигнал
  delayMicroseconds(10);
  digitalWrite(trigPin2, LOW); // убиарем после 10 млсек
  //Serial.println("жду 2");
  duration2 = pulseIn(echoPin2, HIGH); // палсиен снимает показания с эхопина (длина сигнала)
  //Serial.println("принял 2");
  cm2 = duration2 / 58; // получаем величину в см



  if(cm2 > 65 || cm2 < 0){
    //noTone(soundPin2); // не звучит, если выходит за диапазон 
    tone2.stop();
    digitalWrite(svet2, LOW); // свет не горит
    currentNote2 = -1; // никакая нота не играет
  }
  else{
      //tone(soundPin2, notes[currentOctave2][cm2 / 5]); // играет нота
      tone2.play(notes[currentOctave2][cm2 / 5]);
      digitalWrite(svet2, HIGH); // горит свет
      currentNote2 = cm2 / 5; // запоминаем ноту
    }

  message = "2." + (String)currentNote2 + "." + (String)currentOctave2 + ".";
  Serial.println(message); // отправяем в форму
  delay(del*2);
}
