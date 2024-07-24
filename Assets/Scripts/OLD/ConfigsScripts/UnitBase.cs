using System;
using System.Collections.Generic;
using UnityEngine;
using static UserInterfaceGridLayout.FlexibleGridLayout;

namespace Assets.Scripts.Units.Base
{
    [Serializable]
    [CreateAssetMenu(fileName = "Unit", menuName = "Config/Unit")]
    public class UnitBase : ScriptableObject
    {
        public UnitType UnitType;
        public UnitStats Stats;
        public List<UnitBase> CanEvolveTo;

        public bool BelongsToUser;
        public int CellRow = -1;
        public int CellColumn = -1;
        public Texture2D CellSprite;
    }
}
