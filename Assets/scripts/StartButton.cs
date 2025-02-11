using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Timer timer;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        if (timer != null)
        {
            timer.StartTimer(); // Start the timer when the button is clicked
        }
    }
}