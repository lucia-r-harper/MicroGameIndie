using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetMovingState { LeftToRight, UpAndDown, Still}
public class MovingTarget : MonoBehaviour
{
    private float speed = 0.25f;
    private TargetMovingState movingState = TargetMovingState.LeftToRight;

    private Timer timer;

	// Use this for initialization
	void Start ()
    {
        timer = GameObject.FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void FixedUpdate()
    {
        UpdateMovementBasedOnMovingState();
    }

    private void UpdateMovementBasedOnMovingState()
    {
        switch (movingState)
        {
            case TargetMovingState.LeftToRight:
                MoveLeftToRight();
                break;
            case TargetMovingState.UpAndDown:
                break;
            case TargetMovingState.Still:
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            speed *= -1;
        }
    }

    private void MoveLeftToRight()
    {
        transform.Translate(speed, 0, 0);
    }

    private void MoveUpAndDown()
    {
        transform.Translate(0, speed, 0);
    }
}
