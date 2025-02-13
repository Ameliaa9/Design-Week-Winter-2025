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

    public AudioSource audioSource;

    void Start()
    {
        // Get the button components
        startButtonComponent = startButton.GetComponent<Button>();
        resetButtonComponent = ResetButton.GetComponent<Button>();

        // Set button listeners
        startButtonComponent.onClick.AddListener(StartTimer);
        resetButtonComponent.onClick.AddListener(ResetTimer);

        // Set up initial button visibility
        ResetButton.SetActive(true);
        startButton.SetActive(true);

        UpdateTimerDisplay();

        // Ensure the audio source is stopped at the beginning
        if (audioSource != null)
        {
            audioSource.Stop();
        }
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

        // Play Song.mp3
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }


    public void ResetTimer()
    {
        timeRemaining = 180f; // Reset the timer to 3 minutes
        timerRunning = false;
        startButton.SetActive(true); // Show Start button
        ResetButton.SetActive(true); // Keep reset button visible

        UpdateTimerDisplay();
        Debug.Log("Timer reset to 3 minutes");

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the song when resetting
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timer.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
