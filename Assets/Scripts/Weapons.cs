using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public EnemyController enemyController;
    public PlayerMovement playerMovement;
    public float attackRange = 1.5f;
    public GameObject attackRadius;
    public bool enemyInRange;
    public int stickDamage = 1;
    public float stickAttackRate = 1;
    public bool canAttack = true;
    public bool weaponUsedLast = false;
    public float attackCooldown;
    public GameObject yesAttack;
    public GameObject noAttack;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (enemyController == null)
        {
            enemyController = FindObjectOfType<EnemyController>();
        }
        if (!canAttack)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                canAttack = true;
                attackCooldown = 0;
                Debug.Log(canAttack);
            }
        }
        if (weaponUsedLast)
        {
            if (!canAttack)
            {
                noAttack.SetActive(true);
                yesAttack.SetActive(false);
            }
            if (canAttack)
            {
                noAttack.SetActive(false);
                yesAttack.SetActive(true);
            }
        }
        if (!weaponUsedLast)
        {
            noAttack.SetActive(false);
            yesAttack.SetActive(false);
        }
    }

    public void STICK()
    {
        if (enemyController != null)
        {
            //RaycastHit2D hit = Physics2D.Raycast(playerMovement.pCenter.transform.position, playerMovement.moveInput, attackRange, LayerMask.GetMask("Collision"));
            //if (hit && hit.collider.CompareTag("Enemy"))
            //{
            //    Debug.DrawLine(playerMovement.pCenter.transform.position, hit.collider.transform.position, Color.green);
            //    enemyController.TakeDamage(1);
            //}
            //else
            //{
            //    Debug.DrawRay(playerMovement.pCenter.transform.position, playerMovement.moveInput * attackRange, Color.red);
            //}
            if (enemyInRange)
            {
                if (canAttack)
                {
                    enemyController.TakeDamage(stickDamage);
                    canAttack = false;
                    attackCooldown += stickAttackRate;
                    Debug.Log(attackCooldown);
                    Debug.Log(canAttack);
                }
            }
        }
    }
}
