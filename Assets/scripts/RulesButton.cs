using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RulesButton : MonoBehaviour
{
    public GameObject rulesPanel;

    private void Start()
    {
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(false); // Hide panel at start (Displays rules)
        }

        GetComponent<Button>().onClick.AddListener(ToggleRules);
    }

    private void ToggleRules()
    {
        if (rulesPanel != null)
        {
            bool isActive = rulesPanel.activeSelf;
            rulesPanel.SetActive(!isActive);
        }
    }

    private void Update()
    {
        // If ESC key pressed, close the rules panel
        if (rulesPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            rulesPanel.SetActive(false);
        }
    }
}


