using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundary : MonoBehaviour
{
    public GameObject enemy;
    private EnemyController enemyController;

    void Start()
    {
        enemyController = FindObjectOfType<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.transform.position = enemyController.startPos;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyController.GetTarget();
        }
    }
}
