using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject Enemyobject;
    public GameObject Bulletpref;
    public const float InvulnerabilityTime = 1f;

    private Weapon _weaponDamage = new Weapon();
    private GhostEnemy _enemy = new GhostEnemy();
    private SpriteRenderer _spriteRenderer;
    private Color _startColor;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startColor = _spriteRenderer.color;
        _weaponDamage.bulletStrength = 10f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet"))
        {
            return;
        }

        Bulletpref.GetComponent<GameObject>();
        // Применяем урон к врагу
        TakeDamage(_weaponDamage.bulletStrength);

        // Выключаем пулю
        Destroy(other.gameObject);
    }

    public void TakeDamage(float damage)
    {
        _enemy.CurrentHealthPoint -= damage;
        _enemy.CurrentHealthPoint = Mathf.Max(_enemy.CurrentHealthPoint, 0); // Ensure health doesn't go negative
        _spriteRenderer.color = new Color(255, 0, 0);
        Debug.Log(_enemy.CurrentHealthPoint);
        StartCoroutine(TakedamageTimer());
        if (_enemy.CurrentHealthPoint == 0)
        {
            Destroy(Enemyobject);
        }
    }

    private IEnumerator TakedamageTimer()
    {
        yield return new WaitForSeconds(InvulnerabilityTime);
        _spriteRenderer.color = _startColor;
    }
}

public class GhostEnemy : CharacterBase
{
    public GhostEnemy() : base(100)
    {
        Speed = 2.5f;
        Damage = 5f;
        CharName = "_enemy";
    }
}
