using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GridManager : MonoBehaviour
{
    public List<GameObject> Cells = new List<GameObject>();
    public List<Image> cellsImage = new List<Image>();
    public List<Image> unitImage = new List<Image>();
    private List<GameObject> UnitPlaces = new List<GameObject>();
    private List<GameObject> AttackPlaces = new List<GameObject>();
    private List<GameObject> HPPlaces = new List<GameObject>();
    private List<GameObject> MnvrPlaces = new List<GameObject>();
    private List<GameObject> InitPlaces = new List<GameObject>();
    private List<TMP_Text> attackValue = new List<TMP_Text>();
    private List<TMP_Text> HPValue = new List<TMP_Text>();
    private List<TMP_Text> InitValue = new List<TMP_Text>();
    private List<TMP_Text> MnvrValue = new List<TMP_Text>();
    void Start()
    {
        InitiateCells();        
    }
    void InitiateCells()
    {
        CollectCellsByNames(CellsNames.Cells);
        GetImage(Cells, cellsImage);
        GetImage(UnitPlaces, unitImage);
        GetChild(Cells, "UnitPlace", UnitPlaces);
        GetChild(Cells, "AttackPlace", AttackPlaces);
        GetChild(Cells, "InitPlace", InitPlaces);
        GetChild(Cells, "HPPlace", HPPlaces);
        GetChild(Cells, "MnvrPlace", MnvrPlaces);
        GetText(AttackPlaces, attackValue, "AttackValue");
        GetText(InitPlaces, InitValue, "InitValue");
        GetText(HPPlaces, HPValue, "HPValue");
        GetText(MnvrPlaces, MnvrValue, "MnvrValue");
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
            imagePlaceList.Add(image);
        }
    }
    void GetText(List<GameObject> objectWithText,List<TMP_Text> textlist,string childName)
    {
        foreach (GameObject obj in objectWithText)
        {
            Transform parent = obj.transform;
            Transform child = parent.Find(childName);
            GameObject Child = child.gameObject;

            TMP_Text text = Child.GetComponent<TMP_Text>();
            
            textlist.Add(text);
        }
    }
}
