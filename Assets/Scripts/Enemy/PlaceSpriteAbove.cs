using UnityEngine;

public class PlaceSpriteAbove : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // Reference to the object the sprite should follow
    [SerializeField] private Transform sprite; // Reference to the sprite that should be placed above the target object
    [SerializeField] private float yOffset =1.3f;/* Set your desired vertical offset here */ // Adjust this value as needed
    private void Update()
    {
        if (targetObject != null && sprite != null)
        {
            // Get the target object's position
            Vector3 targetPosition = targetObject.position;

            // Set the sprite's position to match the target object's position, but with a vertical offset
            Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y + yOffset, sprite.position.z);
            sprite.position = newPosition;
        }
    }

}