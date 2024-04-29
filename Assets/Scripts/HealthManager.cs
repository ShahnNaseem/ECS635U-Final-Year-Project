using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public BossAI bossAI;

    public Slider playerHealthBar;
    public Slider bossHealthBar;

    public float playerHealth;
    public float bossHealth;
    public float maxHealth = 100f;

    void Start()
    {
        playerHealth = maxHealth;
        bossHealth = maxHealth;
        UpdateHealthUI();
    }

    public void DealDamageToPlayer(float damageAmount)
    {
        playerHealth -= damageAmount;
        playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        UpdateHealthUI();

        if (playerHealth <= 0)
        {
            Debug.Log("Player defeated");
            // Handle player defeat
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void DealDamageToBoss(float damageAmount)
    {
        bossHealth -= damageAmount;
        bossHealth = Mathf.Clamp(bossHealth, 0, maxHealth);
        UpdateHealthUI();

        if (bossHealth <= 0)
        {
            Debug.Log("Boss health depleted");
            bossAI.Die();
        }
    }

    private void UpdateHealthUI()
    {
        playerHealthBar.value = playerHealth;
        bossHealthBar.value = bossHealth;
    }
}

