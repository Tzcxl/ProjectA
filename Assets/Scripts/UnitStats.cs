using System;
using UnityEngine;

namespace Assets.Scripts.Units.Base
{
    [Serializable]
    public class UnitStats
    {
        public string LoreName;
        public int CurrentHP;
        public int Attack;
        public int Initiative;
        public int ManeuversAmount;
        public int Level;
        public int Exp;

       // [field: SerializeField] public ReactiveProperty<int> MaxHP { get; set; }

    }

   
}
