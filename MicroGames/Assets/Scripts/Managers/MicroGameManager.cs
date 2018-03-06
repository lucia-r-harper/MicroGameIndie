using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MicroGameManager : MonoBehaviour
{
    public List<int> MicroGamesInPlayIndexes = new List<int>();
    public Toggle[] customMicroGameToggles = new Toggle[8];

    //used so when adding scenes that it skips the Main Menu and Game Over Scenes
    private const int sceneIntLocationBuffer = 2;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
	}

    public void AssignMicroGamesInPlay()
    {
        int i = 0;

        foreach (Toggle toggle in customMicroGameToggles)
        {
            if (toggle.isOn)
            {
                MicroGamesInPlayIndexes.Add(i + sceneIntLocationBuffer);
            }
            //better way to do this?
            i++;
        }
    }
}
