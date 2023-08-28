using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text ="Final Time: "+ String.Format("{0:0.##}", TimeManager.timeSinceStart ) +" s";
    }

    
   
}
