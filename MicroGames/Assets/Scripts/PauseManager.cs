using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject popUp;
    public GameObject ContinueButton;

    private bool isAtGameOverScene = false;
	// Use this for initialization
	void Start ()
    {
        
	}

    private void OnEnable()
    {
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        HandlePauseState();
        DisablePauseOnGameOverScene();
        HandleHideCursor();
    }


    private void HandlePauseState()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (IsPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
        if (isAtGameOverScene == true)
        {
            UnPause();
        }
    }
    private void DisablePauseOnGameOverScene()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOverScene"))
        {
            isAtGameOverScene = true;
        }
    }

    private void HandleHideCursor()
    {
        if (isAtGameOverScene == false)
        {
            if (popUp.activeInHierarchy == true)
            {
                //Cursor.visible = true;
                MouseManager.MouseState = MouseState.Paused;
            }
            else
            {
                //Cursor.visible = false;
                MouseManager.MouseState = MouseState.Upnaused;
            }
        }
    }

    public void UnPause()
    {
        IsPaused = false;
        popUp.SetActive(false);
        Time.timeScale = 1;
    }

    private void Pause()
    {
        IsPaused = true;
        //Debug.Log(IsPaused);
        popUp.SetActive(true);
        Time.timeScale = 0;
        //FindObjectOfType<EventSystem>().SetSelectedGameObject(ContinueButton);
        Cursor.visible = true;
    }
}
