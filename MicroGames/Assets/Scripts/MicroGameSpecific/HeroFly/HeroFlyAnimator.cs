﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlyAnimator : MonoBehaviour
{
    private Animator animator;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetAnimationToDied();
    }

    private void SetAnimationToDied()
    {
        animator.SetBool("isdead", true);
    }
}
