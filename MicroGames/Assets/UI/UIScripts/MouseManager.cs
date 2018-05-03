﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseState { TitleScreen, GameOver, Upnaused, Paused}
public class MouseManager : MonoBehaviour
{
    public static MouseState MouseState;
    public Texture2D[] customCursors;
    private Texture2D customCursor;
    AudioSource clickSound;
	// Use this for initialization
	void Start ()
    {
        MouseState = MouseState.TitleScreen;
        SetCustomCursor();
        DontDestroyOnLoad(this);
        clickSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update ()
    {
        PlayClickWhenClicked();
        HideMouseBasedOnState();
    }
    private void SetCustomCursor()
    {
        int randomCursorNumber = UnityEngine.Random.Range(0, customCursors.Length);
        customCursor = customCursors[randomCursorNumber];
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }

    private void HideMouseBasedOnState()
    {
        switch (MouseState)
        {
            case MouseState.TitleScreen:
                Cursor.visible = true;
                break;
            case MouseState.GameOver:
                Cursor.visible = true;
                break;
            case MouseState.Upnaused:
                Cursor.visible = false;
                break;
            case MouseState.Paused:
                Cursor.visible = true;
                break;
            default:
                break;
        }
    }

    private void PlayClickWhenClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("hello!");
            clickSound.Play();
        }
    }
}
