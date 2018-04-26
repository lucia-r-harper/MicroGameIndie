using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorShower : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        MouseManager.MouseState = MouseState.TitleScreen;
        //Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
