using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallMovement : ObjectRandomMovement
{

	// Use this for initialization
	void Start ()
    {
        SetRandomMovementAndSpeed();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected override void SetRandomMovementAndSpeed()
    {
        horizontalMovementValue = UnityEngine.Random.Range(0, 1.0f);
        verticalMovementValue = UnityEngine.Random.Range(-1.0f, 1.0f);
        Debug.Log("x:" + horizontalMovementValue + " y:" + verticalMovementValue);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            horizontalMovementValue *= -1;
        }
    }
}
