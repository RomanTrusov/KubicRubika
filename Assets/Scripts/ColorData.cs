using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{

    int[,,] colorArray; // переменная для хранения всех цветов куба на текущий момент


    // Start is called before the first frame update
    void Start()
    {
        colorArray = GenerateCube(); // генерация массивов куба
    }

    // Создадим трехмерный (3х3х6 сторон) массив, заполненный цифрами от 0 до 5, означающими определенный цвет кубика
    int[,,] GenerateCube()
    {
        int[,,] colors = new int[6, 3, 3]; // массив для заполнения цветами
        for (int i = 0; i <= 5; i++) // каждая сторона куба
        {
            for (int j = 0; j <= 2; j++) // строка
            {
                for (int l = 0; l <= 2; l++) // столбец
                {
                    colors[i, j, l] = i; // Заполнить по очереди каждое значение строки и столбца каждой стороны своим цветом, соглсно номеру стороны
                }
            }
        }
        return colors; // вернуть на выходе заполненный массив
    }

    // всего два вида поворотов: поворот стороны (номер стороны и в какую сторону) и поворот центра (какая ось и в какую сторону)

    // Update is called once per frame
    void Update()
    {
        
    }
}
