using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        Debug.Log("Game Over");
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
                break;
            case State.GameOver:
                //Debug.Log(CurrentState);
                // Display message GUI and title GUI
                //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.PlayGui);
                
               
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //Player.Instance.ResetPlayer();
                    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    GuiBehavior.Instance.UpdateMessageGUI("Press Return to Start");
                    CurrentState = State.Title;
                   
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
