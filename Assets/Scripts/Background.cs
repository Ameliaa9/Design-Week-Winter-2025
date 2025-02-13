using UnityEngine;
using TMPro;

public class Background : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject startAnimation; // Assign "StartAnimation" GameObject in Inspector
    public TMP_Text imposterText; // Assign a TextMeshPro object for "Vote: Who is the Imposter?"

    public Color defaultColor = Color.gray;
    public Color firstPhaseColor = Color.blue;
    public Color finalPhaseColor = Color.red;
    public Color imposterTextColor = Color.red; // Set the color to red when showing the vote text

    private Timer timerScript;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        timerScript = FindObjectOfType<Timer>();

        // Set defaults
        mainCamera.backgroundColor = defaultColor;
        if (startAnimation != null) startAnimation.SetActive(true);
        if (imposterText != null)
        {
            imposterText.gameObject.SetActive(false); // Hide "Vote" text initially
        }
    }

    void Update()
    {
        if (timerScript != null)
        {
            if (timerScript.IsSecondTimerRunning)
            {
                mainCamera.backgroundColor = finalPhaseColor;

                // Hide StartAnimation & Show Imposter Text in red
                if (startAnimation != null) startAnimation.SetActive(false);
                if (imposterText != null)
                {
                    imposterText.gameObject.SetActive(true); // Show the "Vote: Who is the Imposter?" text
                    imposterText.text = "Vote: Who is the Imposter?"; // Set the imposter text
                    imposterText.color = imposterTextColor; // Change the text color to red
                }
            }
            else if (timerScript.IsTimerRunning)
            {
                mainCamera.backgroundColor = firstPhaseColor;
                if (startAnimation != null) startAnimation.SetActive(true); // Show animation during first phase
                if (imposterText != null) imposterText.gameObject.SetActive(false); // Hide imposter text during first phase
            }
            else
            {
                mainCamera.backgroundColor = defaultColor;
                if (startAnimation != null) startAnimation.SetActive(true); // Reset StartAnimation
                if (imposterText != null) imposterText.gameObject.SetActive(false); // Hide imposter text when timer isn't running
            }
        }
    }
}
