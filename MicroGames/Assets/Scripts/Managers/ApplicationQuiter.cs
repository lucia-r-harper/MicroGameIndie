using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuiter : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
	}

    public void Quit()
    {
        Application.Quit();
    }
}
