using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    private PongBallMovement pongBall;
	// Use this for initialization

	void Start ()
    {
        pongBall = GameObject.FindObjectOfType<PongBallMovement>();
	}
	
    private void FixedUpdate()
    {
        FollowPongBall();
    }

    private void FollowPongBall()
    {
        transform.position = new Vector3(transform.position.x, pongBall.transform.position.y);
    }
}
