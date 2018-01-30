using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public List<GameObject> MainMenuPanels = new List<GameObject>();
    public GameObject metaGameManager;

    // Use this for initialization
    void Start ()
    {
        metaGameManager.SetActive(false);
        DisableAllPanelsExceptForTitle();
	}

    private void DisableAllPanelsExceptForTitle()
    {
        DeactivateAllPanels();
        MainMenuPanels[0].SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void ActivateMetagame()
    {
        metaGameManager.SetActive(true);
    }

    public void ChangePanel(GameObject panelToChangeTo)
    {
        DeactivateAllPanels();
        panelToChangeTo.SetActive(true);
    }

    private void DeactivateAllPanels()
    {
        foreach (GameObject panel in MainMenuPanels)
        {
            panel.SetActive(false);
        }
    }
}
