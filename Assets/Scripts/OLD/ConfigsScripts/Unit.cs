using UniRx;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public string LoreName;
    public int CurrentHP;
    public int Attack;
    public int Initiative;
    public int ManeuverAmount;
    public int Level;
    public int EXP;
    [field:SerializeField] public ReactiveProperty<int> HP { get; set; }
    [field: SerializeField] public ReactiveProperty<int> Init { get; set; }
}
