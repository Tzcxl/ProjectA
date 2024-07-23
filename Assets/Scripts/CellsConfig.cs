using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "CellsConfig", menuName = "Config/CellsConfig")]
[System.Serializable]
public class CellsConfig : ScriptableObject
{
    public TMP_Text AttackText; //=> Cellchelik.hp;
    public TMP_Text HPText;
    public TMP_Text InitText;
    public TMP_Text MnvrText;
}
public class Cell0 : PlayerUnits
{

    CellsConfig cell0 = new CellsConfig();
    PlayerUnits war = new PlayerUnits();

    private void Start()
    {
        war.ToStart();
        cell0.AttackText.text = war.unitDamage.ToString();
        cell0.HPText.text = war.unitHP.ToString();
        cell0.InitText.text = war.unitInitiative.ToString();
        cell0.MnvrText.text=war.unitMoves.ToString();
    }
    
}

