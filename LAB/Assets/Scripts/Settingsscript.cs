using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settingsscript : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider audioSlider;

    public static int scoreMOD = 1;
    public static float difficulty = 1f;
    public void infQuilsson(bool isOn)
    {
        if (isOn)
        {
            NeedleScript.inc = 0;
            NeedleScript.needlecnt = 0;
            Debug.Log("Infinite Quills ON");
            scoreMOD = 0;
        }
        else
        {
            NeedleScript.inc = 1;
            NeedleScript.needlecnt = 0;
            Debug.Log("Infinite Quills OFF");
            scoreMOD = 1;
        }
        
    }
    public void SlowBaloon(bool SBisOn)
    {
        if (SBisOn)
        {
            baloonmovement.SPEED = 10;
            Debug.Log("Slow Baloons ON");
            scoreMOD = 0;
        }
        else
        {
            baloonmovement.SPEED = 25;
            Debug.Log("Slow Baloons OFF");
            scoreMOD = 1;
        }

    }
    public void FreezeBird(bool FBisOn)
    {
        if (FBisOn)
        {
            birdmovement.SPEED = 0;
            Debug.Log("Freeze Birds ON");
            scoreMOD = 0;
        }
        else
        {
            birdmovement.SPEED = 20;
            Debug.Log("Freeze Birds OFF");
            scoreMOD = 1;
        }

    }

    public void setdifficulty(int diffindex)
    {
        if (diffindex == 1)
        {
            difficulty = 1f;
            scoreMOD = 1;
        }
        else if (diffindex == 2)
        {
            difficulty = 1.5f;
            scoreMOD = 2;
        }
        else if (diffindex == 0) {
            difficulty = .75f;
            scoreMOD = 0;
        }
        else
            difficulty = 1f;

    }

    public void SetVol()
    {
        float volume = audioSlider.value; 
        audioMixer.SetFloat("volume", volume);
    }
}
