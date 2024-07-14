using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour 
{
    public new Rigidbody2D rigidbody;
    PlayerCont Player = new PlayerCont();
    Enemy Enemy = new Enemy();
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public float invulnerabilityTime;
    private bool isInvulnerable = false;
    public Animator animator;
    public SpriteRenderer sprite;
    private bool isRunning;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        healthSlider.value = Player.currentHealthPoint / Player.HealthPoint;
        healthText.text = $"HP: {Player.currentHealthPoint}/{Player.HealthPoint}";
        Player.Speed = 1f;
        Player.HealthPoint = 100f;
        Player.currentHealthPoint = Player.HealthPoint;
        Player.Damage = 5f;
        Player.CharName = "Player";
        rigidbody.GetComponent<Rigidbody2D>();
        healthSlider.value = Player.currentHealthPoint / Player.HealthPoint;
        healthText.text = $"HP: {Player.currentHealthPoint}/{Player.HealthPoint}";
        Enemy.Damage = 5f;
    }
    public void FixedUpdate()
    {
        // Получаем ввод от пользователя
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Вычисляем вектор движения
        if (Mathf.Abs(horizontalInput) > 0)
        {
            isRunning = true;
            animator.SetFloat("Run", horizontalInput);
        }
        else
        {
            isRunning= false;
            animator.SetFloat("Run", horizontalInput);
        }
        if (horizontalInput > 0)
        {
            sprite.flipX = true;
        }
        else 
        {
            sprite.flipX = false;
        }
        animator.SetFloat("VerticalMove", verticalInput);
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * Player.Speed;
        // Применяем движение к Rigidbody2D
        rigidbody.velocity = movement;
        
       
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && !isInvulnerable)
        {
            Debug.Log("dam");// Урон от врага
            TakeDamage(Enemy.Damage);
            StartCoroutine(InvulnerabilityTimer());
        }
    }
    public void TakeDamage(float damage)
    {
        Player.currentHealthPoint -= damage;
        Player.currentHealthPoint = Mathf.Max(Player.currentHealthPoint, 0); // Ensure health doesn't go negative
        healthSlider.value = Player.currentHealthPoint / Player.HealthPoint;
        healthText.text = $"HP: {Player.currentHealthPoint}/{Player.HealthPoint}";
    }
    private IEnumerator InvulnerabilityTimer()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        isInvulnerable = false;
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
public class PlayerCont : BaseStats
{

}
public class Enemy : BaseStats
{

}
