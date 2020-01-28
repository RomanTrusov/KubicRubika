using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Код генерации визкального отображения кубика рубика
public class VisualGenerator : Cube
{

    public GameObject[] colorList; // массив хранения префабов соответсвующих номеру цвета

    void Start()
    {
        colorArray = base.colorArray; // взять цвета для постройки визуала
        DrawSide(colorList, colorArray); // генерация куба
    }

    // Метод рисующий кубик из базы данных цветов
    void DrawSide (GameObject[] colors, int[,,] data)
    {

        for (int s = 0; s <= 5; s++) // для каждой стороны
        {
            for (int i = 0; i <= 2; i++) // для каждой строки
            {
                for (int j = 0; j <= 2; j++) // для каждого столбца
                {

                    // Сторона 0
                    if (s == 0)
                    {
                        Vector3 position = new Vector3(0f, i, j); // получить позицию одного сегмента стороны кубика
                        Instantiate(colors[data[s,i,j]], position, Quaternion.identity); // расположить его согласно цвету и его позиции
                    }

                    //Сторона 1
                    if (s == 1)
                    {
                        Vector3 position = new Vector3(i + 0.5f, j, -0.5f);
                        Instantiate(colors[data[s, i, j]], position, Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f)));
                    }

                    // Сторона 2
                    if (s == 2)
                    {
                        Vector3 position = new Vector3(3f, i, j);
                        Instantiate(colors[data[s, i, j]], position, Quaternion.identity);
                    }

                    // Сторона 3
                    if (s == 3)
                    {
                        Vector3 position = new Vector3(i + 0.5f, j, 2.5f);
                        Instantiate(colors[data[s, i, j]], position, Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f)));
                    }

                    // Сторона 4
                    if (s == 4)
                    {
                        Vector3 position = new Vector3(i + 0.5f, 2.5f, j);
                        Instantiate(colors[data[s, i, j]], position, Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f)));
                    }

                    // Сторона 5
                    if (s == 5)
                    {
                        Vector3 position = new Vector3(i + 0.5f, -0.5f, j);
                        Instantiate(colors[data[s, i, j]], position, Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f)));
                    }
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
