using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
   
    [SerializeField] TMP_Text score5Text;
    [SerializeField] TMP_Text score4Text;
    [SerializeField] TMP_Text score3Text;
    [SerializeField] TMP_Text score2Text;
    [SerializeField] TMP_Text score1Text;
    [SerializeField] TMP_Text name5Text;
    [SerializeField] TMP_Text name4Text;
    [SerializeField] TMP_Text name3Text;
    [SerializeField] TMP_Text name2Text;
    [SerializeField] TMP_Text name1Text;


   
    public static int[] scores =  new int[] { 0, 0, 0, 0, 0, 0 };
    public static string[] names = new string[] { "", "", "", "", "", "" };


  

    private void Awake()
    {

        tableSort();

        score1Text.SetText(scores[0].ToString());
        score2Text.SetText(scores[1].ToString());
        score3Text.SetText(scores[2].ToString());
        score4Text.SetText(scores[3].ToString());
        score5Text.SetText(scores[4].ToString());
        name1Text.SetText(names[0]);
        name2Text.SetText(names[1]);
        name3Text.SetText(names[2]);
        name4Text.SetText(names[3]);
        name5Text.SetText(names[4]);
    }


    public void tableSort()
    {
        int tempscore;
        string tempname;
        for (int i = 0; i < 5; i++)
        {
            for (int j = i +1; j < 6; j++)
            {
                if (scores[i] < scores[j])
                {
                    tempscore = scores[i];
                    scores[i] = scores[j];
                    scores[j] = tempscore;
                    tempname = names[i];
                    names[i] = names[j];
                    names[j] = tempname;
                }
             
            }
            
        }
    }
    
}
