using UnityEngine;
using TMPro;

public class Background : MonoBehaviour
{
    public Camera mainCamera;
    public Color defaultColor = Color.gray; // Default Background Colour on Reset Button
    public Color firstPhaseColor = Color.blue; // Background Colour on Play Button
    public Color finalPhaseColor = Color.red; // Background Colour after 4:00 has passed

    private Timer timerScript;

    void Start()
    {
        mainCamera = mainCamera ?? Camera.main;
        timerScript = FindObjectOfType<Timer>();
        mainCamera.backgroundColor = defaultColor;
    }

    void Update()
    {
        if (timerScript == null) return;

        if (timerScript.timeRemaining <= 0)
        {
            mainCamera.backgroundColor = finalPhaseColor;
        }
        else
        {
            mainCamera.backgroundColor = firstPhaseColor;
        }
    }
}
