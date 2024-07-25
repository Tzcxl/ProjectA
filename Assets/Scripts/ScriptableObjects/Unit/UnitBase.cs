using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    [Serializable]
    [CreateAssetMenu(fileName = "Unit", menuName = "Config/Unit")]
    public class UnitBase : ScriptableObject
    {
        public string UnitName;
        public string LoreName;
        public UnitType UnitType;
        public List<UnitBase> CanEvolveTo;

        public UnitStats Stats;

        public bool BelongsToUser;
        public int CellRow = -1;
        public int CellColumn = -1;
        public Sprite Sprite;

        private void Awake()
        {
            Stats.SetStatsToDefault();
        }
    }
}
