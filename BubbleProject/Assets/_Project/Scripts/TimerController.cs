using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private int initTimeMinutes;
    [SerializeField] private int initTimeSeconds;
    private float waitSeconds;
    public static event Action OnEndState;

    void Start()
    {
        textTimer.text = $"{initTimeMinutes:D2} : {initTimeSeconds:D2}";
        waitSeconds = initTimeMinutes * 60 + initTimeSeconds;
    }

    private void FixedUpdate()
    {
        if (waitSeconds > 0)
        {
            waitSeconds -= Time.deltaTime; 
            int waitSecondsInt = Mathf.CeilToInt(waitSeconds); 
            int minutesToPrint = waitSecondsInt / 60; 
            int secondsToPrint = waitSecondsInt % 60; 

            textTimer.text = $"{minutesToPrint:D2} : {secondsToPrint:D2}";
        }
        else
        {
            textTimer.text = "00 : 00";
            OnEndState?.Invoke();
        }
    }
}
