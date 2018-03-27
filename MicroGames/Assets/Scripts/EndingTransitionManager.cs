using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTransitionManager : MonoBehaviour
{
    public static bool hasTransitionPlayed = false;
    public SpriteRenderer background;

    public Sprite winningBackground;
    public Sprite losingBackground;

    Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
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
        background.sprite = winningBackground;
        timer.MicroGameState = PlayingState.Ending;
    }

    protected virtual void ActivateLosingAnimationTransation()
    {
        background.sprite = losingBackground;
        timer.MicroGameState = PlayingState.Ending;
    }
}
