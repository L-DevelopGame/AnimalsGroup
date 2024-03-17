using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;



public class QuitGame : MonoBehaviour
{
    public GameObject quitPanel; // Reference to the panel containing the quit confirmation UI

    private bool isPaused = false;

    private void Start()
    {
        // Deactivate the quit confirmation panel initially
        if (quitPanel != null)
            quitPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        isPaused = true;

        // Show the quit confirmation panel
        if (quitPanel != null)
            quitPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false;

        // Hide the quit confirmation panel
        if (quitPanel != null)
            quitPanel.SetActive(false);
    }

    public void CancelQuit()
    {
        // Hide the quit confirmation panel when cancel is clicked
        if (quitPanel != null)
            quitPanel.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        // Resume the game before loading the main menu scene
        Time.timeScale = 1f;

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}