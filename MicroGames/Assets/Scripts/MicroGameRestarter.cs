using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameRestarter : MonoBehaviour
{
    public string newSceneToLoad = "testScene";

    private Timer currentTimer;
	// Use this for initialization
	void Start ()
    {
        currentTimer = GameObject.FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateCheckToRestart();
	}

    private void UpdateCheckToRestart()
    {
        switch (currentTimer.MicroGameState)
        {
            case PlayingState.Playing:
                break;
            case PlayingState.Lost:
                if (Input.GetButton("Jump"))
                {
                    Restart();
                }
                break;
            case PlayingState.Won:
                if (Input.GetButton("Jump"))
                {
                    Restart();
                }
                break;
            default:
                break;
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(newSceneToLoad);
    }
}
