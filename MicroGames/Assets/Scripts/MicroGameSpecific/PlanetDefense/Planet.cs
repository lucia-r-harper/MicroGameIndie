using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Rigidbody2D[] planetChunks;

    private Timer timer;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private const float explosionFadeOutTime = 0.2f;
    private float explosionAlphaValue = 255;
    public Sprite ExplosionSprite;
    private bool isDestroyed = false;

    private const float driftForceMin = 25;
    private const float driftForceMax = 75;
    // Use this for initialization
    void Start ()
    {
        timer = FindObjectOfType<Timer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isDestroyed == true)
        {
            FadeOutExplosion();
        }
	}

    private void FadeOutExplosion()
    {
        float newAlpha = Mathf.SmoothDamp(spriteRenderer.color.a, 0, ref explosionAlphaValue, explosionFadeOutTime);
        spriteRenderer.color = new Color(255, 255, 255, newAlpha);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Meteor>() != null && timer.MicroGameState == PlayingState.Playing)
        {
            Explode();
            timer.MicroGameState = PlayingState.Lost;
        }
    }

    private void Explode()
    {
        spriteRenderer.sprite = ExplosionSprite;
        audioSource.Play();
        isDestroyed = true;
        foreach (Rigidbody2D chunk in planetChunks)
        {
            Vector2 forceToAdd = new Vector2(UnityEngine.Random.Range(driftForceMin, driftForceMax), UnityEngine.Random.Range(driftForceMin, driftForceMax));
            chunk.AddForce(forceToAdd);
        }
    }
}
