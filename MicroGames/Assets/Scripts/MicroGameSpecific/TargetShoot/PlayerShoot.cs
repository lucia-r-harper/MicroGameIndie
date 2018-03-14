using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public string shootingButton = "Jump";
    public GameObject shotFired;
    public int shotLimit = 1;
    private bool canShoot = false;
	// Update is called once per frame
	void Update ()
    {
        CheckForFireButton();
	}

    private void CheckForFireButton()
    {
        if (Input.GetButtonDown(shootingButton))
        {
            if (canShoot)
            {
                Shoot();
            }
            else
            {
                canShoot = true;
            }
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
