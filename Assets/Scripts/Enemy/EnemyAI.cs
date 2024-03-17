using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        if (isInChaseRange)
        {

            Vector2 playerDirection = (target.position - transform.position).normalized;

            // Set movement direction
            movement = playerDirection;

            if (shouldRotate)
            {
                // Set X and Y parameters based on movement direction
                if (Mathf.Abs(playerDirection.x) > Mathf.Abs(playerDirection.y))
                {
                    // Horizontal movement is dominant
                    anim.SetFloat("X", playerDirection.x);
                    anim.SetFloat("Y", 0);
                }
                else
                {
                    // Vertical movement is dominant
                    anim.SetFloat("X", 0);
                    anim.SetFloat("Y", playerDirection.y);
                }
            }
        }

        anim.SetBool("isRunning", isInChaseRange);
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        else if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }
}