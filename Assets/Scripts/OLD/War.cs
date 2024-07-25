using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class War : MonoBehaviour
{
    public UnitConfig warConfig;

    public void Initialized()
    {
        warConfig = Resources.Load<UnitConfig>("WarConf");
        warConfig.unitHP = 10;
        warConfig.unitInitiative = 10;
        warConfig.unitDamage = 10;
        warConfig.unitMoves = 10;
    }
}
