using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorHider : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject firstSelected; 
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        eventSystem.SetSelectedGameObject(FindObjectOfType<Button>().gameObject);
    }
}
