using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidestepPlayerAnimator : MonoBehaviour
{
    private Animator animator;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        animator.SetBool("isdead", true);
    }
}
