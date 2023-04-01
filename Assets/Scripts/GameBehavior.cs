using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public int score;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI playButton;

    public static GameBehavior Instance;

    public State CurrentState;

    public void GameOver()
    {
        Debug.Log("no");
        GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
    }
    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        // Changed to Play fromt title
        GuiBehavior.Instance.UpdateMessageGUI("Press Return to Start");
        GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
        GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
        GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
        Time.timeScale = 0f;
        CurrentState = State.Title;

    }
    private void Update()
    {
        switch (CurrentState)
        {
            case State.Title:
                
                //Player.Instance.enabled = false;
                //Debug.Log(CurrentState);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    
                    Time.timeScale = 1f;
                    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
                    CurrentState = State.Play;
                    
                }
                break;
            case State.Play:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 0f;
                    //Player.Instance.enabled = false;
                    GuiBehavior.Instance.UpdateMessageGUI("Pause");
                    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    CurrentState = State.Pause;
                   
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    //GuiBehavior.Instance.UpdateMessageGUI("Game Over");
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //Time.timeScale = 0f;
                    //CurrentState = State.GameOver;

                }
                break;
            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //Player.Instance.ResetPlayer();
                    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
                    GuiBehavior.Instance.UpdateMessageGUI("Press Return to Start");
                    CurrentState = State.Title;
                   
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    //GuiBehavior.Instance.UpdateMessageGUI("Game Over");
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //Time.timeScale = 0f;
                    //CurrentState = State.GameOver;

                }
                break;
            case State.Pause:
                //Debug.Log(CurrentState);
                if (Input.GetKeyDown(KeyCode.P))
                {
                    //Player.Instance.enabled = true;
                    Time.timeScale = 1f;
                    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    CurrentState = State.Play;
                }
                break;
        }
    }

    
}
