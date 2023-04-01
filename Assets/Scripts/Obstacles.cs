using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    public static Obstacles Instance;
    public float speed = 5f;
    private float leftEdge;
    private Animator animOB;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GuiBehavior.Instance.UpdateMessageGUI("Game Over");
            GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
            Time.timeScale = 0f;
            GameBehavior.Instance.CurrentState = State.GameOver;
            //FindObjectOfType<GameBehavior>().GameOver();
        }
        else if (collision.gameObject.CompareTag("Scoring"))
        {
            Player.Instance.IncreaseScore();
            //FindObjectOfType<GameBehavior>().IncreaseScore();
        }

    }
    public void AnimOB()
    {
        animOB.SetBool("isShrink", true);
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
