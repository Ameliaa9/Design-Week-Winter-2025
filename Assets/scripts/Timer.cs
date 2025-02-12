using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f; // 3 Minute Timer
    private bool timerRunning = false;
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

        UpdateTimerDisplay(); // Ensure correct time display at the start
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
                startButton.SetActive(true); // Show Start button when time reaches 0
                ResetButton.SetActive(true); // Reset button stays visible
                Debug.Log("Time Up!");
            }

            UpdateTimerDisplay();
        }
    }

    public void StartTimer()
    {
        if (!timerRunning) // Start the timer only if it isn't running
        {
            timerRunning = true; // Start timer
            startButton.SetActive(false); // Hide start button
            ResetButton.SetActive(true); // Keep reset button visible
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 180f; // Reset the timer to 3 minutes
        timerRunning = false; // Stop the countdown
        startButton.SetActive(true); // Show Start button
        ResetButton.SetActive(true); // Keep reset button visible

        UpdateTimerDisplay(); // Update UI immediately
        Debug.Log("Timer reset to 3 minutes");
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timer.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}