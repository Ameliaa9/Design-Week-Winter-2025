using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Timer timer;
    public Animator animator;

    private Button button; // Store reference to Button component

    private void Awake()
    {
        // Get the Button component from the prefab
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnStartClicked);
        }
        else
        {
            Debug.LogError("Button component missing on StartButton prefab!");
        }

        if (animator != null)
        {
            animator.enabled = false; // Disable animator at start
        }
    }

    private void OnStartClicked()
    {
        Debug.Log("Start Button Clicked!");

        if (timer != null)
        {
            timer.StartTimer();
        }
        else
        {
            Debug.LogWarning("Timer reference is missing!");
        }

        if (animator != null)
        {
            animator.enabled = true;
        }
    }
}