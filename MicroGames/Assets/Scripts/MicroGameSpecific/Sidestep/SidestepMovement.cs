using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidestepMovement : MonoBehaviour
{
    public float ForwardMovementSpeed;
    public float HorizontalMovementAmount = 1;
    public string HorizontalInput;

    private float horizontalInputValue;
    private const float horizontalLimit = 7.5f;
    private bool isDead = false;

	// Update is called once per frame
	void Update ()
    {
        if (isDead != true)
        {
            CheckForSidestepMovement();
        }
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
            if (horizontalInputValue > 0 && transform.position.x < horizontalLimit)
            {
                transform.Translate(HorizontalMovementAmount, 0, 0);
            }
            if (horizontalInputValue < 0 && transform.position.x > -horizontalLimit)
            {
                transform.Translate(-HorizontalMovementAmount, 0, 0);
            }
        }
        horizontalInputValue = 0;
    }

    private void MoveForward()
    {
        transform.Translate(0, ForwardMovementSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        ForwardMovementSpeed = 0;
        isDead = true;
    }
}
