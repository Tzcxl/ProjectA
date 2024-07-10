using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDamage : MonoBehaviour 
{
    private BaseStats Enemy;
    public new Rigidbody2D rigidbody;
    public float Speed;
    public float currentHealthPoint;
    public float HealthPoint;
    public void Start()
    {
        Speed = Enemy.Speed = 5f;
        currentHealthPoint = Enemy.currentHealthPoint = 0f;
        HealthPoint = Enemy.HealthPoint = 100f;
        Enemy.Damage = 5f;
        Enemy.CharName = "Enemy";
        rigidbody.GetComponent<Rigidbody2D>();
    }
}





