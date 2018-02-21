using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Transform target;
    private float speed = 0.75f;
    public Transform Target
    {
        set
        {
            target = value;
        }
    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
	}

    public void BlowUp()
    {
        gameObject.SetActive(false);
    }
}
