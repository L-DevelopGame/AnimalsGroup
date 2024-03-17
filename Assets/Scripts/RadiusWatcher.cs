
using UnityEngine;

/**
 * This component makes its object watch a given radius, and if the target is found - it starts chasing it.
 */

/*
[RequireComponent(typeof(Chaser))]
public class RadiusWatcher: MonoBehaviour {
    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] Transform cow1 = null;


    private Chaser chaser;
    private void Start() {
        chaser = GetComponent<Chaser>();
        chaser.enabled = false;
    }

    void Update() {
        float distanceToTarget = Vector3.Distance(
            transform.position, chaser.TargetObjectPosition());
        if (distanceToTarget <= radiusToWatch) {
            chaser.enabled = true;
           //// cow1.GetComponent<Animator>().SetInteger("State", 2);

        }
        else {
            chaser.enabled = false;
         //   cow1.GetComponent<Animator>().SetInteger("State", 0);

        }
    }

    private void OnDrawGizmosSelected() {
        if (enabled) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radiusToWatch);
        }
    }
}
*/