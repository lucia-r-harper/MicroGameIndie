using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MicroGameManager : MonoBehaviour
{
    public List<Scene> MicroGamesInPlay = new List<Scene>();
    private Toggle[] customMicroGameToggles = new Toggle[8];
    //figure out how to watch me!
    private List<Scene> microGameLevels = new List<Scene>();
    private List<Scene> discardedMicroGameLevels = new List<Scene>();

    //used so when adding scenes that it skips the Main Menu and Game Over Scenes
    private const int sceneIntLocationBuffer = 2;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
        customMicroGameToggles = FindObjectsOfType<Toggle>();
        //PopulateMicroGameLevelsList();
	}

    //private void PopulateMicroGameLevelsList()
    //{
    //    foreach (string microGameLevelName in microGameLevelNames)
    //    {
    //        microGameLevels.Add(SceneManager.GetSceneByName(microGameLevelName));
    //    }
    //}

    //public void PickRandomMicroGame()
    //{
    //    int microgameToLoad = UnityEngine.Random.Range(0, microGameLevels.Count);
    //    SceneManager.LoadScene(microgameToLoad);
    //    DiscardLevel(microgameToLoad);
    //}

    //private void DiscardLevel(int microgameToDiscard)
    //{
    //    microGameLevels.Remove(SceneManager.GetSceneAt(microgameToDiscard));
    //    discardedMicroGameLevels.Add(SceneManager.GetSceneAt(microgameToDiscard));
    //}

    public void AssignMicroGamesInPlay()
    {
        int i = 0;

        foreach (Toggle toggle in customMicroGameToggles)
        {
            //better way to do this?
            i++;
            if (toggle.isOn)
            {
                MicroGamesInPlay.Add(SceneManager.GetSceneAt(i));
            }
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
		
	}
}
