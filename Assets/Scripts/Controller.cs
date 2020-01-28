using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Код для поворота квадратов (холдера) - он вращает все квадраты за собой

public class Controller : MonoBehaviour
{

    public GameObject holder; // переменная для хранения префаба холдера (используется для его инициации)
    KeyCode button; // переменная хранения нажатой клавиши для выбора позиции холдера
    bool isRotate = false; // происходит ли вращение холдера - инзначально нет

    // Метод создания холдера
    void GenerateHolder(int pos) // создание холдера на одной из 9 позиций
    {
        if (GameObject.FindGameObjectWithTag("Holder") == true) // если уже есть холдер
        {
            return; // если он есть то ничего не делать
        }
        else // если холдера нет то начать его создание
        {
            Vector3 holderPosition = new Vector3(); // переменная позиции холдера
            float holderAngle = 0; // переменная угла вращения холдера
            Vector3 holderAxis = new Vector3(); // переменная оси вращения холдера

            switch (pos) // задать позицию, согласно той стороне, на которой он будет вращаться
            {
                case 0: // сторона 0
                    holderPosition = new Vector3(1.5f, 1f, 2.5f); // позиция
                    holderAngle = 0; // угол поворота при инициации
                    holderAxis = new Vector3(0f, 0f, 1f); // ось вокруг которой необходимо повернуть холдер при инициации
                    break;
                case 1: // сторона 1
                    holderPosition = new Vector3(0f, 1f, 1f);
                    holderAngle = 90;
                    holderAxis = new Vector3(0f, 1f, 0f);
                    break;
                case 2: // сторона 2
                    holderPosition = new Vector3(1.5f, 1f, -0.5f);
                    holderAngle = 180;
                    holderAxis = new Vector3(0f, 1f, 0f);
                    break;
                case 3:
                    holderPosition = new Vector3(3f, 1f, 1f);
                    holderAngle = 270;
                    holderAxis = new Vector3(0f, 1f, 0f);
                    break;
                case 4:
                    holderPosition = new Vector3(1.5f, 2.5f, 1f);
                    holderAngle = 90;
                    holderAxis = new Vector3(1f, 0f, 0f);
                    break;
                case 5:
                    holderPosition = new Vector3(1.5f, -0.5f, 1f);
                    holderAngle = 270;
                    holderAxis = new Vector3(1f, 0f, 0f);
                    break;
                case 6:
                    holderPosition = new Vector3(1.5f, 1f, 1f);
                    holderAngle = 90;
                    holderAxis = new Vector3(1f, 0f, 0f);
                    break;
                case 7:
                    holderPosition = new Vector3(1.5f, 1f, 1f);
                    holderAngle = 0;
                    holderAxis = new Vector3(0f, 0f, 0f);
                    break;
                case 8:
                    holderPosition = new Vector3(1.5f, 1f, 1f);
                    holderAngle = 90;
                    holderAxis = new Vector3(0f, 1f, 0f);
                    break;

                default:
                    holderPosition = new Vector3(1.5f, 1f, 2.5f);
                    holderAngle = 0;
                    holderAxis = new Vector3(0f, 0f, 0f);
                    break;
            }
            // создание экземпляра холдера по заданным параметрам
            Instantiate(holder, holderPosition, Quaternion.AngleAxis(holderAngle,holderAxis));
        }
    }


    // GUI работает с EVENT, обработка нажатой клавиши и запуск генерации и вращения холдера
    void OnGUI()
    {
        // если совершается поворот, то не обрабатывать нажатия
        if (isRotate) { }

        else // если нет вращений, то проверять нажатия
        {
            button = Event.current.keyCode; // получить нажатую сейчас кнопку
            // запустить проверку нажатой кнопки 
            switch (button)
            {
                case (KeyCode.Keypad0): // если нажата 0
                    GenerateHolder(0); // то строить хэндлер на стороне 0
                    isRotate = true; // сигнал что поворот осуществляется
                    StartCoroutine(RotateHolder(0)); // запустить цикл (корутин) поворота
                    break;
                case (KeyCode.Keypad1):
                    GenerateHolder(1);
                    isRotate = true;
                    StartCoroutine(RotateHolder(1));
                    break;
                case (KeyCode.Keypad2):
                    GenerateHolder(2);
                    isRotate = true;
                    StartCoroutine(RotateHolder(2));
                    break;
                case (KeyCode.Keypad3):
                    GenerateHolder(3);
                    isRotate = true;
                    StartCoroutine(RotateHolder(3));
                    break;
                case (KeyCode.Keypad4):
                    GenerateHolder(4);
                    isRotate = true;
                    StartCoroutine(RotateHolder(4));
                    break;
                case (KeyCode.Keypad5):
                    GenerateHolder(5);
                    isRotate = true;
                    StartCoroutine(RotateHolder(5));
                    break;
                case (KeyCode.Keypad6):
                    GenerateHolder(6);
                    isRotate = true;
                    StartCoroutine(RotateHolder(6));
                    break;
                case (KeyCode.Keypad7):
                    GenerateHolder(7);
                    isRotate = true;
                    StartCoroutine(RotateHolder(7));
                    break;
                case (KeyCode.Keypad8):
                    GenerateHolder(8);
                    isRotate = true;
                    StartCoroutine(RotateHolder(8));
                    break;
                default: // Если нажата любая другая кнопка - ничего не делать
                    break;

            }
        }
        
        

    }

    // Вращение хэндлера (корутин)
    IEnumerator RotateHolder(int axis) // поворот холдера по оси, согласно его позиции (номеру его позиции)
    {
        for (int i = 0; i != 46; i++) // 46 кадров поворота на 2 градуса за кадр (один кадр лишний для доворота детей холдера)
        {
            Vector3 hanlderAxisRotate = new Vector3(); // пустая переменная для хранения оси вращения
            // определение оси вращения холдера по нажатой кнопке
            switch (axis)
            {
                case 0:
                    hanlderAxisRotate = new Vector3(0f, 0f, 1f);
                    break;
                case 1:
                    hanlderAxisRotate = new Vector3(0f, 0f, -1f);
                    break;
                case 2:
                    hanlderAxisRotate = new Vector3(0f, 0f, 1f);
                    break;
                case 3:
                    hanlderAxisRotate = new Vector3(0f, 0f, -1f);
                    break;
                case 4:
                    hanlderAxisRotate = new Vector3(0f, 0f, -1f);
                    break;
                case 5:
                    hanlderAxisRotate = new Vector3(0f, 0f, 1f);
                    break;
                case 6:
                    hanlderAxisRotate = new Vector3(0f, 0f, -1f);
                    break;
                case 7:
                    hanlderAxisRotate = new Vector3(0f, 0f, 1f);
                    break;
                case 8:
                    hanlderAxisRotate = new Vector3(0f, 0f, -1f);
                    break;
            } 

            GameObject.FindGameObjectWithTag("Holder").transform.Rotate(hanlderAxisRotate, 2f); // поворот на 2 градуса за каждый кадр
            yield return null; // сброс для покадрового просчета цикла
            
        } // по оконцчании анимации
        GameObject.FindGameObjectWithTag("Holder").transform.DetachChildren(); // удалить связь с детьми
        Destroy(GameObject.FindGameObjectWithTag("Holder")); // удалить холдер после поворота
        isRotate = false; // поворот прекращен (теперь будет учет нажатия кнопок)
    }

}
