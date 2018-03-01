using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TollBoothSpawner : MonoBehaviour
{
    public GameObject tollBooth;

    private enum xLocations { FarleftLane, LeftLane, CloseLeftLane, MiddleLane, CloseRightLane, RightLane, FarRightLane }
    private int tollBoothsToSpawn = 1;
    private const int difficultyScale = 5;
	// Use this for initialization
	void Start ()
    {
        tollBoothsToSpawn += MetaGameManager.Difficulty / difficultyScale;
        SpawnTollBooths();
	}

    private void SpawnTollBooths()
    {
        for (int i = 0; i < tollBoothsToSpawn; i++)
        {
            float xTollSpawnLocation;

            xLocations xTollSpawnLocationEnum = (xLocations)UnityEngine.Random.Range(0, 6);

            #region switchForRandomXLocationSpawning
            switch (xTollSpawnLocationEnum)
            {
                case xLocations.FarleftLane:
                    xTollSpawnLocation = -7.5f;
                    break;
                case xLocations.LeftLane:
                    xTollSpawnLocation = -5.0f;
                    break;
                case xLocations.CloseLeftLane:
                    xTollSpawnLocation = -2.5f;
                    break;
                case xLocations.MiddleLane:
                    xTollSpawnLocation = 0;
                    break;
                case xLocations.CloseRightLane:
                    xTollSpawnLocation = 2.5f;
                    break;
                case xLocations.RightLane:
                    xTollSpawnLocation = 5.0f;
                    break;
                case xLocations.FarRightLane:
                    xTollSpawnLocation = 7.5f;
                    break;
                default:
                    xTollSpawnLocation = 0;
                    break;
            }
            #endregion

            Instantiate(tollBooth, new Vector3(xTollSpawnLocation, transform.position.y), tollBooth.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
