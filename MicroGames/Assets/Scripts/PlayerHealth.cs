﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public string ThingToAvoid;
    public Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ThingToAvoid)
        {
            Die();
        }
    }

    private void Die()
    {
        timer.ChangePlayingState(PlayingState.Lost);
    }
}
