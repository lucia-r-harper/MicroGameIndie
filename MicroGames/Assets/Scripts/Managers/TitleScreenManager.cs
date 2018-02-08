using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public List<GameObject> MainMenuPanels = new List<GameObject>();
    public GameObject metaGameManager;
    private EventSystem eventSystem;

    // Use this for initialization
    void Start ()
    {
        eventSystem = FindObjectOfType<EventSystem>();
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
        eventSystem.SetSelectedGameObject(panelToChangeTo.GetComponentInChildren<Button>().gameObject);
    }

    private void DeactivateAllPanels()
    {
        foreach (GameObject panel in MainMenuPanels)
        {
            panel.SetActive(false);
        }
    }
}
