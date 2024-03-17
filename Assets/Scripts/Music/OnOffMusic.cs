using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnOffMusic : MonoBehaviour
{
    private Music music;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    [SerializeField] private float volumeSoundNum = 0.165f;

    private void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIconAndVolume();
    }



    public void PauseMusic() //function when player press button on icon - update our player prefs;
    {
        music.ToggleSound();
        UpdateIconAndVolume(); 

    }

    void UpdateIconAndVolume() //update the icon and volum
    {
        if (PlayerPrefs.GetInt("Muted",0 )== 0)
        {
            AudioListener.volume = volumeSoundNum;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }

    }


  



    // Play or stop music based on whether the current scene is one of the scenes with music








    /*
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;



    }

    // Update is called once per frame
    public void onButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;

        }
        
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }

        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;

        }

    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;

    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1 : 0);

    }


    public void UpdateMuteState(bool mutedState)
    {
        muted = mutedState;
        UpdateButtonIcon();
    }*/

}
