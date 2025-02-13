using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f; // 3-Minute Timer
    private bool timerRunning = false;
    private bool secondTimerRunning = false; // One-Minute Timer

    // Public getters for other scripts (like Background.cs)
    public bool IsTimerRunning => timerRunning;
    public bool IsSecondTimerRunning => secondTimerRunning;

    public TMP_Text timer;
    public GameObject startButton;
    public GameObject ResetButton;
    private Button startButtonComponent;
    private Button resetButtonComponent;
    public AudioSource audioSource;

    private float oneMinuteRemaining = 60f; // Last minute countdown

    // Animator Reference for Scale Animation
    public Animator scaleAnimator;

    void Start()
    {
        startButtonComponent = startButton.GetComponent<Button>();
        resetButtonComponent = ResetButton.GetComponent<Button>();

        startButtonComponent.onClick.AddListener(StartTimer);
        resetButtonComponent.onClick.AddListener(ResetTimer);

        ResetButton.SetActive(true);
        startButton.SetActive(true);

        UpdateTimerDisplay();

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
                timerRunning = false;
                secondTimerRunning = true; // Start the final 1-minute countdown
            }

            UpdateTimerDisplay();
        }
        else if (secondTimerRunning)
        {
            oneMinuteRemaining -= Time.deltaTime;

            if (oneMinuteRemaining <= 0)
            {
                oneMinuteRemaining = 0;
                secondTimerRunning = false;
                Debug.Log("Time Up!");
            }

            UpdateTimerDisplay();
        }
    }

    public void StartTimer()
    {
        if (!timerRunning && !secondTimerRunning)
        {
            timerRunning = true;
            startButton.SetActive(false);
            ResetButton.SetActive(true);

            // Reset text color when restarting from 3:00
            timer.color = Color.white;
        }

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 180f;
        oneMinuteRemaining = 60f;
        timerRunning = false;
        secondTimerRunning = false;

        startButton.SetActive(true);
        ResetButton.SetActive(true);

        // Reset text color when resetting
        timer.color = Color.white;

        UpdateTimerDisplay();

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (scaleAnimator != null)
        {
            scaleAnimator.enabled = false; // Disable animation when resetting
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes, seconds;

        if (secondTimerRunning)
        {
            minutes = Mathf.FloorToInt(oneMinuteRemaining / 60);
            seconds = Mathf.FloorToInt(oneMinuteRemaining % 60);
            timer.color = Color.red; // Change text color to red in last minute
        }
        else
        {
            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);
        }

        timer.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
