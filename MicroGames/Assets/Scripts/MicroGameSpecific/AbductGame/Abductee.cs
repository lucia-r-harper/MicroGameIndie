using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abductee : ObjectRandomMovement
{
    public float TimeUntilChangesMovement;

    private WaitForSeconds timeUntilChangesMovement;

	// Use this for initialization
	void Start ()
    {
        timeUntilChangesMovement = new WaitForSeconds(TimeUntilChangesMovement);
        //SetRandomMovementAndSpeed();
        StartCoroutine(SetNewMovementBasedOnIntervalOfTime());
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
