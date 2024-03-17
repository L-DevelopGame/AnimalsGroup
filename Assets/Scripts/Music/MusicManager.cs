using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    // Singleton instance to ensure only one MusicManager exists
    private static MusicManager instance;

    // Reference to the Audio Source component that will play the music
    public AudioSource musicSource;

    // Add the scene names where you want the music to play
    public string[] scenesWithMusic;

    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private bool muted = false;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Check if an instance of MusicManager already exists
        if (instance == null)
        {
            // Set the instance to this object
            instance = this;
            // Don't destroy this GameObject when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy any additional instances of MusicManager
            Destroy(gameObject);
            return;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the SceneManager's sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Load the mute state
        if (PlayerPrefs.HasKey("muted"))
        {
            muted = PlayerPrefs.GetInt("muted") == 1;
            Debug.Log("Mute state loaded: " + muted);
        }

        // Set the initial audio listener state
        AudioListener.pause = muted;

        // Update the button icon
        UpdateButtonIcon();
    }

    // Called when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is one of the scenes with music
        foreach (string sceneName in scenesWithMusic)
        {
            if (scene.name == sceneName)
            {
                // Play the music if it's not already playing and if it's not muted
                if (!musicSource.isPlaying && !muted)
                {
                    musicSource.Play();
                }
                return;
            }
        }
        // Stop the music if the loaded scene is not one of the scenes with music or if it's muted
        musicSource.Stop();
    }

    public void ToggleMute()
    {
        muted = !muted;
        AudioListener.pause = muted;

        // Save the mute state
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        Debug.Log("Mute state saved: " + muted);

        // Update the button icon
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        soundOnIcon.enabled = !muted;
        soundOffIcon.enabled = muted;
    }
}