using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimator : MonoBehaviour, IAnimatable
{

    Animator animator;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetToLosingAnimation()
    {
        animator.SetBool("didplayerlose", true);
    }

    public void SetToWinningAnimation()
    {
        animator.SetBool("didplayerwin", true);
    }
}
