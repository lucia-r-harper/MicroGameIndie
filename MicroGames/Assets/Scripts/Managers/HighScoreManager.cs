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

    //public Text HighScoreText;
    public Animator HighScoreNotificationAnimator;
    public Text[] HighScoreTextArray;
    public InputField inputField;

    private int sessionHighScore = 0;
    private int[] highScoreInts = new int[5];
    private string[] highScoreNames = new string[5];
    private int sessionScore;
    int newHighScoreLocation = 0;

    //Fix the path for this so it writes to the right location
    private string path;

    // Use this for initialization
    void Start ()
    {
        inputField.gameObject.SetActive(false);

        CheckForDirectoryAndFileExistance();

        SetDataPath();

        GetCurrentSessionScore();
        GetHighScore();
        CheckForNewHighScore();
    }

    private void CheckForDirectoryAndFileExistance()
    {
        #region oldSystem
        ////Checks to see if directory doesn't exists, creates it.
        //if (!Directory.Exists(Application.dataPath + "/_saveData"))
        //{
        //    Directory.CreateDirectory(Application.dataPath + "/_saveData");
        //    SetDataPath();
        //    SetNewHighScore();
        //}
        //else
        //{
        //    SetDataPath();
        //}
        ////Checks to see if file doesn't exist in the directory
        //if (!File.Exists(Path.Combine(path, "saveData.xml")))
        //{
        //    SetDataPath();
        //    SetNewHighScore();
        //}
        #endregion
        //Checks to see if directory doesn't exists, creates it.
        if (!Directory.Exists(Application.dataPath + "/_saveData"))
        {
            Directory.CreateDirectory(Application.dataPath + "/_saveData");
            SetDataPath();
            SetDefaultHighScore();
            SetDefaultHighScoreNames();
        }
        else
        {
            SetDataPath();
        }
        //Checks to see if file doesn't exist in the directory
        if (!File.Exists(Path.Combine(path, "topScores.xml")))
        {
            SetDataPath();
            SetDefaultHighScore();
        }
        if (!File.Exists(Path.Combine(path, "topNames.xml")))
        {
            SetDataPath();
            SetDefaultHighScoreNames();
        }
    }

    private void GetHighScore()
    {
        XmlSerializer scoreSerializer = new XmlSerializer(typeof(int[]));
        XmlSerializer namesSerializer = new XmlSerializer(typeof(string[]));
        FileStream scoreStream = new FileStream(Path.Combine(path, "topScores.xml"), FileMode.Open);
        FileStream namesStream = new FileStream(Path.Combine(path, "topNames.xml"), FileMode.Open);
        highScoreInts = (int[])scoreSerializer.Deserialize(scoreStream);
        highScoreNames = (string[])namesSerializer.Deserialize(namesStream);
        scoreStream.Close();
        namesStream.Close();
        UpdateHighScoreText();
    }


    private void CheckForNewHighScore()
    {

        int[] newHighScoreArray = new int[5];
        string[] newNamesArray = new string[5];
        bool newHighScoreFound = false;
        int newHighScoreBuffer = 1;


        for (int i = 0; i < highScoreInts.Length; i++)
        {
            //checks if the session score is viable for a new highscore and the new highscore hasn't been found yet
            if (sessionScore >= highScoreInts[i] && newHighScoreFound == false)
            {
                //new high score has been found! place it in the proper location
                newHighScoreArray[i] = sessionScore;
                sessionHighScore = sessionScore;
                newHighScoreFound = true;
                inputField.gameObject.SetActive(true);
                HighScoreNotificationAnimator.SetBool("newhighscore", true);
                newHighScoreLocation = i;
            }

            //checks if thew newHighScore has not been found and the session score is lower than the highScoreInts
            if (newHighScoreFound == false && sessionScore < highScoreInts[i])
            {
                newHighScoreArray[i] = highScoreInts[i];
                newNamesArray[i] = highScoreNames[i];
            }

            //checks if the new position does not exceed the scorearray length only once a new high score has been found
            if ((i + 2) <= highScoreInts.Length && newHighScoreFound == true)
            {
                //adds the scores underneath to their new location
                newHighScoreArray[(i + 1)] = highScoreInts[i];
                newNamesArray[(i + 1)] = highScoreNames[i];
                newHighScoreBuffer++;
            }
        }

        highScoreInts = newHighScoreArray;
        highScoreNames = newNamesArray;
        SetNewHighScore();
        SetNewHighScoreName();
        UpdateHighScoreText();
        if (newHighScoreFound)
        {
            ChangeStringForAppropriateScore();
        }
    }

    private void SetDefaultHighScore()
    {
        int[] defaultHighScoreInts = new int[5];
        defaultHighScoreInts[0] = 15;
        defaultHighScoreInts[1] = 12;
        defaultHighScoreInts[2] = 9;
        defaultHighScoreInts[3] = 6;
        defaultHighScoreInts[4] = 3;

        //serializes the scores
        XmlSerializer scoreSerializer = new XmlSerializer(typeof(int[]));
        FileStream scoreStream = new FileStream(Path.Combine(path, "topScores.xml"), FileMode.Create);
        scoreSerializer.Serialize(scoreStream, defaultHighScoreInts);
        scoreStream.Close();
    }

    private void SetDefaultHighScoreNames()
    {
        string[] defaultHighScoreNames = new string[5];
        defaultHighScoreNames[0] = "Cobra";
        defaultHighScoreNames[1] = "OMH";
        defaultHighScoreNames[2] = "Squatch";
        defaultHighScoreNames[3] = "RoganJr";
        defaultHighScoreNames[4] = "Sander";

        XmlSerializer namesSerializer = new XmlSerializer(typeof(string[]));
        FileStream namesStream = new FileStream(Path.Combine(path, "topNames.xml"), FileMode.Create);
        namesSerializer.Serialize(namesStream, defaultHighScoreNames);
        namesStream.Close();
    }

    private void SetNewHighScore()
    {

        //serializes the scores
        XmlSerializer scoreSerializer = new XmlSerializer(typeof(int[]));
        FileStream scoreStream = new FileStream(Path.Combine(path, "topScores.xml"), FileMode.Create);
        scoreSerializer.Serialize(scoreStream, highScoreInts);
        scoreStream.Close();
    }

    private void SetNewHighScoreName()
    {
        XmlSerializer namesSerializer = new XmlSerializer(typeof(string[]));
        FileStream namesStream = new FileStream(Path.Combine(path, "topNames.xml"), FileMode.Create);
        namesSerializer.Serialize(namesStream, highScoreNames);
        namesStream.Close();
    }

    private void SetDataPath()
    {
        path = Application.dataPath + "/_saveData";
    }

    public void ChangeStringForAppropriateScore()
    {
        HighScoreTextArray[newHighScoreLocation].text = (newHighScoreLocation + 1).ToString() + ": " + inputField.text + "-" + sessionHighScore;
    }

    public void UpdateNamesArray()
    {
        //update the array
        highScoreNames[(newHighScoreLocation)] = inputField.text;

        //serialize array
        SetNewHighScoreName();
    }

    public void UpdateHighScoreText()
    {

        for (int i = 0; i < HighScoreTextArray.Length; i++)
        {
            if (highScoreNames[i] == null)
            {
                highScoreNames[i] = "No Name";
            }
            HighScoreTextArray[i].text = (i+1).ToString() + ": " + highScoreNames[i].ToString() + " - " + highScoreInts[i].ToString();
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
