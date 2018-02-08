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
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PongBallMovement>() != null)
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
