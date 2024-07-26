using System;
using UnityEngine;
using Assets.Unit.Stats;

namespace Assets.Unit
{
    [Serializable]
    public class UnitScript : MonoBehaviour
    {
        public string LoreName;
        [SerializeField] private UnitStats _defaultStats;
        [HideInInspector] public UnitStats Stats;

        private void Awake()
        {
            Stats = Instantiate(_defaultStats);
        }
    }
}
