using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameBehavior.Instance.CurrentState == State.Play)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", true);
                
               
            }
            else
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", true);
            }
        }
        if (GameBehavior.Instance.CurrentState == State.Pause)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", true);
        }

    }
}
