using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGoal : MonoBehaviour
{
    public enum GoalMode { LoseOnCotact, WinOnContact}
    public GoalMode goalMode;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PongBallMovement>() != null && timer.MicroGameState == PlayingState.Playing)
        {
            switch (goalMode)
            {
                case GoalMode.LoseOnCotact:
                    timer.MicroGameState = PlayingState.Lost;
                    break;
                case GoalMode.WinOnContact:
                    timer.MicroGameState = PlayingState.Won;
                    break;
                default:
                    break;
            }
        }
    }
}
