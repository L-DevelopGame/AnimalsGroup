using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsGame : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HelpButton()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackToOpenningButton()
    {
        SceneManager.LoadScene("OpenGame");
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Level1Button()
    {
        SceneManager.LoadScene("Level1Mammals");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2Birds");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level3Reptiles");
    }



}
