using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public string VerticalInput;
    public string HorizontalInput;

    public float speed;

    protected float verticalInputValue;
    protected float horizontalInputValue;

    SpriteRenderer spriteRenderer;

    Timer timer;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                UpdateMoveValues();
                break;
            case PlayingState.Lost:
                zeroOutUpdateValues();
                break;
            case PlayingState.Won:
                zeroOutUpdateValues();
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                zeroOutUpdateValues();
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        UpdateMove();
        if (spriteRenderer != null)
        {
            OrientBasedOnDirection();
        }
    }

    private void OrientBasedOnDirection()
    {
        if (horizontalInputValue < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontalInputValue > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    protected virtual void UpdateMoveValues()
    {
        verticalInputValue = Input.GetAxis(VerticalInput);
        horizontalInputValue = Input.GetAxis(HorizontalInput);

        Debug.Log("Vertical Input:" + verticalInputValue);
        Debug.Log("Horizontal Input:" + horizontalInputValue);
    }

    protected virtual void zeroOutUpdateValues()
    {
        verticalInputValue = 0;
        horizontalInputValue = 0;
    }

    private void UpdateMove()
    {
        transform.Translate(horizontalInputValue * speed, verticalInputValue * speed, 0);
        RestrictMovementWithinScreenBoundaries();
    }

    private void RestrictMovementWithinScreenBoundaries()
    {
        #region BindXAxisMovement
        if (transform.position.x <= -8.875)
        {
            transform.position = new Vector3(-8.875f, transform.position.y);
        }
        else if (transform.position.x >= 8.875)
        {
            transform.position = new Vector3(8.875f, transform.position.y);
        }
        #endregion

        #region BindYAxisMovement
        if (transform.position.y <= -5)
        {
            transform.position = new Vector3(transform.position.x, -5);
        }
        else if (transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5);
        }
        #endregion
    }
}
