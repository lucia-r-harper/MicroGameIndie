using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public string shootingButton = "Jump";
    public GameObject shotFired;
    public int shotLimit = 1;

    private Timer timer;
    //private bool canShoot = false;
    // Update is called once per frame

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    void Update ()
    {
        CheckForFireButton();
	}

    private void CheckForFireButton()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                UpdateToShoot();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void UpdateToShoot()
    {
        if (Input.GetButtonDown(shootingButton))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (shotLimit > 0)
        {
            Debug.Log("I have shot a bullet!");
            Instantiate(shotFired, this.transform.position, this.transform.rotation);
        }
        else
        {
            Debug.Log("No more bullets to shoot!!!");
        }
        shotLimit--;
    }
}
