using UnityEngine;

/**
 * This component patrols between given points, and chases a given target object when it sees it.
 */
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Chaser))]
public class EnemyController: MonoBehaviour {

    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] Transform cow = null;

    private Chaser chaser;
    private Patroller patroller;
    private void Start()
    {
        chaser = GetComponent<Chaser>();
        patroller = GetComponent<Patroller>();
        chaser.enabled = false;
        patroller.enabled = true;
        cow.GetComponent<Animator>().SetInteger("State", 1);

    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, chaser.TargetObjectPosition());
        if (distanceToTarget <= radiusToWatch)
        {
            chaser.enabled = true;
            cow.GetComponent<Animator>().SetInteger("State", 2);

            patroller.enabled = false;
        }
        else
        {
            patroller.enabled = true;
            chaser.enabled = false;
            cow.GetComponent<Animator>().SetInteger("State", 1);


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToWatch);
    }
}
 