using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashSpaceToMove : PlayerMove
{
    private Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = GameObject.FindObjectOfType<Timer>();
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
        }
        else
        {
            horizontalInputValue = 0;
        }
    }
}
