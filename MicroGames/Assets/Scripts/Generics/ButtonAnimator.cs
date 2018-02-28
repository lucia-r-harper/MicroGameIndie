using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour
{
    private Button button;
    private Animator animator;
    private BaseEventData baseEvent;

    // Use this for initialization
    void Start ()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //UpdateAnimations();
	}

    //private void UpdateAnimations()
    //{
    //    if (button. == true)
    //    {

    //    }
    //}
}
