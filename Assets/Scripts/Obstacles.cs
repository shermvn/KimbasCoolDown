using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    public static Obstacles Instance;
    public float speed = 5f;
    private float leftEdge;



    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }


   
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge - 10)
        {
            Destroy(gameObject);
        }
        if (GameBehavior.Instance.CurrentState == State.Title)
        {
            Destroy(gameObject);
        }

        //OnTriggerEnter2D();
    }
}
