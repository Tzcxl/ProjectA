using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // Цель для следования (например, игрок)
    public float smooth = 5.0f; // Сглаживание движения камеры
    public Vector3 offset = new Vector3(0, 2, -5); // Смещение камеры относительно цели

    private void LateUpdate()
    {
        // Интерполируем позицию камеры между текущей позицией и позицией цели
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
    }
}
