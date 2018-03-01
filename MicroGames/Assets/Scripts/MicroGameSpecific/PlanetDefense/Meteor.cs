using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Transform target;
    private float speed = 0.75f;
    private const float difficultyScaleRate = 20;
    public Transform Target
    {
        set
        {
            target = value;
        }
    }
	// Use this for initialization
	void Start ()
    {
        speed += MetaGameManager.Difficulty / difficultyScaleRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
	}

    public void BlowUp()
    {
        gameObject.SetActive(false);
    }
}
