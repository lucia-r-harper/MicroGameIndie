using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashSpaceToMove : PlayerMove
{
    private Timer timer;
    private float difficultySpeedAdjustmentRate = 50;
    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        speed -= MetaGameManager.Difficulty / difficultySpeedAdjustmentRate;
        timer = GameObject.FindObjectOfType<Timer>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMoveValues();
	}

    protected override void UpdateMoveValues()
    {
        if (Input.GetButtonDown(HorizontalInput) && timer.MicroGameState == PlayingState.Playing)
        {
            horizontalInputValue = speed;
            audioSource.Play();
        }
        else
        {
            horizontalInputValue = 0;
        }
    }
}
