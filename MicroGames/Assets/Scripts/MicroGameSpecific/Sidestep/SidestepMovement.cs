using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidestepMovement : MonoBehaviour
{
    public float ForwardMovementSpeed;
    public int HorizontalMovementAmount = 1;
    public string HorizontalInput;

    private float horizontalInputValue;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckForSidestepMovement();
	}


    private void FixedUpdate()
    {
        MoveForward();
    }
    private void CheckForSidestepMovement()
    {
        if (Input.GetButtonDown(HorizontalInput))
        {
            horizontalInputValue = Input.GetAxis(HorizontalInput);
            if (horizontalInputValue > 0)
            {
                transform.Translate(HorizontalMovementAmount, 0, 0);
            }
            if (horizontalInputValue < 0)
            {
                transform.Translate(-HorizontalMovementAmount, 0, 0);
            }
        }
        else
        {
            horizontalInputValue = 0;
        }
    }

    private void MoveForward()
    {
        transform.Translate(0, ForwardMovementSpeed, 0);
    }
}
