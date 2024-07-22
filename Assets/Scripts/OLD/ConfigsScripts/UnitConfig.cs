using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "UnitConfigData", menuName = "Config/UnitConfigData")]

[System.Serializable]
public class UnitConfig : ScriptableObject
{
 
    public string unitName;
    public int unitDamage;
    public int unitInitiative;
    public int unitMoves;
    public int unitDefense;
    public int unitStartRowToPlace;
    public int unitHP;
    public VisualElement visualElement;
}

