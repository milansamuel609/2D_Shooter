using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI winScoreText;
    private int score = 0;
    private bool isGameOver = false;
    private int enemyCount;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Hide end game panels at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        // Count initial enemies
        CountEnemies();

        UpdateScoreText();
    }

    void CountEnemies()
    {
        // Count all objects with Enemy tag
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Enemy count: " + enemyCount);
    }

    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void EnemyDestroyed()
    {
        // Reduce enemy count
        enemyCount--;

        // Check for win condition
        if (enemyCount <= 0)
        {
            Win();
        }
    }

    public void Win()
    {
        isGameOver = true;

        // Show win panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);

            if (winScoreText != null)
            {
                winScoreText.text = "Final Score: " + score;
            }
        }

        // Enable restart after delay
        Invoke("EnableRestart", 1.5f);
    }

    public void GameOver()
    {
        isGameOver = true;

        // Show game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (finalScoreText != null)
            {
                finalScoreText.text = "Final Score: " + score;
            }
        }

        // Enable restart after delay
        Invoke("EnableRestart", 1.5f);
    }

    void EnableRestart()
    {
        // Allow restart by pressing R
        // Implemented in Update
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}