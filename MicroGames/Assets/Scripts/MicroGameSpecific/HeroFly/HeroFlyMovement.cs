using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlyMovement : MonoBehaviour
{
    public string FlyButton = "Jump";
    public float FlyUpThrust;
    //public float FlyForwardMovement;

    private Rigidbody2D playerRigidbody2D;
    private Vector2 flyForwardVector2;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        timer = FindObjectOfType<Timer>();
        //flyForwardVector2 = new Vector2(FlyForwardMovement, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateFlyUp();
	}

    private void FixedUpdate()
    {
        FlyForward();
    }


    private void UpdateFlyUp()
    {
        if (Input.GetButtonDown(FlyButton) && timer.MicroGameState == PlayingState.Playing)
        {
            playerRigidbody2D.AddForce(transform.up * FlyUpThrust);
        }
    }
    private void FlyForward()
    {
        //playerRigidbody2D.AddForce(transform.right * FlyForwardMovement);
        //playerRigidbody2D.MovePosition(playerRigidbody2D.position + flyForwardVector2);
    }
}
