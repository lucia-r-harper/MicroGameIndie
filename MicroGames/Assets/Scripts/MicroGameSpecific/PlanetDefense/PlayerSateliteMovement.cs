using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSateliteMovement : MonoBehaviour
{
    public string MovementInput;
    public float MovementSpeed;

    private Planet planet;

    private float movementInputValue;
	// Use this for initialization
	void Start ()
    {
        planet = FindObjectOfType<Planet>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMovementValues();
	}

    private void FixedUpdate()
    {
        MoveAroundPlanet();
    }

    private void MoveAroundPlanet()
    {
        transform.RotateAround(planet.transform.position, planet.transform.forward, MovementSpeed * movementInputValue);
    }

    private void UpdateMovementValues()
    {
        //negative one multiplier added so it rotates clockwise around the planet
        movementInputValue = (Input.GetAxis(MovementInput)) * -1;
    }
}
