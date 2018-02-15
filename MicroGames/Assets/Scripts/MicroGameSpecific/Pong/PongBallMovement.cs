using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallMovement : ObjectRandomMovement
{
    private AudioSource audioSource;
    private float difficultySpeedAdjustmentRate = 20;
    // Use this for initialization
    void Start ()
    {
        speed = 0.5f;
        SetRandomMovement();
        SetSpeedBasedOnDifficulty();
        audioSource = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update ()
    {
		
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
        MoveFixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            horizontalMovementValue *= -1;
        }
    }
}
