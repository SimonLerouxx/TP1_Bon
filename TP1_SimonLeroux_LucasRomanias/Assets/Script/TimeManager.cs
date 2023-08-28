using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update

    float timeSinceStart =0;
    TextMeshProUGUI textMeshProUGUI;
    
    void Start()
    {
        textMeshProUGUI= GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       textMeshProUGUI.text ="Temps: "+ String.Format("{0:0.##}", (timeSinceStart += Time.deltaTime)); ;
    }
}
