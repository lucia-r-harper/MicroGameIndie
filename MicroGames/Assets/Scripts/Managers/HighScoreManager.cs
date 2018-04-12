using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    //figure me out with XML so people can't just hack into it, unless the resource folder is restricted then just use a .txt file because that's all you need
    private int highScore;
    private int sessionScore;

	// Use this for initialization
	void Start ()
    {
        GetCurrentSessionScore();
        GetHighScore();
        SetHighScore();
	}

    private void GetHighScore()
    {
        //read from a file, written out by this scripts
    }

    private void SetHighScore()
    {
        if (sessionScore > highScore)
        {

        }
    }

    private void GetCurrentSessionScore()
    {
        sessionScore = MetaGameManager.Score;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
