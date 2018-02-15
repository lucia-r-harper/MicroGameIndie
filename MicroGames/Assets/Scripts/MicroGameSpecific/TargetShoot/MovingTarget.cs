using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingTarget : MonoBehaviour
{
    private float speed = 0.25f;
    private float rotationspeed = 25f;
    private float difficultySpeedAdjustmentRate = 20;

    private Timer timer;


	// Use this for initialization
	void Start ()
    {
        AdjustSpeedBasedOnDifficulty();
        timer = GameObject.FindObjectOfType<Timer>();
	}

    private void AdjustSpeedBasedOnDifficulty()
    {
        speed += MetaGameManager.Difficulty / difficultySpeedAdjustmentRate;
    }

    // Update is called once per frame
    void Update ()
    {
        
	}

    private void FixedUpdate()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                MoveLeftToRight();
                break;
            case PlayingState.Lost:
                MoveLeftToRight();
                break;
            case PlayingState.Won:
                SpinOut();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border" && timer.MicroGameState != PlayingState.Won)
        {
            speed *= -1;
        }
    }

    private void MoveLeftToRight()
    {
        transform.Translate(speed, 0, 0);
    }

    private void SpinOut()
    {
        transform.Rotate(0, 0, rotationspeed);
        transform.Translate(0, Mathf.Abs(speed), 0, Space.World);

        if (transform.localScale.x > 0 && transform.localScale.y > 0)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
}
