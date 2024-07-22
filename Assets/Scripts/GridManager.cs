using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    private List<Image> Cells = new List<Image>();
    private List<Image> UnitPlace = new List<Image>();
    // Массив имен UI элементов, которые вы хотите найти
    private List<string> imageNames = CellsNames.cellsName;

    void Start()
    {
        // Найти и сохранить все UI изображения по именам в списке
        CollectImagesByNames(imageNames);
    }

    void CollectImagesByNames(List<string> names)
    {

        foreach (string name in names)
        {
            // Найти объект по имени
            GameObject obj = GameObject.Find(name);

            if (obj != null)
            {
                // Получить компонент Image
                Image image = obj.GetComponent<Image>();

                if (image != null)
                {
                    Cells.Add(image);
                }
                else
                {
                    Debug.LogWarning($"Object '{name}' found but does not have an Image component.");
                }
            }
            else
            {
                Debug.LogWarning($"Object with name '{name}' not found.");
            }
        }

        // Вывести количество найденных изображений в консоль
        Debug.Log($"Found {Cells.Count} images.");
    }
}
