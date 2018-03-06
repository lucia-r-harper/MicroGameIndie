using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameRestarter : MonoBehaviour
{
    //public string newSceneToLoad = "testScene";
    
    private int firstMicrogame = 2;
    private int lastMicrogame = 10;

    private Timer currentTimer;
    //private Scene[] microGames;
    private List<int> availableMicroGames = new List<int>();

    private WaitForSeconds transitionDelay = new WaitForSeconds(1);
    
	// Use this for initialization
	void Start ()
    {
        //refactor me, I'm slow as all hell
        availableMicroGames = GameObject.FindObjectOfType<MicroGameManager>().MicroGamesInPlayIndexes;
        currentTimer = GameObject.FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentTimer != null)
        {
            UpdateCheckToRestart();
        }
	}

    private void UpdateCheckToRestart()
    {
        switch (currentTimer.MicroGameState)
        {
            case PlayingState.Playing:
                break;
            case PlayingState.Lost:
                StartCoroutine(ChangeMicroGame());
                break;
            case PlayingState.Won:
                StartCoroutine(ChangeMicroGame());
                break;
            default:
                break;
        }
    }

    public IEnumerator ChangeMicroGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        int microgameToLoad = availableMicroGames[UnityEngine.Random.Range(0, availableMicroGames.Count)];

        //precaution, if the microgame is the same, try again
        if (microgameToLoad == currentScene)
        {
            microgameToLoad = availableMicroGames[UnityEngine.Random.Range(0, availableMicroGames.Count)];
        }

        yield return transitionDelay;
        if (MetaGameManager.IsGameOver)
        {
            MetaGameManager.GameOver();
        }
        else
        {
            SceneManager.LoadScene(microgameToLoad);
        }
        yield return transitionDelay;
    }

    public void StartSession()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        int microgameToLoad = availableMicroGames[UnityEngine.Random.Range(0, availableMicroGames.Count)];

        if (microgameToLoad == currentScene)
        {
            microgameToLoad = availableMicroGames[UnityEngine.Random.Range(0, availableMicroGames.Count)];
        }
        SceneManager.LoadScene(microgameToLoad);
    }
}
