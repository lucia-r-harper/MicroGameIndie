using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameRestarter : MonoBehaviour
{
    public string newSceneToLoad = "testScene";

    private int firstMicrogame = 2;
    private int lastMicrogame = 3;

    private Timer currentTimer;
	// Use this for initialization
	void Start ()
    {
        currentTimer = GameObject.FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentTimer != null)
        {
            UpdateCheckToRestart();
        }
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
                    ChangeMicroGame();
                }
                break;
            case PlayingState.Won:
                if (Input.GetButton("Jump"))
                {
                    ChangeMicroGame();
                }
                break;
            default:
                break;
        }
    }

    public void ChangeMicroGame()
    {
        int microgameToLoad = UnityEngine.Random.Range(firstMicrogame, lastMicrogame);
        SceneManager.LoadScene(microgameToLoad);
    }
}
