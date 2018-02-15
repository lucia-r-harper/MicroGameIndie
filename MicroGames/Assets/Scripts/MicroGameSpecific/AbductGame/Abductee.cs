using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abductee : ObjectRandomMovement
{
    public float TimeUntilChangesMovement;

    private WaitForSeconds timeUntilChangesMovement;

    private float difficultySpeedAdjustmentScaling = 10;

	// Use this for initialization
	void Start ()
    {
        AdjustSpeedForDifficulty();
        timeUntilChangesMovement = new WaitForSeconds(TimeUntilChangesMovement);
        //SetRandomMovementAndSpeed();
        StartCoroutine(SetNewMovementBasedOnIntervalOfTime());
	}

    private void AdjustSpeedForDifficulty()
    {
        minSpeed += MetaGameManager.Difficulty/10;
        maxSpeed += MetaGameManager.Difficulty/10;
    }

    private IEnumerator SetNewMovementBasedOnIntervalOfTime()
    {
        while (true)
        {
            SetRandomMovementAndSpeed();
            yield return timeUntilChangesMovement;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }
}
