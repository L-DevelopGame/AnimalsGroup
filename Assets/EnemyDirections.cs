using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDirections : MonoBehaviour
{
    public GameObject player;
    public GameObject enemySprite;

    private Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = enemySprite.GetComponent<Animator>();
    }

    void Update()
    {
        // Determine direction to the player
        Vector3 direction = player.transform.position - transform.position;

        // Set animation state based on direction
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                // Player is to the right of the enemy
                enemyAnimator.SetInteger("State", 1); // Set animation state for right direction
            }
            else
            {
                // Player is to the left of the enemy
                enemyAnimator.SetInteger("State", 2); // Set animation state for left direction
            }
        }
        else
        {
            if (direction.y > 0)
            {
                // Player is above the enemy
                enemyAnimator.SetInteger("State", 3); // Set animation state for up direction
            }
            else
            {
                // Player is below the enemy
                enemyAnimator.SetInteger("State", 0); // Set animation state for down direction
            }
        }
    }
}