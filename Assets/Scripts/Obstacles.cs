using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        GameBehavior.Instance.CurrentState = State.GameOver;
    //        //FindObjectOfType<GameBehavior>().GameOver();
    //    }
    //    else if (collision.gameObject.CompareTag("Scoring"))
    //    {
    //        Player.Instance.IncreaseScore();
    //        //FindObjectOfType<GameBehavior>().IncreaseScore();
    //    }

    //}

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge - 10)
        {
            Destroy(gameObject);
        }

        //OnTriggerEnter2D();
    }
}
