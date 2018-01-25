using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public string VerticalInput;
    public string HorizontalInput;

    public float speed;

    private float verticalInputValue;
    private float horizontalInputValue;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMoveValues();
	}

    private void FixedUpdate()
    {
        UpdateMove();
    }

    private void UpdateMoveValues()
    {
        verticalInputValue = Input.GetAxis(VerticalInput);
        horizontalInputValue = Input.GetAxis(HorizontalInput);

        Debug.Log("Vertical Input:" + verticalInputValue);
        Debug.Log("Horizontal Input:" + horizontalInputValue);
    }

    private void UpdateMove()
    {
        transform.Translate(horizontalInputValue * speed, verticalInputValue * speed, 0);
    }
}
