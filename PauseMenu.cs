using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }

        }
    }


    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        NeedleScript.needlecnt = 0;
        Scoring.scoreValue  = 0;
        nameGet.playername = "";
    }

}
