using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MetaGameManager : MonoBehaviour
{
    private static int score = 0;
    public static int Score
    {
        get
        {
            return score;
        }
    }
    private static int lives = 3;

    public Text ScoreText;
    public Text LivesText;
    private static string GameOverScene = "GameOverScene";

    private static int difficultyScale = 3;
    public static int Difficulty
    {
        get
        {
            return score / difficultyScale;
        }
    }

    public static bool IsGameOver
    {
        get
        {
            if (lives <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void ChangeColorOfText(Color newColor, Text textToChange)
    {
        textToChange.color = newColor;
    }

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this);
        resetLivesAndScore();
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
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(GameOverScene);
    }

    private static void resetLivesAndScore()
    {
        score = 0;
        lives = 3;
    }

    public void Destroy()
    {
        Destroy(GetComponent<MetaGameManager>().gameObject);
    }
}
