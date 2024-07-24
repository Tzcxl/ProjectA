using System;
using R3;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    [Serializable]
    public class UnitStats
    {
        public SerializableReactiveProperty<int> HP;
        public SerializableReactiveProperty<int> Attack;
        public SerializableReactiveProperty<int> Initiative;
        public SerializableReactiveProperty<int> ManeuversAmount;
        public SerializableReactiveProperty<int> Level;
        public SerializableReactiveProperty<int> Exp;

        public DefaultUnitStats DefaultUnitStats;
        public void ResetStats()
        {
            HP.Value = DefaultUnitStats.HP;
            Attack.Value = DefaultUnitStats.Attack;
            Initiative.Value = DefaultUnitStats.Initiative;
            ManeuversAmount.Value = DefaultUnitStats.ManeuversAmount;
        }
    }
}
