using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifetime = 0.5f;
    public float startSize = 0.5f;
    public float endSize = 2f;
    private float startTime;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start small
        transform.localScale = new Vector3(startSize, startSize, 1);

        // Ensure this is in front of other objects
        spriteRenderer.sortingOrder = 10;
    }

    void Update()
    {
        // Calculate progress (0 to 1)
        float progress = (Time.time - startTime) / lifetime;

        // Grow over time
        float currentSize = Mathf.Lerp(startSize, endSize, progress);
        transform.localScale = new Vector3(currentSize, currentSize, 1);

        // Fade out
        Color color = spriteRenderer.color;
        color.a = 1 - progress;
        spriteRenderer.color = color;

        // Destroy when lifetime is over
        if (progress >= 1f)
        {
            Destroy(gameObject);
        }
    }
}