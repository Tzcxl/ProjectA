using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float bulletStrength { get; set; }
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    public float fireRate = 0.2f;
    protected float nextFireTime;
    public float bulletLifetime = 0.5f;

    private readonly List<(KeyCode, Vector2)> _keyCodeToVector = new List<(KeyCode, Vector2)>()
    {
        (KeyCode.UpArrow, Vector2.up),
        (KeyCode.DownArrow, Vector2.down),
        (KeyCode.LeftArrow, Vector2.left),
        (KeyCode.RightArrow, Vector2.right),
    };

    private void FixedUpdate()
    {
        if (Time.time < nextFireTime)
            return;

        foreach (var (key, vector) in _keyCodeToVector)
        {
            if (Input.GetKey(key))
            {
                Shoot(vector);
                return;
            }
        }
    }

    protected virtual void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
        nextFireTime = Time.time + fireRate;
        Destroy(bullet, bulletLifetime);
    }
}