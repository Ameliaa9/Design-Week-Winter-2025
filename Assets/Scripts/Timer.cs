using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 240f; // 4 minute timer
    private bool timerRunning = false;

    public TMP_Text timer;
    public GameObject startButton;
    public GameObject resetButton;
    public GameObject startAnimation;

    public TMP_Text imposterText;

    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public AudioClip song1;
    public AudioClip song2;

    private float lastTenSeconds = 10f;

    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(StartTimer);
        resetButton.GetComponent<Button>().onClick.AddListener(ResetTimer);

        resetButton.SetActive(false);
        startButton.SetActive(true);
        if (imposterText != null) imposterText.gameObject.SetActive(false); // Hide imposter text until 4:00
        if (startAnimation != null) startAnimation.SetActive(true); // Show Scale Animation

        UpdateTimerDisplay();

        if (!audioSource1) audioSource1 = gameObject.AddComponent<AudioSource>();
        if (!audioSource2) audioSource2 = gameObject.AddComponent<AudioSource>();

        audioSource1.clip = song1;
        audioSource2.clip = song2;

        audioSource1.loop = true;
        audioSource2.loop = true;

        audioSource1.Stop();
        audioSource2.Stop();
    }

    void Update()
    {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= lastTenSeconds && timeRemaining > 0)
        {
            timer.color = Color.red; // When timer is 0:10, Change text colour to red
        }

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;

            // After 4:00 has passed

            // Stop Song1, play Song2
            if (audioSource1.isPlaying)
            {
                audioSource1.Stop();
            }

            if (!audioSource2.isPlaying)
            {
                audioSource2.Play();
            }

            // Hide the timer
            timer.gameObject.SetActive(false);

            // Hide StartAnimation
            if (startAnimation != null) startAnimation.SetActive(false);

            // Show "Who was the Imposter?" text
            if (imposterText != null)
            {
                imposterText.gameObject.SetActive(true);
                imposterText.text = "Who is the Imposter?";
                imposterText.color = Color.red;
            }
        }

        UpdateTimerDisplay();
    }

    public void StartTimer()
    {
        if (!timerRunning)
        {
            timerRunning = true;
            startButton.SetActive(false);
            resetButton.SetActive(true);
            timer.color = Color.white;
            timer.gameObject.SetActive(true);
        }

        if (!audioSource1.isPlaying)
        {
            audioSource1.Play();
        }
    }

    public void ResetTimer()
    {
        Debug.Log("Reset Timer Clicked!");

        timeRemaining = 240f;
        timerRunning = false;

        startButton.SetActive(true);
        resetButton.SetActive(false);
        timer.color = Color.white;
        timer.gameObject.SetActive(true);

        // Stop all music
        audioSource1.Stop();
        audioSource2.Stop();

        // Reset UI elements
        if (imposterText != null) imposterText.gameObject.SetActive(false); // Hide imposter text
        if (startAnimation != null) startAnimation.SetActive(true); // Show Scale Animation 

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timer.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
