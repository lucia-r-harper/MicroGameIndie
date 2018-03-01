using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Transform target;
    private SpriteRenderer spriteRenderer;
    private float speed = 0.75f;
    private bool isDestroyed = false;
    private const float difficultyScaleRate = 20;

    private const float explosionFadeOutTime = 0.2f;
    private float explosionAlphaValue = 255;
    public Sprite ExplosionSprite;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed += MetaGameManager.Difficulty / difficultyScaleRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        if (isDestroyed)
        {
            float newAlpha = Mathf.SmoothDamp(spriteRenderer.color.a, 0, ref explosionAlphaValue, explosionFadeOutTime);
            spriteRenderer.color = new Color(255, 255, 255, newAlpha);
        }
    }

    public void BlowUp()
    {
        //gameObject.SetActive(false);
        spriteRenderer.sprite = ExplosionSprite;
        isDestroyed = true;
        speed = 0;
    }
}
