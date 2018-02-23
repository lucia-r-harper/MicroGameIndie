using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlyHealth : MonoBehaviour
{
    private Timer timer;
    private ConstantForce2D constantForce2D;
    private Vector2 constantForce2DOnDeath = new Vector2(0, 0);
	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        constantForce2D = GetComponent<ConstantForce2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        timer.MicroGameState = PlayingState.Lost;
        constantForce2D.force = constantForce2DOnDeath;
    }
}
