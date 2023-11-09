using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
 

    static public float timeSinceStart =0;
    TextMeshProUGUI textMeshProUGUI;
    static public bool isSTarted = false;
    
    void Start()
    {
        textMeshProUGUI= GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (isSTarted)
        {
            textMeshProUGUI.text = "Temps: " + String.Format("{0:0.##}", (timeSinceStart += Time.deltaTime)); 
        }
      
    }
}
