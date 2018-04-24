using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject popUp;
    public GameObject ContinueButton;
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
    }
}
