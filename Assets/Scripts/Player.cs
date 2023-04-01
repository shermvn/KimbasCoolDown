using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Vector3 direction;

    public static Player Instance;

    public float gravity = -9.8f;
    public float strength = 5f;
    public float yChange = 0;

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
        HealthBehavior.Instance.Count++;
        Debug.Log(HealthBehavior.Instance.Count);
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
            if (transform.position.y >= -1.56f)
            {
                direction.y += gravity * Time.deltaTime;

            }
   
            else
            {
               
                transform.position = new Vector3(
                    transform.position.x,
                    -1.56f,
                    transform.position.z);
                direction.y = yChange;
            }
            transform.position += direction * Time.deltaTime;
        }
        if (GameBehavior.Instance.CurrentState == State.Title)
        {
            ResetPlayer();
            ResetCoroutine();
            Start();
        }
        if (GameBehavior.Instance.CurrentState == State.Pause || GameBehavior.Instance.CurrentState == State.GameOver)
        {
            ResetCoroutine();
        }
    }


   
    public void ResetPlayer()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        direction = Vector3.zero;
    }
    //Player.SetActive(false);

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.CompareTag("Obstacle"))
        {
            // Destroy the enemy object

            Debug.Log("obstacle");
            GuiBehavior.Instance.UpdateMessageGUI("Game Over");
            GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
            Time.timeScale = 0f;
            GameBehavior.Instance.CurrentState = State.GameOver;
            Start();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);



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
        else if (collision.gameObject.CompareTag("Healing"))
        {
            //Obstacles.Instance.AnimOB();
            if (HealthBehavior.Instance.Count <= HealthBehavior.Instance.PowerDown)
            {
                HealthBehavior.Instance.Count = 0;
                HealthBehavior.Instance.anim.SetTrigger("isBar4");
            }
            else if (HealthBehavior.Instance.Count > HealthBehavior.Instance.PowerDown && HealthBehavior.Instance.Count <= (HealthBehavior.Instance.PowerDown * 2))
            {
                HealthBehavior.Instance.Count = 6;
                HealthBehavior.Instance.anim.SetTrigger("isBar3");
            }
            else if (HealthBehavior.Instance.Count > (HealthBehavior.Instance.PowerDown * 2) && HealthBehavior.Instance.Count <= (HealthBehavior.Instance.PowerDown * 3))
            {
                HealthBehavior.Instance.Count = 12;
                HealthBehavior.Instance.anim.SetTrigger("isBar2");
            }
            else if (HealthBehavior.Instance.Count > (HealthBehavior.Instance.PowerDown * 3) && HealthBehavior.Instance.Count <= (HealthBehavior.Instance.PowerDown * 4))
            {
                HealthBehavior.Instance.Count = 18;
                HealthBehavior.Instance.anim.SetTrigger("isBar1");
            }


        }
    }
        //scalepower
        IEnumerator ScaleUp()
        {
            //yChange = -1.86f;
            transform.localScale *= 0.5f;
        // number of secs
            yield return new WaitForSeconds(PowerDuration);
            transform.localScale *= 2f;
            //yChange = 0;


        }
        //IEnumerator HealUp()
        //{
           
        //    yield return new WaitForSeconds(PowerDuration);
            

        //}
         private void ResetCoroutine()
         {
            StopCoroutine(ScaleUp());
            //StopCoroutine(HealUp());
         }
    }
  

   
