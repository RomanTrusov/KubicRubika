using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Код генерирует стандартную базу цветов для кубика
public class Cube : MonoBehaviour
{

    public int[,,] colorArray; // переменная для хранения всех цветов куба на текущий момент в трехмерном массиве


    void Awake()
    {
        colorArray = GenerateCube(); // генерация массивов куба
    }

    // Создадим трехмерный (6х3х3 сторон) массив, заполненный цифрами от 0 до 5, означающими определенный цвет кубика
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

}
