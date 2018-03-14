using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSateliteMovement : MonoBehaviour
{
    public string MovementInput;
    public float MovementSpeed;

    private Planet planet;
    private Timer timer;

    private float movementInputValue;
	// Use this for initialization
	void Start ()
    {
        planet = FindObjectOfType<Planet>();
        timer = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                UpdateMovementValues();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                MoveAroundPlanet();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            default:
                break;
        }
    }

    private void MoveAroundPlanet()
    {
        transform.RotateAround(planet.transform.position, planet.transform.forward, MovementSpeed * movementInputValue);
    }

    private void UpdateMovementValues()
    {
        //movementInputValue = 0;

        movementInputValue = (Input.GetAxis(MovementInput)) * -1;
    }
}
