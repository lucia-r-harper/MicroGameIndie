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
        MouseManager.MouseState = MouseState.GameOver;
    }

    private static void DestroyMetaGameObjects()
    {
        Destroy(GameObject.Find("MetaGame"));
        Destroy(GameObject.Find("MicroGameManager"));
        Destroy(GameObject.Find("ApplicationQuitter"));
    }

    public void Restart()
    {
        SceneManager.LoadScene(TitleSceenScene);
        DestroyMetaGameObjects();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
