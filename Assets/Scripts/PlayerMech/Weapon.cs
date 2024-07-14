using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float bulletStrength { get; set; }
    public GameObject Enemy;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
    public float bulletLifetime = 0.5f;
    public SpriteRenderer spritePlayer;


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Time.time >= nextFireTime)
        {
            Shoot(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Time.time >= nextFireTime)
        {
            Shoot(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time >= nextFireTime)
        {
            Shoot(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Time.time >= nextFireTime)
        {
            Shoot(Vector2.right);
        }
    }
    
    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
        nextFireTime = Time.time + fireRate;
        Destroy(bullet, bulletLifetime);
    }
    
   
}
public class WeaponDamage : EnemyDamage
{

}