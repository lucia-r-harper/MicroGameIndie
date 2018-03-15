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
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                UpdateAbductionZone();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                ActivateAbductionMode();
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void UpdateAbductionZone()
    {
        //if the button is pressed, or if the game is already won (meaning the cow has been successfuly abducted
        if (Input.GetButton(ActivateAbductModeButton))
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
