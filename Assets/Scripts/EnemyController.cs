using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerManager playerManager;
    public GameObject target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    private float distanceToPlayer;
    public float chaseDistance = 5f;
    public int damage = 1;
    public Vector3 startPos = new Vector3(0.02f, 8.54f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        if(target)
        {
            distanceToPlayer = Vector2.Distance(transform.position, target.transform.position);
            RotateTowardsTarget();
        }
        
    }

    private void FixedUpdate()
    {
        if(target)
        {
            Move();
        }
    }

    public void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerManager.TakeDamage(damage);
        }
    }

    public void Move()
    {
        if (distanceToPlayer <= chaseDistance)
        {
            rb.velocity = transform.up * speed;
        }
    }
}
