﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDodgeMovementAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMove playerMove;
    private Timer timer;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
        timer = FindObjectOfType<Timer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (timer.MicroGameState != PlayingState.Lost)
        {
            if (Mathf.Abs(Input.GetAxis(playerMove.HorizontalInput)) > 0 || Mathf.Abs(Input.GetAxis(playerMove.VerticalInput)) > 0)
            {
                animator.SetBool("isplayerrunning", true);
            }
            else
            {
                animator.SetBool("isplayerrunning", false);
            }
        }
        else
        {
            animator.SetBool("isplayerdead", true);
            rigidBody.gravityScale = 1;
        }
    }
}