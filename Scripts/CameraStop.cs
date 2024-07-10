using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    public Vector2 mapSize = new Vector2(10f, 10f); // Размер карты

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(mapSize.x, mapSize.y, 0f));
    }
}
