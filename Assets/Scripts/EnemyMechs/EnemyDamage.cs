using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDamage:MonoBehaviour
{
    public GameObject Enemyobject;
    public GameObject bulletpref;
    DamagefromWeapon WeaponDamage = new DamagefromWeapon();
    EnemyStats Enemy = new EnemyStats();
    private SpriteRenderer SpriteRenderer;
    private Color startColor;
    public float invulnerabilityTime = 1f;
    public void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        startColor = SpriteRenderer.color;
        WeaponDamage.bulletStrength = 10f;
        Enemy.Speed = 2.5f;
        Enemy.currentHealthPoint = 0f;
        Enemy.HealthPoint = 100f;
        Enemy.Damage = 5f;
        Enemy.CharName = "Enemy";
        Enemy.currentHealthPoint = Enemy.HealthPoint;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            bulletpref.GetComponent<GameObject>();
            // Применяем урон к врагу
            TakeDamage(WeaponDamage.bulletStrength);

            // Выключаем пулю
            Destroy(other.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        Enemy.currentHealthPoint -= damage;
        Enemy.currentHealthPoint = Mathf.Max(Enemy.currentHealthPoint, 0); // Ensure health doesn't go negative
        SpriteRenderer.color = new Color(255, 0, 0);
        Debug.Log(Enemy.currentHealthPoint);
        StartCoroutine(TakedamageTimer());
        if (Enemy.currentHealthPoint == 0)
        {
            Destroy(Enemyobject);
        }
        
    }


    
    private IEnumerator TakedamageTimer()
    {   
        yield return new WaitForSeconds(invulnerabilityTime);
        SpriteRenderer.color = startColor;
    }
}

public class DamagefromWeapon: Weapon
{
   
}
public class EnemyStats : BaseStats
{

}




