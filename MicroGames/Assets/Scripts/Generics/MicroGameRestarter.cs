using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameRestarter : MonoBehaviour
{
    //public string newSceneToLoad = "testScene";

    private int firstMicrogame = 2;
    private int lastMicrogame = 8;

    private Timer currentTimer;

    private WaitForSeconds transitionDelay = new WaitForSeconds(1);
    
	// Use this for initialization
	void Start ()
    {
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
                //MetaGameManager.LoseLife();
                StartCoroutine(ChangeMicroGame());
                break;
            case PlayingState.Won:
                //MetaGameManager.WinGame();
                StartCoroutine(ChangeMicroGame());
                break;
            default:
                break;
        }
    }

    public IEnumerator ChangeMicroGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int microgameToLoad = UnityEngine.Random.Range(firstMicrogame, lastMicrogame);

        //if (microgameToLoad == currentScene)
        //{
        //    microgameToLoad = UnityEngine.Random.Range(firstMicrogame, lastMicrogame);
        //}
        while (microgameToLoad == currentScene)
        {
            microgameToLoad = UnityEngine.Random.Range(firstMicrogame, lastMicrogame);
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
        int microgameToLoad = UnityEngine.Random.Range(firstMicrogame, lastMicrogame);

        if (microgameToLoad == currentScene)
        {
            microgameToLoad = UnityEngine.Random.Range(firstMicrogame, lastMicrogame);
        }
        SceneManager.LoadScene(microgameToLoad);
    }
}
