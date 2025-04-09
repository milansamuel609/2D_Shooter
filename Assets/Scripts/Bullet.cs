using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Add score
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(100);
            }

            // Create explosion at the enemy position
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            }

            // Notify GameManager about destroyed enemy
            if (GameManager.instance != null)
            {
                GameManager.instance.EnemyDestroyed();
            }

            // Destroy enemy
            Destroy(other.gameObject);

            // Destroy bullet
            Destroy(gameObject);
        }
    }
}