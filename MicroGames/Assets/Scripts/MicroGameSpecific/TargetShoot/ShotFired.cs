﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFired : MonoBehaviour
{
    private int speed = 1;
    private Timer timer;

    // Use this for initialization
    void Start ()
    {
        timer = GameObject.FindObjectOfType<Timer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void FixedUpdate()
    {
        ShootUp();
    }

    private void ShootUp()
    {
        transform.Translate(0.0f, speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "gamelosstrigger")
        {
            //currentTimer.ChangePlayingState(PlayingState.Lost);
            timer.MicroGameState = PlayingState.Lost;
        }
    }

    private void OnDestroy()
    {
        timer.MicroGameState = PlayingState.Won;
    }
}
