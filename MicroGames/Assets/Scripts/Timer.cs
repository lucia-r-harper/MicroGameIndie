using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PlayingState { Playing, Lost, Won}
//TO BE ATTACHED TO TIMER TEXT COMPONENT
public class Timer : MonoBehaviour
{
    public int timeLimit;
    public string newSceneToLoad = "testScene";

    private int seconds;
    private Text timerText;
    private WaitForSeconds timeCountDownRate = new WaitForSeconds(1);

    private bool isCountingDown = true;
    private PlayingState microgameState = PlayingState.Playing;

    public PlayingState MicroGameState
    {
        get
        {
            return microgameState;
        }
    }

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    // Use this for initialization
    void Start ()
    {
        seconds = timeLimit;
        StartCoroutine(CountDown());
	}

    private IEnumerator CountDown()
    {
        while (microgameState == PlayingState.Playing)
        {
            yield return timeCountDownRate;
            seconds--;
            if (seconds == 0)
            {
                microgameState = PlayingState.Won;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateTimerText();
        //UpdateCheckToRestart();
	}


    private void UpdateTimerText()
    {
        //if (isCountingDown)
        //{
        //    timerText.text = seconds.ToString();
        //}
        //else
        //{
        //    timerText.text = "Finished!";
        //}
        switch (microgameState)
        {
            case PlayingState.Playing:
                timerText.text = seconds.ToString();
                break;
            case PlayingState.Lost:
                timerText.text = "You lose! Press space to restart";
                break;
            case PlayingState.Won:
                timerText.text = "Finished! Press space to restart";
                break;
            default:
                break;
        }
    }
    private void UpdateCheckToRestart()
    {
        switch (microgameState)
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

    public void ChangePlayingState(PlayingState stateToChangeTo)
    {
        microgameState = stateToChangeTo;
    }
}
