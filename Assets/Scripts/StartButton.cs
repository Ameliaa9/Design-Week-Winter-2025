using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Timer timer;
    public AudioSource audioSource;
    public Animator animator;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnStartClicked);

        // Audio is stopped before Start button is pressed
        if (audioSource != null)
        {
            audioSource.loop = false;
            audioSource.Stop();
        }

        // Scale Animation is stopped before Start button is pressed
        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void OnStartClicked()
    {
        // Start the timer
        if (timer != null)
        {
            timer.StartTimer();
        }

        // Play the audio
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Enable Scale Animation
        if (animator != null)
        {
            animator.enabled = true;
        }
    }
}
