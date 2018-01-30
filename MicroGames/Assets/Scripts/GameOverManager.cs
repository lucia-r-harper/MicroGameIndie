using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string TitleSceenScene;
	// Use this for initialization
	void Start ()
    {
        Destroy(GameObject.Find("MetaGame"));
        Destroy(GameObject.Find("ApplicationQuitter"));
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckToRestart();
	}

    private void CheckToRestart()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(TitleSceenScene);
        }
    }
}
