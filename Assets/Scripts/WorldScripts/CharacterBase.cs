using UnityEngine;


[SerializeField]
public class CharacterBase
{
    public string CharName { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public float HealthPoint { get; set; }
    public float CurrentHealthPoint { get; set; }

    public CharacterBase(float maxHp)
    {
        HealthPoint = maxHp;
        CurrentHealthPoint = maxHp;
    }
}
