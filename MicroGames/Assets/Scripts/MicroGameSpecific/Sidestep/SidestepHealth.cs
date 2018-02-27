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
            Spinout();
        }
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        timer.MicroGameState = PlayingState.Lost;
        isDead = false;
    }
    private void Spinout()
    {

    }
}
