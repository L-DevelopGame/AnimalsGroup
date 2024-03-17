using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateIconsMusic : MonoBehaviour
{

    public static UpdateIconsMusic instance;

    public Image soundOnIcon;
    public Image soundOffIcon;

    private void Awake()
    {
        // Ensure only one instance of UpdateIconsMusic exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction when loading new scene
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void UpdateIcons(bool isMuted)
    {
        // Check if the icon references are assigned
        if (soundOnIcon != null && soundOffIcon != null)
        {
            soundOnIcon.enabled = !isMuted;
            soundOffIcon.enabled = isMuted;
        }
    }
}