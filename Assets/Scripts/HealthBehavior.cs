using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    public static HealthBehavior Instance;
    public Animator anim;
    public int PowerDown = 6;

    // create a get set function count like score in player
    
    private int _count;
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            if (Count < PowerDown)
            {
                anim.SetTrigger("isBar4");
                //Debug.Log(Count);
            }
            else if (Count >= PowerDown && Count < (PowerDown*2))
            {
                anim.SetTrigger("isBar3");
                //Debug.Log(Count);
            }
            else if (Count >= (PowerDown * 2) && Count < (PowerDown * 3))
            {
                anim.SetTrigger("isBar2");
                //Debug.Log(Count);
            }
            else if (Count >= (PowerDown * 3) && Count < (PowerDown * 4))
            {
                anim.SetTrigger("isBar1");
                //Debug.Log(Count);
            }
            //else if (Count == (PowerDown * 4))
            else if (Count == (2))

            {
                anim.SetTrigger("isBar0");
                GuiBehavior.Instance.UpdateMessageGUI("Game Over");
                GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                Time.timeScale = 0f;
                GameBehavior.Instance.CurrentState = State.GameOver;
            }
        }
    }
    public void Awake()
    {
        if( Instance != null && Instance != this)
        {
             Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {

        if (GameBehavior.Instance.CurrentState == State.Title || GameBehavior.Instance.CurrentState == State.GameOver) { 
            Count = 0;

        }
        // no magic numbers
        // SWITCHING THE SPRITE OF THE HEALTH BAR
        // use if instead
        //switch (Count)
        //{
        //    case 6:
        //        anim.SetTrigger("isBar3");
        //        break;
        //    case 12:
        //        anim.SetTrigger("isBar2");
        //        break;
        //    case 18:
        //        anim.SetTrigger("isBar1");
        //        break;
        //    case 24:
        //        anim.SetTrigger("isBar0");
        //        GameBehavior.Instance.CurrentState = State.GameOver;
        //        break;
        //    default:
        //        anim.SetTrigger("isBar4");
        //        break;
        //}

    }
}
