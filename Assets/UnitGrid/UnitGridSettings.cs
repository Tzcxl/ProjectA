using UnityEngine;

namespace Assets.UnitGrid
{
    [CreateAssetMenu(fileName = "UnitGridSettings", menuName = "Settings/UnitGridSettings")]
    public class UnitGridSettings : ScriptableObject
    {
        [field: SerializeField] public int Rows { get; private set; }
        [field: SerializeField] public int Columns { get; private set; }
    }
}
