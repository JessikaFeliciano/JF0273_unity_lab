using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level1");
        Movement.lives = 3;
        NeedleScript.needlecnt = 0;
    }

    public void instructionsGame()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void returnButton()
    {
        SceneManager.LoadScene("Main Menu");
        Scoring.scoreValue = 0;
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings Page");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("High Scores");
    }

    public void playScreen()
    {
        SceneManager.LoadScene("PlayScreen");
    }
}
