using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to GameObject with Camera component
public class CameraFollowScript : MonoBehaviour
{
    public enum FollowMode { FollowX, FollowY};
    public FollowMode CameraFollowMode;
    public GameObject target;
    public float followDistance;

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
