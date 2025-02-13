using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Timer timer;
    public Animator animator;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnStartClicked);

        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void OnStartClicked()
    {
        if (timer != null)
        {
            timer.StartTimer();
        }

        if (animator != null)
        {
            animator.enabled = true;
        }
    }
}
