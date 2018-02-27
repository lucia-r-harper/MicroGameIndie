using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AbductionZone : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D abductionZoneTrigger;
    private Timer timer;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        audioSource = GetComponent<AudioSource>();
        Deactivate();
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Abductee>() != null)
        {
            Abudct(collision.gameObject.GetComponent<Abductee>());
        }
    }

    private void Abudct(Abductee abductee)
    {
        abductee.GetAbducted(this.transform);
        timer.MicroGameState = PlayingState.Won;
    }

    public void Activate()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        spriteRenderer.enabled = true;
        abductionZoneTrigger.enabled = true;
    }

    public void Deactivate()
    {
        spriteRenderer.enabled = false;
        abductionZoneTrigger.enabled = false;
    }
}
