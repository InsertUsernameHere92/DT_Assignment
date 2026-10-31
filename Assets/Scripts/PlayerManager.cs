using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject deathScreen;
    private EnemyBoundary enemyBoundary;
    public int damageTaken;

    void Start()
    {
        enemyBoundary = FindObjectOfType<EnemyBoundary>();
        deathScreen.SetActive(false);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        damageTaken = maxHealth - currentHealth;
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            currentHealth = maxHealth;
            if (enemyBoundary.enemySpawned)
            {
                enemyBoundary.DespawnEnemy();
            }
        }
    }
}
