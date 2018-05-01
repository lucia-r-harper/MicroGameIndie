using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Should only be used to store a reference to the toggles in the right order in the startupscreen
public class MicroGameToggles : MonoBehaviour
{
    public Toggle[] Toggles = new Toggle[8];
    public Button startFromCustomModeButton;

    private void OnDisable()
    {
        //ResetToggle();
    }

    public void ResetToggle()
    {
        foreach (Toggle toggle in Toggles)
        {
            toggle.isOn = true;
        }
    }

    private void Update()
    {
        DisableCustomModeStartButtonIfNoTogglesAreEnabled();
    }

    private void DisableCustomModeStartButtonIfNoTogglesAreEnabled()
    {
        foreach (Toggle toggle in Toggles)
        {
            if (toggle.isOn == false)
            {
                startFromCustomModeButton.interactable = false;
            }
            else
            {
                startFromCustomModeButton.interactable = true;
            }
        }
    }
}
