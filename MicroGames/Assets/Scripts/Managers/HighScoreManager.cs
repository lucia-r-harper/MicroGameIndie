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

    private string path = "/_saveData";

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
            Debug.Log("New high score!!!");
            /*ERROR! TODO: InvalidOperationException: To be XML serializable, types which inherit from IEnumerable must have an implementation of Add(System.Object)
            at all levels of their inheritance hierarchy. UnityEngine.Transform does not implement Add(System.Object).
            */
            XmlSerializer serializer = new XmlSerializer(typeof(HighScoreManager));
            FileStream stream = new FileStream(path,FileMode.Create);
            serializer.Serialize(stream, this);
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
