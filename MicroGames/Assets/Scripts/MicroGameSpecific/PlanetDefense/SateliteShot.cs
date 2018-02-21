using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteShot : MonoBehaviour
{
    private int speed = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0.0f, speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Meteor>() != null)
        {
            Meteor meteorCollidedWith = collision.GetComponent<Meteor>();
            meteorCollidedWith.BlowUp();
        }
    }
}
