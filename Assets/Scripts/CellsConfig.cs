using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Units.Base;


namespace Assets.Scripts
{
    public class CellsScript : MonoBehaviour
    {
        [field: SerializeField] public int Row { get; private set; }
        [field: SerializeField] public int Column { get; private set; }
        [field: SerializeField] public UnitBase Unit { get; set; }
        [field: SerializeField] public int AttackText { get; private set; }
        [field: SerializeField] public int HPText { get; private set; }
        [field: SerializeField] public int InitText { get; private set; }
        [field: SerializeField] public int MnvrText { get; private set; }

        //GetComponent<TMPro.TextMeshProUGUI>().text
        private void Start()
        {
           SubscribeToChanges();
        }
        public void SubscribeToChanges()
        {
            Unit.Stats.MaxHP.Subscribe();
        }

        private void HpChanged(int newHP)
        {
            //
        }

    }
}





