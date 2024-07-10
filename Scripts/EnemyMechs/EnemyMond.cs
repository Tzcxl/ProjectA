using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMond : MonoBehaviour
{
    public Transform player; // ������ �� ������
    
    float moveSpeed = 3f;
    private void Update()
    {
        // ��������� ����������� � ������
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize(); // ����������� ������ �����������

        // ������� ������ � ����������� ������
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }
}
