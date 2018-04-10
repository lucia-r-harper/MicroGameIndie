using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{

    public GameObject target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FollowTarget();
	}

    private void FollowTarget()
    {
        transform.position = target.transform.position;
    }
}
