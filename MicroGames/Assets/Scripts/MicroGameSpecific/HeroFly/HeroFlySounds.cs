using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlySounds : MonoBehaviour
{
    //public List<AudioSource> AudioSources = new List<AudioSource>();

    public AudioSource[] AudioSources;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayWhackSound();
    }

    private void PlayWhackSound()
    {
        AudioSources[1].Play();
    }

    public void PlayWhoosh()
    {
        AudioSources[0].Play();
    }
}
