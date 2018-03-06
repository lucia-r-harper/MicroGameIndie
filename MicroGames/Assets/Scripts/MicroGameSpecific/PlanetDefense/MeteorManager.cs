using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public Meteor MeteorPrefab;

    public List<Transform> MeteorSpawnPoints = new List<Transform>();

    private List<Meteor> meteors = new List<Meteor>();

    private float XBorderExtent = 8.875f;
    private float YBorderExtent = 5.0f;

    //Buffer that ensures meteors spawn outside of the camera rect
    public float BorderBufferZone = 1.0f;

    private Timer timer;
    private Planet planet;

    private WaitForSeconds meteorSpawnDelay = new WaitForSeconds(1);

	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        planet = FindObjectOfType<Planet>();

        StartCoroutine(SpawnMeteors());
	}

    private IEnumerator SpawnMeteors()
    {
        while (timer.MicroGameState == PlayingState.Playing)
        {
            SpawnMeteor();
            yield return meteorSpawnDelay;
        }
        foreach (Meteor meteor in meteors)
        {
            meteor.BlowUp();
        }
    }

    private void SpawnMeteor()
    {
        Vector3 spawnVectorPosition = new Vector3(UnityEngine.Random.Range((-XBorderExtent - BorderBufferZone),-XBorderExtent), UnityEngine.Random.Range((-YBorderExtent - BorderBufferZone), -YBorderExtent));
        int randomNumber = UnityEngine.Random.Range(0, MeteorSpawnPoints.Count);
        Transform spawnVectorTransform = MeteorSpawnPoints[randomNumber];
        
        Meteor m = Instantiate(MeteorPrefab, spawnVectorTransform.position, MeteorPrefab.transform.rotation);
        m.Target = planet.transform;
        meteors.Add(m);
    }
}
