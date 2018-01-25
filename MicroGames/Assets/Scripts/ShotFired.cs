﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFired : MonoBehaviour
{
    private int speed = 1;
    private Timer currentTimer;

    // Use this for initialization
    void Start ()
    {
        currentTimer = GameObject.FindObjectOfType<Timer>();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            currentTimer.ChangePlayingState(PlayingState.Lost);
        }
    }
}
