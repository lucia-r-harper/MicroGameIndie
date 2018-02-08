using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionZone : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "abductee")
        {
            Abudct(collision.gameObject);
        }
    }

    private void Abudct(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
