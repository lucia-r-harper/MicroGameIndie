using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSateliteShooting : MonoBehaviour
{
    public string ShootButton;
    public SateliteShot SateliteShotPrefab;

	// Update is called once per frame
	void Update ()
    {
        CheckForShootButtonPressed();
	}

    private void CheckForShootButtonPressed()
    {
        if (Input.GetButtonDown(ShootButton))
        {
            ShootSateliteShot();
        }
    }

    private void ShootSateliteShot()
    {
        Instantiate(SateliteShotPrefab, transform.position, transform.rotation);
    }
}
