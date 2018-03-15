using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidestepHealth : MonoBehaviour
{
    private bool isDead;
    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        isDead = true;
        timer = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isDead)
        {
        }
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                Die();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }


    private void Die()
    {
        timer.MicroGameState = PlayingState.Lost;
        isDead = false;
    }
}
