using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abductee : ObjectRandomMovement
{
    public float TimeUntilChangesMovement;

    private WaitForSeconds timeUntilChangesMovement;

    private float difficultySpeedAdjustmentScaling = 25;

    private bool isAbducted;

    private AudioSource audioSource;

    private const int abductionRotationSpeed = 20;

	// Use this for initialization
	void Start ()
    {
        isAbducted = false;
        audioSource = GetComponent<AudioSource>();
        minSpeed = 0.05f;
        maxSpeed = 0.1f;
        AdjustSpeedForDifficulty();
        timeUntilChangesMovement = new WaitForSeconds(TimeUntilChangesMovement);
        StartCoroutine(SetNewMovementBasedOnIntervalOfTime());
	}

    private void AdjustSpeedForDifficulty()
    {
        minSpeed += (MetaGameManager.Difficulty/ difficultySpeedAdjustmentScaling);
        maxSpeed += (MetaGameManager.Difficulty/ difficultySpeedAdjustmentScaling);
    }

    private IEnumerator SetNewMovementBasedOnIntervalOfTime()
    {
        while (isAbducted == false)
        {
            SetRandomMovementAndSpeed();
            yield return timeUntilChangesMovement;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (isAbducted == true)
        {
            RotateWhileAbducted();
        }
	}


    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    public void GetAbducted(Transform AZParentToSet)
    {
        isAbducted = true;
        speed = 0;
        audioSource.Play();
        transform.SetParent(AZParentToSet);
        transform.localPosition = new Vector3(0, 0, 0);
    }

    private void RotateWhileAbducted()
    {
        transform.Rotate(transform.forward, abductionRotationSpeed);
    }
}
