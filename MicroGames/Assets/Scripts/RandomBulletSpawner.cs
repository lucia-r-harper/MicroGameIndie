using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletSpawner : MonoBehaviour
{
    public int NumberOfBulletsToSpawn;
    public GameObject bullet;

    public float XBorderExtent = 8.875f;
    public float YBorderExtent = 5.0f;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < NumberOfBulletsToSpawn; i++)
        {
            SpawnBullet();
        }
	}

    private void SpawnBullet()
    {
        Vector3 spawnVector = new Vector3(UnityEngine.Random.Range(-XBorderExtent, XBorderExtent), UnityEngine.Random.Range(-YBorderExtent, YBorderExtent));
        Instantiate(bullet, spawnVector, bullet.transform.rotation);
    }

    // Update is called once per frame
    void Update ()
    {

	}
}
