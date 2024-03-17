using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sword collided with player.");

            // Access the player's Animator Controller
            Animator playerAnimator = this.GetComponent<Animator>();

            // Check if the player's Animator Controller is accessible
            if (playerAnimator != null)
            {
                Debug.Log("Player Animator found.");

                // Trigger the "State" parameter in the player's Animator Controller
                playerAnimator.SetInteger("State", 1);
                StartCoroutine(ResetStateAfterDelay(playerAnimator));

                Debug.Log("Player animation triggered.");
                

            }
            else
            {
                Debug.LogWarning("Player Animator not found.");
            }
        }
    
    }

    private IEnumerator ResetStateAfterDelay(Animator animator)
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Reset the "State" parameter back to 0
        animator.SetInteger("State", 0);
    }
}
