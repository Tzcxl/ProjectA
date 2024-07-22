using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    private List<Image> Cells = new List<Image>();
    private List<Image> UnitPlace = new List<Image>();
    // ������ ���� UI ���������, ������� �� ������ �����
    private List<string> imageNames = CellsNames.cellsName;

    void Start()
    {
        // ����� � ��������� ��� UI ����������� �� ������ � ������
        CollectImagesByNames(imageNames);
    }

    void CollectImagesByNames(List<string> names)
    {

        foreach (string name in names)
        {
            // ����� ������ �� �����
            GameObject obj = GameObject.Find(name);

            if (obj != null)
            {
                // �������� ��������� Image
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

        // ������� ���������� ��������� ����������� � �������
        Debug.Log($"Found {Cells.Count} images.");
    }
}
