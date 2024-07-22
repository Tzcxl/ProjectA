using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitConfig unitConfig;

    private float health;
    private float speed;
    public static int initiative;

    void Start()
    { 
            health = unitConfig.unitHP;
            speed = unitConfig.unitInitiative;
            initiative = unitConfig.unitDamage;
    }
}
