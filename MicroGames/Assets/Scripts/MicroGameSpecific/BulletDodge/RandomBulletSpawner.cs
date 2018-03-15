using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletSpawner : MonoBehaviour
{
    public int NumberOfBulletsToSpawn;
    public GameObject bullet;
    private bool haveBulletsBeenSpawned = false;

    public float XBorderExtent = 8.875f;
    public float YBorderExtent = 5.0f;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        AdjustNumberOfBulletsToSpawnForDifficulty();
        //SpawnAllBullets();
    }

    private void Update()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                SpawnAllBullets();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void SpawnAllBullets()
    {
        for (int i = 0; i < NumberOfBulletsToSpawn; i++)
        {
            if (haveBulletsBeenSpawned == false)
            {
                SpawnBullet();
            }

            if (i+1 == NumberOfBulletsToSpawn)
            {
                haveBulletsBeenSpawned = true;
            }
        }
    }

    private void AdjustNumberOfBulletsToSpawnForDifficulty()
    {
        int numberOfExtraBulletsToAdd = MetaGameManager.Difficulty;
        NumberOfBulletsToSpawn += numberOfExtraBulletsToAdd;

        Debug.Log("number of Extra Bullets Added: " + numberOfExtraBulletsToAdd.ToString());
    }

    private void SpawnBullet()
    {
        Vector3 spawnVector = new Vector3(UnityEngine.Random.Range(-XBorderExtent, XBorderExtent), UnityEngine.Random.Range(-YBorderExtent, YBorderExtent));
        Instantiate(bullet, spawnVector, bullet.transform.rotation);
    }
}
