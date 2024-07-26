using System;
using Assets._Scripts;
using MyBox;
using R3;

namespace Assets.Unit.Stats
{
    [Serializable]
    public class MagicCombatExtraStats
    {
        public MagicType MagicType;
        public bool CanHealAndBuff;

        [ConditionalField("CanHealAndBuff")] public HealerStats HealerExtraStats;

        [Serializable]
        public class HealerStats
        {
            public SerializableReactiveProperty<int> HealAmount;
            public SerializableReactiveProperty<int> AttckBuff;
            public SerializableReactiveProperty<int> DeffenceBuff;
            public SerializableReactiveProperty<int> InitiativeBuff;
            public SerializableReactiveProperty<int> ManeuversAmountBuff;
        }
    }

    [Serializable]
    public class RangedCombatExtraStats
    {
    }

    [Serializable]
    public class CloseCombatExtraStats
    {
    }
}
