using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Код для поворота сегментами

public class Controller : MonoBehaviour
{

    public GameObject handler; // префаб хэндлера
    KeyCode button = KeyCode.A; // переменная хранения нажатой клавиши для выбора позии хэндлера (A - пустое значение)
    bool isRotate = false; // происходит ли вращение - инзначально нет

    void GenerateHandler(int pos) // создание хэндлера на одной из 9 позиций
    {
        if (GameObject.FindGameObjectWithTag("Handler") == true) // если уже есть хэндлер
        {
            return; // если он есть то ничего не делать
        }
        else // если хэндлера нет то начать его создание
        {
            print("хэндлер создается");
            Vector3 handlerPosition = new Vector3(); // переменная позиции хэндлера
            float handlerAngle = 0; // переменная угла вращения хэндлера
            Vector3 handlerAxis = new Vector3(); // переменная оси вращения хэндлера

            switch (pos) // задать позицию, согласно той стороне, где он будет вращаться
            {
                case 0: // сторона 0
                    handlerPosition = new Vector3(1.5f, 1f, 2.5f);
                    handlerAngle = 0;
                    handlerAxis = new Vector3(0f, 0f, 1f);
                    break;
                case 1: // сторона 1
                    handlerPosition = new Vector3(0f, 1f, 1f);
                    handlerAngle = 90;
                    handlerAxis = new Vector3(0f, 1f, 0f);
                    break;
                case 2: // сторона 2
                    handlerPosition = new Vector3(1.5f, 1f, -0.5f);
                    handlerAngle = 180;
                    handlerAxis = new Vector3(0f, 1f, 0f);
                    break;
                case 3:
                    handlerPosition = new Vector3(3f, 1f, 1f);
                    handlerAngle = 270;
                    handlerAxis = new Vector3(0f, 1f, 0f);
                    break;
                case 4:
                    handlerPosition = new Vector3(1.5f, 2.5f, 1f);
                    handlerAngle = 90;
                    handlerAxis = new Vector3(1f, 0f, 0f);
                    break;
                case 5:
                    handlerPosition = new Vector3(1.5f, -0.5f, 1f);
                    handlerAngle = 270;
                    handlerAxis = new Vector3(1f, 0f, 0f);
                    break;
                case 6:
                    handlerPosition = new Vector3(1.5f, 1f, 1f);
                    handlerAngle = 90;
                    handlerAxis = new Vector3(1f, 0f, 0f);
                    break;
                case 7:
                    handlerPosition = new Vector3(1.5f, 1f, 1f);
                    handlerAngle = 0;
                    handlerAxis = new Vector3(0f, 0f, 0f);
                    break;
                case 8:
                    handlerPosition = new Vector3(1.5f, 1f, 1f);
                    handlerAngle = 90;
                    handlerAxis = new Vector3(0f, 1f, 0f);
                    break;

                default:
                    handlerPosition = new Vector3(1.5f, 1f, 2.5f);
                    handlerAngle = 0;
                    handlerAxis = new Vector3(0f, 0f, 0f);
                    break;
            }
            // создание экземпляра хэндлера по заданным параметрам
            Instantiate(handler, handlerPosition, Quaternion.AngleAxis(handlerAngle,handlerAxis));
            print("Хэндлер создан");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // GUI работает с EVENT
    void OnGUI()
    {
        // если текущая кнопка А или совершается поворот, то не обрабатывать нажатия
        if (isRotate) { }

        else // если не А, то проверять нажатия
        {

            button = Event.current.keyCode; // получить нажатую кнопку
            // запустить проверку нажатой кнопки 
            switch (button)
            {
                case (KeyCode.Keypad0): // если нажата 0
                    print("Нажат 0"); //++
                    GenerateHandler(0); // то строить хэндлер на стороне 0
                    isRotate = true; // сигнал что поворот осуществляется
                    StartCoroutine(RotateHandler(0)); // запустить корутин поворота
                    break;
                case (KeyCode.Keypad1):
                    GenerateHandler(1);
                    isRotate = true;
                    StartCoroutine(RotateHandler(1));
                    break;
                case (KeyCode.Keypad2):
                    GenerateHandler(2);
                    isRotate = true;
                    StartCoroutine(RotateHandler(2));
                    break;
                case (KeyCode.Keypad3):
                    GenerateHandler(3);
                    isRotate = true;
                    StartCoroutine(RotateHandler(3));
                    break;
                case (KeyCode.Keypad4):
                    GenerateHandler(4);
                    isRotate = true;
                    StartCoroutine(RotateHandler(4));
                    break;
                case (KeyCode.Keypad5):
                    GenerateHandler(5);
                    isRotate = true;
                    StartCoroutine(RotateHandler(5));
                    break;
                case (KeyCode.Keypad6):
                    GenerateHandler(6);
                    isRotate = true;
                    StartCoroutine(RotateHandler(6));
                    break;
                case (KeyCode.Keypad7):
                    GenerateHandler(7);
                    isRotate = true;
                    StartCoroutine(RotateHandler(7));
                    break;
                case (KeyCode.Keypad8):
                    GenerateHandler(8);
                    isRotate = true;
                    StartCoroutine(RotateHandler(8));
                    break;
                default:
                    break;

            }
        }// перебор нажатых клавиш для задания позиции хэндлеру
        
        

    }


    IEnumerator RotateHandler(int axis) // поворот хэндлера по его номеру
    {
        
        for (int i = 0; i != 45; i++) // 45 кадров поворота на 2 градус за кадр
        {
            Vector3 hanlderAxisRotate = new Vector3(); // пустая переменная для хранения оси вращения
            // определение оси вращения по нажатой кнопке
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

            GameObject.FindGameObjectWithTag("Handler").transform.Rotate(hanlderAxisRotate, 2f); // поворот на 2 градуса каждый кадр
            yield return null; // сброс для покадрового просчета цикла
            
        } // по оконцчании анимации
        Destroy(GameObject.FindGameObjectWithTag("Handler")); // удалить хэндлер после поворота спутя малое время
        isRotate = false; // поворот прекращен


    }

}
