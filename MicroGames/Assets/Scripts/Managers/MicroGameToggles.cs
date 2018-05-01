using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Should only be used to store a reference to the toggles in the right order in the startupscreen
public class MicroGameToggles : MonoBehaviour
{
    public Toggle[] Toggles = new Toggle[8];
    public Button startFromCustomModeButton;

    private int togglesOn = 0;

    private void OnDisable()
    {
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
    }

    public void DisableCustomModeStartButtonIfNoTogglesAreEnabled()
    {
        togglesOn = 0;
        foreach (Toggle toggle in Toggles)
        {
            if (toggle.isOn == true)
            {
                togglesOn++;
                Debug.Log("togglesOn: " + togglesOn.ToString());
            }
        }

        if (togglesOn == 0)
        {
            startFromCustomModeButton.interactable = false;
        }
        else
        {
            startFromCustomModeButton.interactable = true;
        }
    }
}
