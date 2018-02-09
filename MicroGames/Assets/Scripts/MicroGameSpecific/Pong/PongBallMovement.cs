using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallMovement : ObjectRandomMovement
{
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        SetRandomMovementAndSpeed();
        audioSource = GetComponent<AudioSource>();

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
            audioSource.Play();
            horizontalMovementValue *= -1;
        }
    }
}
