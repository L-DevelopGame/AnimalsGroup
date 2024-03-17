using UnityEditor;
using UnityEngine;

/**
 * This component chases a given target object.
 */
public class Chaser: MonoBehaviour
{
    [Tooltip("The object that we try to chase")]
    [SerializeField] Transform targetObject = null;
  //  [SerializeField] Transform cow1 = null;
    [SerializeField] private float speed  = 2f;

    private float ddistance;

    public Vector3 TargetObjectPosition()
    {

        return targetObject.position;

    }

    private void Update()
    {

        if (transform != null)
        {
            // Calculate distance and direction
            ddistance = Vector2.Distance(transform.position, targetObject.position);
            Vector2 direction = targetObject.position - transform.position;
            direction.Normalize();

            // Move the chaser towards the targetObject smoothly
            transform.position = Vector2.MoveTowards(this.transform.position, targetObject.transform.position, speed * Time.deltaTime);


            // Flip the object if moving to the left



            // If the direction is to the left, flip the object's sprite
            if (direction.x < 0)
            {

                transform.localScale = new Vector3(-1, 1, 1); // Flips the object horizontally
            }

            else
            {

                transform.localScale = new Vector3(1, 1, 1);


            }
        }

        // Set the animation state


        //  SetTarget(targetObject.position);
        // cow1.GetComponent<Animator>().SetInteger("State", 2);
        // float step = speed * Time.deltaTime; // speed is assumed to be a variable in your class representing movement speed
        // transform.position = Vector3.MoveTowards(transform.position, targetObject.position, step);
    }
}
