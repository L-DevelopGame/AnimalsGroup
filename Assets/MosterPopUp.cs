using UnityEngine;

public class MonsterPopup : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float speed = 2f;

   


    private void Update()
    {
        // Move the monster to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the monster collides with any other collider
        if (other.gameObject.CompareTag("Monster"))
        {
            // Destroy the monster if it collides with an obstacle
            Destroy(gameObject);
        }
    }
}