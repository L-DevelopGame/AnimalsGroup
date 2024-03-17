using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public sealed class BushStomping : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private Sprite stompSprite = default;
    private AudioSource audioSource; // Add this field for AudioSource
    [SerializeField] private AudioClip crunch; // Add this field for the hit sound effect
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (crunch != null && GetComponent<SpriteRenderer>().sprite != stompSprite)
            {
                audioSource.enabled = true;
                audioSource.PlayOneShot(crunch);
            }
            GetComponent<SpriteRenderer>().sprite = stompSprite;
        }
    }
    #endregion
}