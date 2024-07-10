using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour 
{
    public GameObject myGameObject;
    BaseStats Player = new();
    public new Rigidbody2D rigidbody;
    public float Speed;
    public float currentHealthPoint;
    public float HealthPoint;

    public void Start()
    {
        Speed = Player.Speed = 5f;
        currentHealthPoint = Player.currentHealthPoint = 0f;
        HealthPoint = Player.HealthPoint = 100f;
        Player.Damage = 5f;
        Player.CharName = "Player";
        rigidbody.GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        // Получаем ввод от пользователя
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Вычисляем вектор движения
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * Speed;
        // Применяем движение к Rigidbody2D
        rigidbody.velocity = movement;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            float DamageFromEnemy = 10f;// Урон от врага
            TakeDamage(DamageFromEnemy);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealthPoint -= damage;
        currentHealthPoint = Mathf.Max(currentHealthPoint, 0); // Ensure health doesn't go negative
        Debug.Log($"Player health: {currentHealthPoint}/{HealthPoint}");
    }
}
