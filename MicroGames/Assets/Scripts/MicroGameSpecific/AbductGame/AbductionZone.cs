using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionZone : MonoBehaviour
{
    private Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = GameObject.FindObjectOfType<Timer>();
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.tag == "abductee"
        if (collision.gameObject.GetComponent<Abductee>() != null)
        {
            Abudct(collision.gameObject);
        }
    }

    private void Abudct(GameObject abductee)
    {
        abductee.SetActive(false);
        timer.MicroGameState = PlayingState.Won;
    }
}
