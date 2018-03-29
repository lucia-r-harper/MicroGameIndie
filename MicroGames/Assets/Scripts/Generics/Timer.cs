﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayingState { Playing, Lost, Won, Starting, Ending}
//TO BE ATTACHED TO TIMER TEXT COMPONENT
public class Timer : MonoBehaviour
{
    public Sprite[] timerImages;
    public const int timeLimit = 5;
    private float timePassed = 0;
    public string newSceneToLoad = "testScene";

    private MetaGameManager metaGameManager;

    private int seconds;
    public int Seconds
    {
        get
        {
            return seconds;
        }
    }

    private Text timerText;
    private Image timerImage;
    private WaitForSeconds timeCountDownRate = new WaitForSeconds(1);

    private bool isCountingDown = true;
    private PlayingState microgameState = PlayingState.Playing;

    public PlayingState MicroGameState
    {
        get { return microgameState; }
        set
        {
            if (value == microgameState)
            {
                return;
            }
            microgameState = value;
            switch (microgameState)
            {
                case PlayingState.Playing:
                    StartCoroutine(CountDown());
                    break;
                case PlayingState.Lost:
                    MetaGameManager.LoseLife();
                    metaGameManager.ChangeColorOfText(Color.red, metaGameManager.LivesText);
                    //find better way to do this
                    microgameState = PlayingState.Ending;
                    break;
                case PlayingState.Won:
                    MetaGameManager.WinGame();
                    metaGameManager.ChangeColorOfText(Color.green, metaGameManager.ScoreText);
                    //find better way to do this
                    microgameState = PlayingState.Ending;
                    break;
                case PlayingState.Starting:
                    metaGameManager.ChangeColorOfText(Color.white, metaGameManager.ScoreText);
                    metaGameManager.ChangeColorOfText(Color.white, metaGameManager.LivesText);
                    break;
                case PlayingState.Ending:
                    break;
                default:
                    break;
            }
        }
    }

    private void Awake()
    {
        timerText = GetComponentInChildren<Text>();
        timerImage = GetComponentInChildren<Image>();
        metaGameManager = FindObjectOfType<MetaGameManager>();
    }

    // Use this for initialization
    void Start ()
    {
        MicroGameState = PlayingState.Starting;
        //DontDestroyOnLoad(this);
        seconds = timeLimit;
        //StartCoroutine(CountDown());
	}

    private IEnumerator CountDown()
    {
        yield return timeCountDownRate;
        while (microgameState == PlayingState.Playing)
        {
            yield return timeCountDownRate;
            seconds--;
        }
    }

    //private void CountDownSeconds()
    //{
    //    timePassed += Time.deltaTime;
    //    seconds -= (int)timePassed;
    //}

    // Update is called once per frame
    void Update ()
    {
        UpdateTimerText();
        UpdateTimerImage();
	}

    private void UpdateTimerImage()
    {
        if (seconds >= 0)
        {
            timerImage.sprite = timerImages[seconds];
        }
    }

    private void UpdateTimerText()
    {
        if (Time.timeScale == 0 && PauseManager.IsPaused == false)
        {
            timerText.text = "Press Space to Play";
        }
        else
        {

            switch (microgameState)
            {
                case PlayingState.Playing:
                    timerText.text = seconds.ToString();
                    break;
                case PlayingState.Lost:
                    timerText.text = "You lose!";
                    break;
                case PlayingState.Won:
                    timerText.text = "Finished!";
                    break;
                case PlayingState.Starting:
                    break;
                case PlayingState.Ending:
                    timerText.text = "Get ready!";
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayingState(PlayingState stateToChangeTo)
    {
        microgameState = stateToChangeTo;
    }
}
