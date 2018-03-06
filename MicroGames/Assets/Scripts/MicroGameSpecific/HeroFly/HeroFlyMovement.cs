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
    private HeroFlySounds heroFlySounds;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        timer = FindObjectOfType<Timer>();
        heroFlySounds = GetComponent<HeroFlySounds>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateFlyUp();
	}


    private void UpdateFlyUp()
    {
        if (Input.GetButtonDown(FlyButton) && timer.MicroGameState == PlayingState.Playing)
        {
            playerRigidbody2D.AddForce(transform.up * FlyUpThrust);
            heroFlySounds.PlayWhoosh();
        }
    }
}
