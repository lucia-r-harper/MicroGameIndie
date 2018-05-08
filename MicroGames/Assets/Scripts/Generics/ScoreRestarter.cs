using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRestarter : MonoBehaviour
{
    private PauseManager pauseManager;
    public void ResetScore()
    {
        pauseManager.SetIsAtGameOverSceneToFalse();
        MetaGameManager.resetLivesAndScore();
    }

    private void Start()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }

}
