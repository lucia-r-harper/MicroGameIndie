using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlySounds : MonoBehaviour
{
    public AudioSource[] AudioSources;

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
