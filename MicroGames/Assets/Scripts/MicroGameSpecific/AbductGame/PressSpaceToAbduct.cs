using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToAbduct : MonoBehaviour
{
    public string ActivateAbductModeButton;
    private AbductionZone abductionZone;
    private PlayerMove playerMove;
    private float defaultMoveSpeed;
    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        playerMove = GetComponent<PlayerMove>();
        defaultMoveSpeed = playerMove.speed;
        abductionZone = GetComponentInChildren<AbductionZone>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if the button is pressed, or if the game is already won (meaning the cow has been successfuly abducted
        if (Input.GetButton(ActivateAbductModeButton) || timer.MicroGameState == PlayingState.Won)
        {
            ActivateAbductionMode();
        }
        else
        {
            DeactivateAbductionMode();
        }
	}
    private void ActivateAbductionMode()
    {
        abductionZone.Activate();
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                playerMove.speed = 0;
                break;
            case PlayingState.Lost:
                playerMove.speed = defaultMoveSpeed;
                break;
            case PlayingState.Won:
                playerMove.speed = defaultMoveSpeed;
                break;
            default:
                break;
        }
    }

    private void DeactivateAbductionMode()
    {
        abductionZone.Deactivate();
        playerMove.speed = defaultMoveSpeed;
    }

}
