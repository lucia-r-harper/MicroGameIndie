using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToAbduct : MonoBehaviour
{
    public string ActivateAbductModeButton;
    //public GameObject AbductionZone;
    private AbductionZone abductionZone;
    private PlayerMove playerMove;
    private float defaultMoveSpeed;
	// Use this for initialization
	void Start ()
    {
        playerMove = GetComponent<PlayerMove>();
        defaultMoveSpeed = playerMove.speed;
        abductionZone = GetComponentInChildren<AbductionZone>();
        abductionZone.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
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
        abductionZone.gameObject.SetActive(true);
        playerMove.speed = 0;
    }

    private void DeactivateAbductionMode()
    {
        abductionZone.gameObject.SetActive(false);
        playerMove.speed = defaultMoveSpeed;
    }

}
