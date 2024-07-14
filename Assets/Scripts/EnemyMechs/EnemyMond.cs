using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMond : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    SpriteRenderer spriteRenderer;
    float moveSpeed =0.5f;
    private void Update()
    {
        // Вычисляем направление к игроку
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize(); // Нормализуем вектор направления

        
        // Двигаем объект в направлении игрока
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }
}
