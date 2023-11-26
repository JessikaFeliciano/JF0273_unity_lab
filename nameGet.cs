using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nameGet : MonoBehaviour
{
    public TMPro.TMP_InputField myfield;
    public static string playername;
    // Start is called before the first frame update
    
    public void OnEnd()
    {
        playername = myfield.text;
        Debug.Log(playername);
    }
}
