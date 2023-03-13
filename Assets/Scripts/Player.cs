using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Vector3 direction;

    public static Player Instance;

    public float gravity = -9.8f;
    public float strength = 5f;

    [SerializeField] float PowerDuration = 5f;

    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreGUI.text = Score.ToString();
        }
    }

    public void IncreaseScore()
    {
        Score++;
    }

    [SerializeField] TextMeshProUGUI ScoreGUI;

    private void Start()
    {
        Score = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (GameBehavior.Instance.CurrentState == State.Play)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;

            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    direction = Vector3.up * strength;
                }
            }
            if (transform.position.y >= -2.08f)
            {
                direction.y += gravity * Time.deltaTime;

            }
            else
            {
                transform.position = new Vector3(
                    transform.position.x,
                    -2.08f,
                    transform.position.z);
                direction.y = 0;
            }
            transform.position += direction * Time.deltaTime;
        }
        if (GameBehavior.Instance.CurrentState == State.Title)
        {
            ResetPlayer();
            
        }
    }


   
    public void ResetPlayer()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        transform.localScale = new Vector3(-1.34f, .70f, 0.36f);
        direction = Vector3.zero;
    }
    //Player.SetActive(false);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.CompareTag("Obstacle"))
        {
            // Destroy the enemy object
            Time.timeScale = 0f;
            GuiBehavior.Instance.UpdateMessageGUI("Game Over");
            GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
            Start();
            GameBehavior.Instance.CurrentState = State.GameOver;
            

        }
        else if (collision.gameObject.CompareTag("Scoring"))
        {
            IncreaseScore();
            //FindObjectOfType<GameBehavior>().IncreaseScore();
        }
        else if (collision.gameObject.CompareTag("Scaling"))
        {
            StartCoroutine(ScaleUp());
            //PowerSpawn.Instance.DestroyPowerup();
                //function that destroys the scurrent soawn
        }
        //scalepower
        IEnumerator ScaleUp()
        {
            transform.localScale *= 0.5f;
            // number of secs
            yield return new WaitForSeconds(PowerDuration);
            transform.localScale *= 2f;

        }
    }





}
