using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float sprintSpeed = 5f;     // Speed when close to player
    public float detectionRange = 10f; // Range to detect player
    public float sprintRange = 5f;     // Range to start sprinting
    
    [Header("AI Settings")]
    public float pathUpdateFrequency = 0.2f;
    public bool usePathPrediction = true;
    
    // Private variables
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private float nextPathUpdate;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextPathUpdate = 0f;
    }
    
    void Update()
    {
        if (player == null || !player.gameObject.activeSelf) return;
        
        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // Check if it's time to update path
        if (Time.time >= nextPathUpdate)
        {
            UpdateTargetPosition(distanceToPlayer);
            nextPathUpdate = Time.time + pathUpdateFrequency;
        }
        
        // Move towards target
        MoveTowardsTarget(distanceToPlayer);
    }
    
    void UpdateTargetPosition(float distanceToPlayer)
    {
        // If player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            if (usePathPrediction && distanceToPlayer > 1.5f)
            {
                // Try to predict where player will be
                Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    // Predict player position based on current velocity
                    float timeToReachPlayer = distanceToPlayer / moveSpeed;
                    targetPosition = (Vector2)player.position + playerRb.velocity * timeToReachPlayer * 0.5f;
                }
                else
                {
                    targetPosition = player.position;
                }
            }
            else
            {
                targetPosition = player.position;
            }
        }
    }
    
    void MoveTowardsTarget(float distanceToPlayer)
    {
        if (distanceToPlayer <= detectionRange)
        {
            // Get direction to target
            Vector2 direction = ((Vector2)targetPosition - (Vector2)transform.position).normalized;
            
            // Determine speed based on distance
            float currentSpeed = distanceToPlayer <= sprintRange ? sprintSpeed : moveSpeed;
            
            // Apply movement
            rb.velocity = direction * currentSpeed;
            
            // Optional: Rotate enemy to face direction of movement
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        else
        {
            // Stop if player is out of detection range
            rb.velocity = Vector2.zero;
        }
    }
    
    // Optional: Add visualization for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sprintRange);
    }
}