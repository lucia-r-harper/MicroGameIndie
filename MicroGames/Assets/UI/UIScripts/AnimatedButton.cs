using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AnimatedButton : Button
{
    private new Animator animator;
    private BaseEventData baseEvent;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.IsHighlighted(baseEvent) == true)
        {
            ChangeAnimationState(1);
        }

        if (this.IsPressed() == true)
        {
            ChangeAnimationState(2);
        }
	}

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        ChangeAnimationState(0);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        ChangeAnimationState(2);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        ChangeAnimationState(0);
    }

    public void ChangeAnimationState(int intToChangeTo)
    {
        animator.SetInteger("buttonstate", intToChangeTo);
    }
}
