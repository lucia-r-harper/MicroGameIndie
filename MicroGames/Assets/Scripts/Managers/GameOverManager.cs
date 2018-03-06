﻿using System;
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

    public void Restart()
    {
        SceneManager.LoadScene(TitleSceenScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
