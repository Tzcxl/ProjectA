using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsConfigData", menuName = "Config/UnitsConfigData")]

[System.Serializable]
public class UnitBase : ScriptableObject
{
    public List<UnitConfig> units;
}

