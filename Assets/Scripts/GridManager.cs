using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    private List<GameObject> Cells = new List<GameObject>();
    private List<GameObject> UnitPlace = new List<GameObject>();

    void Start()
    {
        Cells.Clear();    
        CollectImagesByNames(CellsNames.Cells);
        GetDaughter(Cells, "UnitPlace", UnitPlace);
    }

    void CollectImagesByNames(List<string> names)
    { 
        foreach (string name in names)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Cell");
            obj.name = name;
            Cells.Add(obj);
        }
    }
    void GetDaughter(List<GameObject> CellsList,string daughterName,List<GameObject> childList)
    {
        foreach(GameObject obj in CellsList) 
        {
            Transform parent = obj.transform;
            Transform child = parent.Find(daughterName);
            GameObject Child = child.gameObject;
            childList.Add(Child);
        }
    }
}
