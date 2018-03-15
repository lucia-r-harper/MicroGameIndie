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
    //private ConstantForce2D constantForce2D;
    //private Vector2 zeroForce = new Vector2(0, 0);

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        timer = FindObjectOfType<Timer>();
        heroFlySounds = GetComponent<HeroFlySounds>();
        //constantForce2D = GetComponent<ConstantForce2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                UpdateFlyUp();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                //constantForce2D.force = zeroForce;
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
        //UpdateFlyUp();
	}


    private void UpdateFlyUp()
    {
        playerRigidbody2D.constraints = RigidbodyConstraints2D.None;
        if (Input.GetButtonDown(FlyButton))
        {
            playerRigidbody2D.gravityScale = 0;
            playerRigidbody2D.AddForce(transform.up * FlyUpThrust);
            //transform.Translate(0, FlyUpThrust * Time.deltaTime, 0);
            heroFlySounds.PlayWhoosh();
        }
        else
        {
            playerRigidbody2D.gravityScale = 1;
        }
    }
}
