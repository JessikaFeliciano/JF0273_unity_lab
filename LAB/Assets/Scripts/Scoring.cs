using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public static int scoreValue = 0;
    public TMP_Text scoreText;
    public TMP_Text playerlives;


    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(nameGet.playername + ": " + scoreValue);
        playerlives.SetText("Lives: " + Movement.lives);

}

    public void savenewScore()
    {
        HighScoreTable.names[5] = nameGet.playername;
        HighScoreTable.scores[5] = scoreValue;
        scoreValue = 0;
        nameGet.playername = "";
        SceneManager.LoadScene("Main Menu");
    }

}
