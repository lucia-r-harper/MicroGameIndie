using System;
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
        if (collision.gameObject.tag == ThingToAvoid && timer.MicroGameState == PlayingState.Playing)
        {
            Die();
        }
    }

    private void Die()
    {
        //timer.ChangePlayingState(PlayingState.Lost);
        timer.MicroGameState = PlayingState.Lost;
        gameObject.GetComponent<PlayerMove>().enabled = false;
    }
}