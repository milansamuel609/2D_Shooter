using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    void Update()
    {
        // Check if player can fire
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            // Set next fire time
            nextFireTime = Time.time + fireRate;

            // Create bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Get mouse position in world coordinates
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // Calculate direction
            Vector2 direction = (mousePos - transform.position).normalized;

            // Add velocity to bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            // Destroy bullet after 2 seconds
            Destroy(bullet, 2f);
        }
    }
}