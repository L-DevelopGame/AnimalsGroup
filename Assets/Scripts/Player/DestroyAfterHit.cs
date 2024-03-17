using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyAfterHits : MonoBehaviour
{
    [SerializeField] private string triggeringTag;
    [SerializeField] private int PlayerLife;
    [Tooltip("Every enemy hitting will decrease this field")]
    [SerializeField] private NumberFieldGUI HealthField;
    [SerializeField] private GameObject messageHitWrongAnimal;
    [SerializeField] private GameObject messageHeartLife;
    [SerializeField] private GameObject messageHitByEnemy;
    [SerializeField] private GameObject messageHitByFire;
    [SerializeField] private AudioClip badSound; // Add this field for the hit sound effect
    [SerializeField] private AudioClip goodSound; // Add this field for the hit sound effect
    [SerializeField] private AudioClip swordEnemySound; // Add this field for the hit sound effect

    private AudioSource audioSource; // Add this field for AudioSource


    bool messageShown = false;
    bool isAttacking = false;



    private void Start()
    {
        HealthField.SetNumber(PlayerLife);
        messageHitWrongAnimal.SetActive(false);
        isAttacking = false;
        messageHeartLife.SetActive(false);
        messageHitByEnemy.SetActive(false);
        messageHitByFire.SetActive(false);
        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != triggeringTag && other.tag != "EnemySword" && other.tag != "HeartLife" &&  other.tag != "Fire" && other.tag !="Bush" )
        {
           // Debug.Log("checf!"+ other.tag);
            --PlayerLife;
            HealthField.SetNumber(PlayerLife);
            Destroy(other.gameObject);
            ShowMessagePanel();
            messageShown = true; // Ensure message is shown only once

            if (badSound != null)
            {
                audioSource.enabled = true;
                audioSource.PlayOneShot(badSound); ;
            }


            if (PlayerLife == 0)
            {
                //
               
               // Destroy(this.gameObject);

                // Debug.Log("Lose scene if!");
                // SceneManager.LoadScene("LoseScreen");
            }
        }


        if (other.tag == "HeartLife")
        {

            ++PlayerLife;
            HealthField.SetNumber(PlayerLife);
            Destroy(other.gameObject);
            StartCoroutine(ShowExtraHearLifeMessage());

            if (goodSound != null)
            {
                audioSource.enabled = true;
                audioSource.PlayOneShot(goodSound); ;
            }


        }


        if (other.tag == "Fire")
        {

            --PlayerLife;
            HealthField.SetNumber(PlayerLife);
            Destroy(other.gameObject);
            ShowMessagePanelFire();
            messageShown = true; // Ensure message is shown only once

            if (badSound != null)
            {
                audioSource.enabled = true;
                audioSource.PlayOneShot(badSound); ;
            }

        }

        if (other.tag == "EnemySword" )
        {
            Debug.Log("Sword collided with player.");

            // Access the player's Animator Controller
            Animator playerAnimator = other.GetComponent<Animator>();

            // Check if the player's Animator Controller is accessible
            if (playerAnimator != null )
            {


                // Trigger the "State" parameter in the player's Animator Controller
                if (isAttacking == false)
                {
                    playerAnimator.SetInteger("State", 1);
                    isAttacking = true;
                    if (swordEnemySound != null)
                    {
                        audioSource.enabled = true;
                        audioSource.PlayOneShot(swordEnemySound); ;
                    }
                    StartCoroutine(ResetAttackState()); //DILEY PREVENT ANOTHER ATTACK FROM ENEMY
                    StartCoroutine(ResetStateAfterDelay(playerAnimator)); //FOR SHOW THE SWORD ATTACK TO PLAYER

                    Debug.Log("Player animation triggered.");
                    

                }
              

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
        yield return new WaitForSeconds(1.3f);
        animator.SetInteger("State", 0);
          ShowMessagePanelEnemy();
       // ShowMessagePanel();

        --PlayerLife;
        HealthField.SetNumber(PlayerLife);
        messageShown = true; // Ensure message is shown only once

        if (swordEnemySound != null)
        {
            audioSource.enabled = true;
            audioSource.PlayOneShot(swordEnemySound); ;
        }

        // Reset the "State" parameter back to 0

        if (PlayerLife == 0)
        {
           // Destroy(this.gameObject);
         //   ShowMessagePanel();

            //  Debug.Log("Lose scene if!");
            // SceneManager.LoadScene("LoseScreen");
        }
    }

    private IEnumerator ResetAttackState()
    {
        yield return new WaitForSeconds(4f); // Adjust the delay as needed
        isAttacking = false;
    }
        
    void ShowMessagePanel()
    {
        messageHitWrongAnimal.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    void ShowMessagePanelEnemy()
    {
        messageHitByEnemy.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    void ShowMessagePanelFire()
    {
        messageHitByFire.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }


    private IEnumerator ShowExtraHearLifeMessage()
    {
        messageHeartLife.SetActive(true);
        yield return new WaitForSeconds(2f);
        messageHeartLife.SetActive(false);
    }

    void Update()
    {
        if (messageShown && Input.GetKeyDown(KeyCode.Space) )
        {
            // Hide the message panel and resume the game
            messageHitWrongAnimal.SetActive(false);
            messageHitByEnemy.SetActive(false);
            messageHitByFire.SetActive(false);

            Time.timeScale = 1; // Resume the game
           // Debug.Log("Space bar pressed!");

            if(PlayerLife == 0)
            {

                // Destroy(this.gameObject);
                Debug.Log("Lose scene if!");
                SceneManager.LoadScene("LoseScreen");
            }
           
          
            

        }

       



    }

}