using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadiusCircleDraw : MonoBehaviour
{
    private float radius = 5f;

    private void OnDrawGizmosSelected()
    {
        // Set the color to red
        Gizmos.color = Color.red;

        // Draw a wire sphere at the enemy's position with the specified radius
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
