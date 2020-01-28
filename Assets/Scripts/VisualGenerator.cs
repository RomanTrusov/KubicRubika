using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Код генерации визуального отображения кубика рубика 
// Наслндуется от Cube
public class VisualGenerator : Cube
{

    public GameObject[] colorList; // массив хранения префабов с квадратами разных цветов

    void Start()
    {
        DrawSide(colorList, colorArray); // генерация куба
    }

    // Метод рисующий кубик из базы данных цветов 
    //(на входе список префабов с разноцветными квадратами и трехмерный массив с номерами цветов всего кубика)
    void DrawSide (GameObject[] colors, int[,,] data)
    {
        for (int s = 0; s <= 5; s++) // для каждой стороны
        {
            for (int i = 0; i <= 2; i++) // для каждой строки
            {
                for (int j = 0; j <= 2; j++) // для каждого столбца
                {
                    switch (s)
                    {
                        case 0: // Если генерируем сторону 0
                            // расположить его согласно цвету и его позиции 
                            //(выбираем префаб из массива colors по номеру стороны, которую сейчас генерируем)
                            Instantiate(colors[data[s, i, j]], new Vector3(0f, i, j), Quaternion.identity);
                            break;

                        case 1: // Если генерируем сторону 1
                            Instantiate(colors[data[s, i, j]], new Vector3(i + 0.5f, j, -0.5f), Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f)));
                            break;

                        case 2: // И так далее для каждой стороны
                            Instantiate(colors[data[s, i, j]], new Vector3(3f, i, j), Quaternion.identity);
                            break;

                        case 3:
                            Instantiate(colors[data[s, i, j]], new Vector3(i + 0.5f, j, 2.5f), Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f)));
                            break;

                        case 4:
                            Instantiate(colors[data[s, i, j]], new Vector3(i + 0.5f, 2.5f, j), Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f)));
                            break;

                        case 5:
                            Instantiate(colors[data[s, i, j]], new Vector3(i + 0.5f, -0.5f, j), Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f)));
                            break;
                    }
                    
                }
            }
        }
    }
}
