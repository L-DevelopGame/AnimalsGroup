using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(TextMeshPro))]
//[RequireComponent(typeof(NumberField))]

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] private string triggeringTag;
    [SerializeField] private NumberField scoreField;
    [SerializeField] private int pointsToAdd;
    [SerializeField] private GameObject wellDoneText;
    [SerializeField] private TextMeshProUGUI pickedAnimalsText; // Reference to the UI Text element
    [SerializeField] private int ANIMALSFORWINNING;

    [SerializeField] private AudioClip goodSound; // Add this field for the hit sound effect
    private AudioSource audioSource; // Add this field for AudioSource



    private List<string> pickedAnimals = new List<string>();


    private void Start()
    {
        wellDoneText.SetActive(false);
        pickedAnimalsText.text = ""; // Clear the text initially
        audioSource = GetComponent<AudioSource>();



    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && scoreField!=null) {
       //     Debug.Log(other.tag + " other.tag, " + triggeringTag + " triggeringTag=" );
            scoreField.AddNumber(pointsToAdd);
            if (goodSound != null)
            {
                audioSource.enabled = true;
                audioSource.PlayOneShot(goodSound); ;
            }

            pickedAnimals.Add(other.gameObject.name); // Add picked animal to the list

            UpdatePickedAnimalsText(); // Update the text when a new animal is picked
            Destroy(other.gameObject);
            StartCoroutine(ShowWellDoneText());

        }
    }

    private void UpdatePickedAnimalsText()
    {

        /*
        pickedAnimalsText.text = ""; // Clear the previous text
        if (scoreField.GetNumber() == ANIMALSFORWINNING)
        {
            Debug.Log("Win scene if!");
            SceneManager.LoadScene("WinScreen");


        }
        else
        {
            
            // Ensure the number of items does not exceed the desired size
            int numItems = Mathf.Min(pickedAnimals.Count, 14);

            // Iterate over each item in the list
            for (int i = 0; i < numItems; i++)
            {
                // Append the current animal name to the text
                pickedAnimalsText.text += pickedAnimals[i];

                // If it's not the last item in the row, add a tab for spacing
                if ((i + 1) % 2 != 0 && i != numItems - 1)
                {
                    pickedAnimalsText.text += "   \t";
                }
                // If it's the last item in the row, add a newline character
                else if ((i + 1) % 2 == 0)
                {
                    pickedAnimalsText.text += "\n";
                }
            }
        }
            */

        
        // Clear the previous text
        pickedAnimalsText.text = "\n";

        if (scoreField.GetNumber() == ANIMALSFORWINNING)
        {
            Debug.Log("Win scene if!");
            SceneManager.LoadScene("WinScreen");


        }
        else
        {
        // Append each picked animal to the text
        foreach (string animal in pickedAnimals)
        {
            pickedAnimalsText.text += animal + "\n";

        }
           }
        
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }

    private IEnumerator ShowWellDoneText()
    {
        wellDoneText.SetActive(true);
        yield return new WaitForSeconds(2f);
        wellDoneText.SetActive(false);
    }



}
