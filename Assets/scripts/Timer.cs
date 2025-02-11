using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f; // 3 Minute Timer
    public bool timerRunning = false;
    public TMP_Text timer;

    // UI Buttons
    public GameObject startButton;
    public GameObject ResetButton;

    private Button startButtonComponent;
    private Button resetButtonComponent;

    void Start()
    {
        // Get the button components
        startButtonComponent = startButton.GetComponent<Button>();
        resetButtonComponent = ResetButton.GetComponent<Button>();

        // Set button listeners
        startButtonComponent.onClick.AddListener(StartTimer);
        resetButtonComponent.onClick.AddListener(ResetTimer);

        // Set up initial button visibility
        ResetButton.SetActive(true); // Reset button is visible at the start
        startButton.SetActive(true); // Start button is visible at the start
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
                startButton.SetActive(true); // Start button reappears when timer reaches 0
                ResetButton.SetActive(false); // Reset button hides when timer reaches 0
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
            startButton.SetActive(false); // Start button disappears when timer starts
            ResetButton.SetActive(true); // Reset button stays visible
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 180f; // Reset the timer to 3 minutes
        timerRunning = true; // Continue the timer (set it to true to keep counting down)
        Debug.Log("Timer reset to 3 minutes");
    }
}