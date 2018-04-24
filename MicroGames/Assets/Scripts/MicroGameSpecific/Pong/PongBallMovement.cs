using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallMovement : ObjectRandomMovement
{
    public AudioSource bouncesound;
    private float difficultySpeedAdjustmentRate = 50;

    private Timer timer;

    // Use this for initialization
    void Start ()
    {
        timer = FindObjectOfType<Timer>();
        speed = 0.5f;
        SetRandomMovement();
        SetSpeedBasedOnDifficulty();
        //bouncesound = GetComponent<AudioSource>();

    }

    private void SetSpeedBasedOnDifficulty()
    {
        speed += MetaGameManager.Difficulty / difficultySpeedAdjustmentRate;
    }

    protected void SetRandomMovement()
    {
        horizontalMovementValue = UnityEngine.Random.Range(0, 1.0f);
        verticalMovementValue = UnityEngine.Random.Range(-1.0f, 1.0f);
        Debug.Log("x:" + horizontalMovementValue + " y:" + verticalMovementValue); 
    }

    private void FixedUpdate()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                MoveFixedUpdate();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bouncesound.Play();
            horizontalMovementValue *= -1;
        }
    }
}
