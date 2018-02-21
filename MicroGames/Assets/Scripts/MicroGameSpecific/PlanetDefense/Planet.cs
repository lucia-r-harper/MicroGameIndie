using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Meteor>() != null && timer.MicroGameState == PlayingState.Playing)
        {
            timer.MicroGameState = PlayingState.Lost;
        }
    }
}
