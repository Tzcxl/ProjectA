using UnityEngine;
using System.Collections.Generic;

public class PlayerUnits : UnitConfig
{
    War warToPlace = new War();
    public Dictionary<UnitConfig, string> unitInfo = new Dictionary<UnitConfig, string>();
    public void ToStart()
    {
        warToPlace.Initialized();
        Initilaze();
    }
    void Initilaze()
    {
        unitInfo.Add(warToPlace.warConfig, "Cell (0)");
    }
}
