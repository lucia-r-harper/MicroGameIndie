using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text HighScoreText;
    public Animator HighScoreNotificationAnimator;

    private int highScore = 0;
    private int sessionScore;

    //Fix the path for this so it writes to the right location
    private string path;

    // Use this for initialization
    void Start ()
    {
        CheckForDirectoryAndFileExistance();

        SetDataPath();

        GetCurrentSessionScore();
        GetHighScore();
        CheckForNewHighScore();
    }

    private void CheckForDirectoryAndFileExistance()
    {
        //Checks to see if directory doesn't exists, creates it.
        if (!Directory.Exists(Application.dataPath + "/_saveData"))
        {
            Directory.CreateDirectory(Application.dataPath + "/_saveData");
            SetDataPath();
            SetNewHighScore();
        }
        else
        {
            SetDataPath();
        }
        //Checks to see if file doesn't exist in the directory
        if (!File.Exists(Path.Combine(path, "saveData.xml")))
        {
            SetDataPath();
            SetNewHighScore();
        }
    }

    private void GetHighScore()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(int));
        FileStream stream = new FileStream(Path.Combine(path, "saveData.xml"), FileMode.Open);
        highScore = (int)serializer.Deserialize(stream);
        stream.Close();
        UpdateHighScoreText();
    }


    private void CheckForNewHighScore()
    {
        if (sessionScore > highScore)
        {
            highScore = sessionScore;
            HighScoreNotificationAnimator.SetBool("newhighscore", true);
            Debug.Log("New high score!!!");
            SetNewHighScore();

            UpdateHighScoreText();
        }
    }

    private void SetNewHighScore()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(int));
        FileStream stream = new FileStream(Path.Combine(path, "saveData.xml"), FileMode.Create);
        serializer.Serialize(stream, highScore);
        stream.Close();
    }

    private void SetDataPath()
    {
        path = Application.dataPath + "/_saveData";
    }

    private void UpdateHighScoreText()
    {
        HighScoreText.text = "High Score: " + highScore.ToString();
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
