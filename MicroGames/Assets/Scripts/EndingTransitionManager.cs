﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTransitionManager : MonoBehaviour
{
    public static bool hasTransitionPlayed = false;

    private TransitionAnimator[] transitionAnimators;
    Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        transitionAnimators = GameObject.FindObjectsOfType<TransitionAnimator>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckTimerToPlayTransition();
        CheckIfTheTransitionIsDonePlaying();
    }

    private void CheckTimerToPlayTransition()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                break;
            case PlayingState.Lost:
                ActivateLosingAnimationTransation();
                break;
            case PlayingState.Won:
                ActivateWinningAnimationTransition();
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void CheckIfTheTransitionIsDonePlaying()
    {
        if (hasTransitionPlayed == true)
        {
            timer.MicroGameState = PlayingState.Ending;
        }
    }

    //Override these functions depending on the microgame
    protected virtual void ActivateWinningAnimationTransition()
    {
        //background.sprite = winningBackground;
        //GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("didplayerwin", true);

        foreach (TransitionAnimator animatableObject in transitionAnimators)
        {
            animatableObject.SetToWinningAnimation();
        }

        timer.MicroGameState = PlayingState.Ending;
    }

    protected virtual void ActivateLosingAnimationTransation()
    {
        //background.sprite = losingBackground;

        foreach (TransitionAnimator animatableObject in transitionAnimators)
        {
            animatableObject.SetToLosingAnimation();
        }

        timer.MicroGameState = PlayingState.Ending;
    }
}
