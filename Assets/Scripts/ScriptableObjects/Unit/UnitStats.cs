using System;
using R3;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    [Serializable]
    public class UnitStats
    {
        //serializable for debug in unity inspector only
        public /*Serializable*/ReactiveProperty<int> HP;
        public /*Serializable*/ReactiveProperty<int> Attack;
        public /*Serializable*/ReactiveProperty<int> Initiative;
        public /*Serializable*/ReactiveProperty<int> ManeuversAmount;
        public /*Serializable*/ReactiveProperty<int> Level;
        public /*Serializable*/ReactiveProperty<int> Exp;

        public DefaultUnitStats DefaultUnitStats;

        public void SetStatsToDefault()
        {
            HP.Value = DefaultUnitStats.HP;
            Attack.Value = DefaultUnitStats.Attack;
            Initiative.Value = DefaultUnitStats.Initiative;
            ManeuversAmount.Value = DefaultUnitStats.ManeuversAmount;
        }
    }
}
