using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGUIBehavior : MonoBehaviour
{
    // static instance of the GuiBehavior class
    public static StartGUIBehavior Instance;
    // GUI elements to control
    [SerializeField] public Canvas STM;
    [SerializeField] public TextMeshProUGUI Close;
  

    [SerializeField] public Canvas IFM;
    
    //private void Awake()
    //{
    //    IFM = GetComponent<Canvas>();
    //    STM = GetComponent<Canvas>();


    //}

    private void Start()
    {
        //if (IFM != null)
        //{
        //    myGameObject.SetActive(false);
        //}
        //if (myGameObject != null)
        //{
        //    myGameObject.SetActive(false);
        //}
    }
    // initialize static instance using singleton pattern
   
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
    public void ToggleCanvasVisibility(Canvas Menu)
    {
        if (Menu.gameObject.activeSelf)
        {
            Menu.gameObject.SetActive(false);
        }
        else
        {
            Menu.gameObject.SetActive(true);
        }
    }
    //public void StartMenu()
    //{
    //    if(Info.gameObject.activeSelf = true)
    //    {

    //    }
    //    ToggleCanvasVisibility(_start);
    //}

    //public void InfoMenu()
    //{
    //    ToggleCanvasVisibility(_info);
    //}


}
