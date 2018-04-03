using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingTarget : MonoBehaviour
{
    private float speed = 0.15f;
    private float rotationspeed = 25f;
    private float difficultySpeedAdjustmentRate = 50;

    private Timer timer;

    private bool hasWon = false;

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
                //hasWon = true;
                break;
            default:
                break;
        }

        if (hasWon == true)
        {
            SpinOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border" && timer.MicroGameState != PlayingState.Won)
        {
            speed *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hasWon = true;
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
