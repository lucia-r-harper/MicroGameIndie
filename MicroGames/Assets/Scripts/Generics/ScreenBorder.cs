using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach me to camera
[RequireComponent(typeof(BoxCollider2D))]
public class ScreenBorder : MonoBehaviour
{
    public string CameraName = "Main Camera";

    private Camera mainCamera;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        mainCamera = GameObject.Find(CameraName).GetComponent<Camera>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        CreateBoxColliderSize();
    }

    private void CreateBoxColliderSize()
    {
        boxCollider.size = new Vector2(mainCamera.rect.x, mainCamera.rect.y);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
