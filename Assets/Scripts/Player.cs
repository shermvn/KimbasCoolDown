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
    //private float  ScaleOG = 0.2f;
    private bool _inCoroutine = false;
    private Vector3 init = new Vector3(0.2f, 0.2f, 0.2f);






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
        //Debug.Log(HealthBehavior.Instance.Count);
    }

    [SerializeField] TextMeshProUGUI ScoreGUI;

    private void StartScore()
    {
        Score = 0;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameBehavior.Instance.CurrentState == State.Play)
        {
            //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.up * strength;
                AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.JumpHit, 0.2f);

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
            StartScore();
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
        transform.localScale = init;
        direction = Vector3.zero;
    }
    //Player.SetActive(false);

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.CompareTag("Obstacle"))
        {


            GuiBehavior.Instance.UpdateMessageGUI("Game Over");
            AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
            GuiBehavior.Instance.OverGui.SetActive(true);
            //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
            AudioBehavior.Instance.Soundtrack.Pause();
            Time.timeScale = 0f;
            GameBehavior.Instance.CurrentState = State.GameOver;
            Debug.Log("obstacle");
            //Start();



        }
        else if (collision.gameObject.CompareTag("Scoring"))
        {
            IncreaseScore();
            AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.ScoreHit, 0.1f);

            //FindObjectOfType<GameBehavior>().IncreaseScore();
        }
        else if (collision.gameObject.CompareTag("Scaling") && !_inCoroutine)
        {
            StartCoroutine(ScaleUp());
            Debug.Log("Scaled");
            AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.ScaleHit, 0.2f);

            //PowerSpawn.Instance.DestroyPowerup();
            //function that destroys the scurrent soawn
        }
        else if (collision.gameObject.CompareTag("Healing"))
        {
            //Obstacles.Instance.AnimOB();
            Debug.Log("Healed");
            AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.HealHit, 0.3f);


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
        _inCoroutine = true;
            //yChange = -1.86f;
            transform.localScale *= 0.5f;
        // number of secs
            yield return new WaitForSeconds(PowerDuration);
        // make a new vector three with o.2 f for each position
        transform.localScale = init;
        //transform.localScale = ScaleOG;
        //yChange = 0;
        _inCoroutine = false;


        }
        //IEnumerator HealUp()
        //{
           
        //    yield return new WaitForSeconds(PowerDuration);
            

        //}
         private void ResetCoroutine()
         {
            StopCoroutine(ScaleUp());
            ResetPlayer();

        //StopCoroutine(HealUp());
    }
    }
  

   
