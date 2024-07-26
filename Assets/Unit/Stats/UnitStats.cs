using System;
using System.Collections.Generic;
using Assets._Scripts;
using MyBox;
using R3;
using UnityEngine;

namespace Assets.Unit.Stats
{
    [Serializable]
    [CreateAssetMenu(fileName = "Unit", menuName = "Create/Unit")]
    public class UnitStats : ScriptableObject
    {
        [field: SerializeField] public string UnitName { get; private set; }

        public SerializableReactiveProperty<int> HP;
        public SerializableReactiveProperty<int> Attack;
        public SerializableReactiveProperty<int> Initiative;
        public SerializableReactiveProperty<int> ManeuversAmount;

        public List<UnitScript> CanEvolveTo;
        public Sprite Sprite;
        [HideInInspector]public int GridRow = -1;
        [HideInInspector] public int GridColumn = -1;

        public UnitCombatStyle UnitCombatStyle;

        [ConditionalField("UnitCombatStyle", compareValues: UnitCombatStyle.Close)]
        public CloseCombatExtraStats CloseCombatExtraStats;

        [ConditionalField("UnitCombatStyle", compareValues: UnitCombatStyle.Ranged)]
        public RangedCombatExtraStats RangedCombatExtraStats;

        [ConditionalField("UnitCombatStyle", compareValues: UnitCombatStyle.Magic)]
        public MagicCombatExtraStats MagicCombatExtraStats;
    }
}
