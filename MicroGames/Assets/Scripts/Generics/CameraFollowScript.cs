using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public enum FollowMode { FollowX, FollowY};
    public FollowMode CameraFollowMode;
    public GameObject target;
    public float followDistance;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FollowTarget();
	}

    private void FollowTarget()
    {
        switch (CameraFollowMode)
        {
            case FollowMode.FollowX:
                transform.position = new Vector3(target.transform.position.x + followDistance, 0, -10);
                break;
            case FollowMode.FollowY:
                transform.position = new Vector3(0, target.transform.position.y + followDistance, -10);
                break;
            default:
                break;
        }
    }
}
