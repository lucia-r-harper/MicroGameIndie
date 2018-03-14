using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationQuiter : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this);
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMain(string TitleSceenScene)
    {
        SceneManager.LoadScene(TitleSceenScene);
        Destroy(GameObject.Find("MetaGame"));
        Destroy(GameObject.Find("MicroGameManager"));
        Destroy(GameObject.Find("ApplicationQuitter"));
    }
}
