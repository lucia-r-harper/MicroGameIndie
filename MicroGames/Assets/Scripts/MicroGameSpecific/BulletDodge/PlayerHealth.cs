using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public string ThingToAvoid;
    public Timer timer;

    private Animator animator;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
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
        timer.MicroGameState = PlayingState.Lost;
        gameObject.GetComponent<PlayerMove>().enabled = false;

        animator.SetBool("isplayerdead", true);
        rigidBody.gravityScale = 1;
    }
}