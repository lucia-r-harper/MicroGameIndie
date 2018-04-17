using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    //figure me out with XML so people can't just hack into it, unless the resource folder is restricted then just use a .txt file because that's all you need
    private int highScore = 0;
    private int sessionScore;

    //Fix the path for this so it writes to the right location
    private string path = "_saveData/";

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
            highScore = sessionScore;
            Debug.Log("New high score!!!");

            XmlSerializer serializer = new XmlSerializer(typeof(int));
            FileStream stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, highScore);
            stream.Close();
        }
    }

    private void GetCurrentSessionScore()
    {
        sessionScore = MetaGameManager.Score;
        Debug.Log(sessionScore.ToString());
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
