using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoss : MonoBehaviour
{
    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = GameObject.FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LoseIfTimeIsUp();
    }

    private void LoseIfTimeIsUp()
    {
        if (timer.MicroGameState == PlayingState.Playing && timer.Seconds <= 0)
        {
            timer.MicroGameState = PlayingState.Lost;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LoseIfBulletLeavesBorder(collision);
        DestroyObject(collision.gameObject);
    }

    private void LoseIfBulletLeavesBorder(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet" && timer.MicroGameState == PlayingState.Playing)
        {
            timer.MicroGameState = PlayingState.Lost;
        }
    }
}
