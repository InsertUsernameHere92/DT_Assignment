using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyBoundary : MonoBehaviour
{
    public GameObject enemy;
    private EnemyController enemyController;
    public GameObject enemyPrefab;
    public Vector3 startPos = new Vector3(0.02f, 8.54f);
    public bool enemySpawned;
    public int enemyDamageTaken;
    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.transform.position = startPos;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasTriggered)
            {
                if (!enemySpawned)
                {
                    hasTriggered = true;
                    SpawnEnemy();
                }
                else
                {
                    hasTriggered = true;
                    DespawnEnemy();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasTriggered)
            {
                hasTriggered = false;
            }
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, startPos, Quaternion.identity);
        enemyController = FindObjectOfType<EnemyController>();
        enemyController.health = enemyController.maxHealth - enemyDamageTaken;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemySpawned = true;
    }

    public void DespawnEnemy()
    {
        enemyDamageTaken = enemyController.maxHealth - enemyController.health;
        Destroy(enemy);
        enemySpawned = false;
    }
}
