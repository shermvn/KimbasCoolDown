using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public static PowerUpBehavior Instance;
    public float rotationSpeed = 100f;
    public float shrinkSpeed = 0.5f;
    private float hoverHeight = 1f;
    private float hoverSpeed = 2f;
    private float startY;
    private Animator anim;
    void Start()
    {
        // Set the initial y-position of the sprite
        startY = transform.position.y;
        anim = GetComponent<Animator>();

    }
    //public void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        Instance = this;
    //    }
    //}
    private void Anim()
    {
        anim.SetBool("isShrink", true);
    }

    //with no animation object present its fine


    private void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object you want to collide with
        //{
        Anim();
        //Obstacles.Instance.AnimOB();
        Debug.Log("collision");
        // Check if the GameObject has shrunk to nothing
        if (transform.localScale.x <= 0f)
        {
            Destroy(this);
        }
        //}

        //}
    }
}