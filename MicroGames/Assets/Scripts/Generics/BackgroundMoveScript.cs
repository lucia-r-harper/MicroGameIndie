using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour {

	// Background scroll speed can be set in Inspector with slider
	[Range(1f, 20f)]
	public float scrollSpeed = 1f;

	// Scroll offset value to smoothly repeat backgrounds movement
	public float scrollOffset;

	// Start position of background movement
	Vector2 startPosition;

	// Backgrounds new position
	float newPosition;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
		// Getting backgrounds start position
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (timer.MicroGameState)
        {
            case PlayingState.Playing:
                ScrollBackground();
                break;
            case PlayingState.Lost:
                break;
            case PlayingState.Won:
                break;
            case PlayingState.Starting:
                break;
            case PlayingState.Ending:
                break;
            default:
                break;
        }
    }

    private void ScrollBackground()
    {
        // Calculating new backgrounds position repeating it depending on scrollOffset
        newPosition = Mathf.Repeat(Time.time * -scrollSpeed, scrollOffset);

        // Setting new position
        transform.position = startPosition + Vector2.right * newPosition;
    }
}
