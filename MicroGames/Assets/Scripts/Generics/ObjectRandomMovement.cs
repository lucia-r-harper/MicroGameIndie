using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomMovement : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    protected float horizontalMovementValue;
    protected float verticalMovementValue;
    protected float speed;

	// Use this for initialization
	void Start ()
    {
        SetRandomMovementAndSpeed();
    }

    protected virtual void SetRandomMovementAndSpeed()
    {
        horizontalMovementValue = UnityEngine.Random.Range(-1.0f, 1.0f);
        verticalMovementValue = UnityEngine.Random.Range(-1.0f, 1.0f);
        Debug.Log("x:" + horizontalMovementValue + " y:" + verticalMovementValue);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    protected void MoveFixedUpdate()
    {
        transform.Translate(horizontalMovementValue * speed, verticalMovementValue * speed, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            if (Mathf.Abs(gameObject.transform.position.y) > Mathf.Abs(collision.bounds.extents.y))
            {
                verticalMovementValue *= -1;
            }

            if (Mathf.Abs(gameObject.transform.position.x) > Mathf.Abs(collision.bounds.extents.x))
            {
                horizontalMovementValue *= -1;
            }
        }
    }
}
