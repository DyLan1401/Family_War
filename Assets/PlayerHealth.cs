using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // 
    public Slider playerHealthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        if (playerHealthSlider != null)
        {
            playerHealthSlider.maxValue = maxHealth;
            playerHealthSlider.value = currentHealth;
        }
    }

    // attack enemy
    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (playerHealthSlider != null)
        {
            playerHealthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            // in diem ra
            int finalScore = 0;
            if (GameManager.instance != null)
            {
                finalScore = GameManager.instance.totalCoins; 
            }
            GameOverManager.Instance.ShowGameOver(finalScore);
        }
    }
}