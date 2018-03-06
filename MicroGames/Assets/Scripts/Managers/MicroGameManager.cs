using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MicroGameManager : MonoBehaviour
{
    //public List<Scene> MicroGamesInPlay = new List<Scene>();
    public List<int> MicroGamesInPlayIndexes = new List<int>();
    public Toggle[] customMicroGameToggles = new Toggle[8];
    //figure out how to watch me!
    private List<Scene> microGameLevels = new List<Scene>();
    private List<Scene> discardedMicroGameLevels = new List<Scene>();

    //used so when adding scenes that it skips the Main Menu and Game Over Scenes
    private const int sceneIntLocationBuffer = 2;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
        //customMicroGameToggles = FindObjectsOfType<Toggle>();
        //PopulateMicroGameLevelsList();
	}

    public void AssignMicroGamesInPlay()
    {
        int i = 0;

        foreach (Toggle toggle in customMicroGameToggles)
        {
            if (toggle.isOn)
            {
                //Debug.Log(SceneManager.sceneCount);
                MicroGamesInPlayIndexes.Add(i + sceneIntLocationBuffer);
            }
            //better way to do this?
            i++;
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
		
	}
}
