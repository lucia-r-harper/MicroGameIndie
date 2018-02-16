using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandlerForFish : MonoBehaviour
{
    private Animator animator;
    private Timer timer;
	// Use this for initialization
	void Start ()
    {
        timer = FindObjectOfType<Timer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("buttonpressed");
        }

        if (timer.MicroGameState == PlayingState.Won)
        {
            animator.SetBool("gamewon", true);
        }
	}
}
