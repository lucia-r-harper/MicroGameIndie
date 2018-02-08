﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for games where the win condition is to outlast the time limit
public class TimerChecker : MonoBehaviour
{
    public enum TimerCheckerMode { WinWhenTimeIsUp, LoseWhenTimeIsUp};
    public TimerCheckerMode timerCheckerMode;
    private Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChangeMicroGameWinStateToWin();
	}

    private void ChangeMicroGameWinStateToWin()
    {
        if (timer.Seconds == 0 && timer.MicroGameState == PlayingState.Playing)
        {
            switch (timerCheckerMode)
            {
                case TimerCheckerMode.WinWhenTimeIsUp:
                    timer.MicroGameState = PlayingState.Won;
                    break;
                case TimerCheckerMode.LoseWhenTimeIsUp:
                    timer.MicroGameState = PlayingState.Lost;
                    break;
                default:
                    break;
            }
        }
    }
}
