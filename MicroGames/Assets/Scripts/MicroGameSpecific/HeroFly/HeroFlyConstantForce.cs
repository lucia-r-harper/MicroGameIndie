using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlyConstantForce : MonoBehaviour
{
    private ConstantForce2D constantForce2D;
    private const float difficultyScale = 50;
    private const float baseConstantForceX = 1;

    private Vector2 zeroForce;
    private Vector2 forwardForce;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        zeroForce = new Vector2(0, 0);
        forwardForce = new Vector2(baseConstantForceX + MetaGameManager.Difficulty / difficultyScale, 0);
        constantForce2D = GetComponent<ConstantForce2D>();
        StayStill();
    }

    private void Update()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                MoveForward();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                //StayStill();
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void StayStill()
    {
        constantForce2D.force = zeroForce;
    }

    private void MoveForward()
    {
        constantForce2D.force = forwardForce;
    }
}
