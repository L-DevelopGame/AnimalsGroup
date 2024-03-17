using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFlipAnimal : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Speed at which the sprite moves
    [SerializeField] private float moveDistance = 3.5f; // Distance the sprite should move before flipping
    [SerializeField] private bool movingRight = true; // Flag to track the movement direction
    //private float initialPosition; // Initial position of the sprite

    private float distanceTraveled = 0f; // Distance traveled since last flip


   

    private void Update()
    {
        // Calculate the movement direction
        float direction = movingRight ? 1f : -1f;

        // Calculate the movement vector
        Vector3 movement = Vector3.right * direction * moveSpeed * Time.deltaTime;

        // Move the sprite
        transform.Translate(movement);

        distanceTraveled += Mathf.Abs(movement.x);

        // Check if the sprite has traveled the required distance
        if (distanceTraveled >= moveDistance)
        {
            // Flip the sprite's direction
            movingRight = !movingRight;

            // Flip the sprite's scale
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

            // Reset the distance traveled
            distanceTraveled = 0f;
        }


        /*
        // Check if the sprite has reached the end of the movement distance
        if (Mathf.Abs(transform.position.x - initialPosition) >= moveDistance)
        {
            // Flip the sprite's direction
            movingRight = !movingRight;

            // Flip the sprite's scale
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }*/
    }
}
