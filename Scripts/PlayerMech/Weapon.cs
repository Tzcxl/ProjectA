using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public float bulletLifetime = 0.5f;
    private Camera mainCamera;
    private Rigidbody2D rb;

    private void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - transform.position;
        lookDirection.Normalize();
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        // Стрельба при зажатии кнопки
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, bulletLifetime);
    }
}
