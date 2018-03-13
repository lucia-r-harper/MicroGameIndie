using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VOAnnouncementScript : MonoBehaviour
{
    public AudioClip[] audioClips = new AudioClip[3];
    private AudioSource audioSource;

    private Timer timer;
    private bool hasAnnouncementPlayed = false;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        timer = FindObjectOfType<Timer>();
        playAnnouncement(audioClips[0]);
        hasAnnouncementPlayed = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                break;
            case PlayingState.Lost:
                if (audioSource.isPlaying == false && hasAnnouncementPlayed == false)
                {
                    playAnnouncement(audioClips[1]);
                }
                break;
            case PlayingState.Won:
                if (audioSource.isPlaying == false && hasAnnouncementPlayed == false)
                {
                    playAnnouncement(audioClips[2]);
                }
                break;
            default:
                break;
        }
    }

    private void playAnnouncement(AudioClip announcementToPlay)
    {
        audioSource.clip = announcementToPlay;
        audioSource.Play();
        hasAnnouncementPlayed = true;
    }
}
