using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameManager : MonoBehaviour
{
    public List<string> microGameLevelNames = new List<string>();
    private List<Scene> microGameLevels = new List<Scene>();
    private List<Scene> discardedMicroGameLevels = new List<Scene>();

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
        PopulateMicroGameLevelsList();
	}

    private void PopulateMicroGameLevelsList()
    {
        foreach (string microGameLevelName in microGameLevelNames)
        {
            microGameLevels.Add(SceneManager.GetSceneByName(microGameLevelName));
        }
    }

    public void PickRandomMicroGame()
    {
        int microgameToLoad = UnityEngine.Random.Range(0, microGameLevels.Count);
        SceneManager.LoadScene(microgameToLoad);
        DiscardLevel(microgameToLoad);
    }

    private void DiscardLevel(int microgameToDiscard)
    {
        microGameLevels.Remove(SceneManager.GetSceneAt(microgameToDiscard));
        discardedMicroGameLevels.Add(SceneManager.GetSceneAt(microgameToDiscard));
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
