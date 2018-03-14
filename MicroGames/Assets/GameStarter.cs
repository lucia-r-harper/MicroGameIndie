using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    bool hasGameBeenStarted = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasGameBeenStarted == false && Input.GetButtonDown("Jump"))
        {
            StartGame();
        }
	}

    private void StartGame()
    {
        Time.timeScale = 1;
        hasGameBeenStarted = true;

    }
}
