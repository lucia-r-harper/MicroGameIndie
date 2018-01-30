using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MetaGameManager : MonoBehaviour
{
    private static int score = 0;
    private static int lives = 3;

    public Text ScoreText;
    public Text LivesText;
    private static string GameOverScene = "GameOverScene";

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateText();
	}

    private void UpdateText()
    {
        ScoreText.text = "Score: " + score.ToString();
        LivesText.text = "Lives: " + lives.ToString();
    }

    public static void WinGame()
    {
        score++;
    }

    public static void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    private static void GameOver()
    {
        resetLivesAndScore();
        SceneManager.LoadScene(GameOverScene);
    }

    private static void resetLivesAndScore()
    {
        score = 0;
        lives = 3;
    }
}
