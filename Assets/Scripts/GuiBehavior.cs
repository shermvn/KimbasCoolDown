using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;
using System;

public class GuiBehavior : MonoBehaviour
{
    // static instance of the GuiBehavior class
    public static GuiBehavior Instance { get; private set; }
    // GUI elements to control
    [SerializeField] public TextMeshProUGUI OverGui;
    [SerializeField] public TextMeshProUGUI ScoreGui;
    



    // initialize static instance using singleton pattern
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        ToggleGUIVisibility(OverGui);
    }

    // toggle visibility of a given GUI element
    public void ToggleGUIVisibility(TextMeshProUGUI GuiElement)
    {
        if (GuiElement.gameObject.activeSelf)
        {
            GuiElement.gameObject.SetActive(false);
        }
        else
        {
            GuiElement.gameObject.SetActive(true);
        }
    }

    public void UpdateMessageGUI(string message)
    {
        OverGui.text = message;
        //ToggleGUIVisibility(MessageGui);
        Debug.Log(OverGui.text);
    }
   
}

