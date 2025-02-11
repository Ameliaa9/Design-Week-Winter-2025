using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f; // 3 Minute Timer
    public bool timerRunning = false;
    public TMP_Text timer;

    void Start()
    {
        timerRunning = false; // Starts timer after button is pressed
    }

    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false; // Stop timer
                Debug.Log("Time!");
            }
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timer.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        if (!timerRunning) // Start the timer if it's not already running
        {
            timeRemaining = 180f; // Set to 3 minutes
            timerRunning = true; // Start timer
        }
    }

    public void StopTimer()
    {
        timerRunning = false; // Stop the timer
    }
}
