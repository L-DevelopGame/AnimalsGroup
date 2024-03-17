using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public string[] scenesWithMusic;
    public AudioSource musicAudioSource; // Reference to the music audio source
    [SerializeField] private float volumeSoundNum = 0.165f;

    // Persistent instance of the Music script
    static Music instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //updating logic my player press and depending on that will be setting the icon. we will also muting or unmuting depending on that
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            Debug.Log("MUTED,0=0");
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            Debug.Log("MUTED,1=1");
            PlayerPrefs.SetInt("Muted", 0);
        }

        UpdateMusicVolume();
    }

    // Method to check if the current scene is one of the scenes with music
    public bool IsSceneShouldBeWithMusic()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        foreach (string sceneName in scenesWithMusic)
        {
            if (currentScene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    private void CheckIfIsSceneShouldBeWithMusic()
    {
        if (IsSceneShouldBeWithMusic() && PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            Debug.Log("Music is enabled for this scene.");
            musicAudioSource.volume = volumeSoundNum; 
                                                      
        }
        else
        {
            Debug.Log("Music is disabled for this scene.");
            musicAudioSource.volume = 0f; // Set music volume to 0
        }
    }

    private void UpdateMusicVolume()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            musicAudioSource.volume = volumeSoundNum;
        }
        else
        {
            musicAudioSource.volume = 0f;
        }
    }

    private void Update()
    {
        CheckIfIsSceneShouldBeWithMusic();
    }

    /*
    public string[] scenesWithMusic;
 

    //pressisting our music between scenes

    static Music instane = null;
    
     private void Awake()
    {
        if(instane != null) //for not spam every another new music clip again. takes care no additional music game object are being spamed every time u move between scenes
        {
            Destroy(gameObject);
        }
        else
        {
            instane = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    //updating logic my player press and depending on that will be setting the icon. we will also muting or unmuting depending on that
    public void ToggleSound()
    {
       
            if (PlayerPrefs.GetInt("Muted", 0) == 0)
            {
            Debug.Log("MUTED,0=0");

            PlayerPrefs.SetInt("Muted", 1);
            }
            else
            {
            Debug.Log("MUTED,1=1");

            PlayerPrefs.SetInt("Muted", 0);

            }


    }

    // Method to check if the current scene is one of the scenes with music
    public bool IsSceneShouldBeWithMusic()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        foreach (string sceneName in scenesWithMusic)
        {
            if (currentScene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }


    private void CheckIfIsSceneShouldBeWithMusic()
    {
        if (IsSceneShouldBeWithMusic() && PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            Debug.Log("music.IsSceneShouldBeWithMusic() " + IsSceneShouldBeWithMusic());

            AudioListener.volume = 1;

        }
        else
        {
            Debug.Log("music.IsSceneShouldBeWithMusic() " + IsSceneShouldBeWithMusic());

         //   AudioListener.volume = 0;


        }

    }

    private void Update()
    {
        CheckIfIsSceneShouldBeWithMusic();
    }
    */
}
