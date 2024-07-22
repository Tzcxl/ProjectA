using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;


public class GridManager : MonoBehaviour
{
    public List<GameObject> Cells = new List<GameObject>();
    public List<Image> cellsImage = new List<Image>();
    private List<GameObject> UnitPlace = new List<GameObject>();

    void Start()
    {
        CollectCellsByNames(CellsNames.Cells);
        GetChild(Cells, "UnitPlace", UnitPlace);
        GetImage(Cells, cellsImage);
        Debug.Log(cellsImage.Count);
    }

    void CollectCellsByNames(List<string> names)
    { 
        foreach (string name in names)
        {
            GameObject obj = GameObject.Find(name);
            Cells.Add(obj);
        }
    }
    void GetChild(List<GameObject> CellsList,string childName,List<GameObject> childList)
    {
        foreach(GameObject obj in CellsList) 
        {
            Transform parent = obj.transform;
            Transform child = parent.Find(childName);
            GameObject Child = child.gameObject;
            childList.Add(Child);
        }
    }
    void GetImage(List<GameObject> gameObjectsList,List<Image>imagePlaceList)
    {
        foreach(GameObject gameObject in gameObjectsList)
        {
            Image image = gameObject.GetComponent<Image>();
            image.color = Color.red;
            imagePlaceList.Add(image);
        }
    }
}
