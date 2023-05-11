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

    //public void GameOver()
    //{
    //    Debug.Log("no");
    //    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
    //}
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
        //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
        GuiBehavior.Instance.ScoreGui.SetActive(false);
        GuiBehavior.Instance.OverGui.SetActive(true);
        GuiBehavior.Instance.Health.SetActive(false);
        //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
        //GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
        Time.timeScale = 0f;
        CurrentState = State.Title;

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch (CurrentState)
        {
            case State.Title:

                //Player.Instance.enabled = false;
                //Debug.Log(CurrentState);
                if (Input.GetKeyDown(KeyCode.Return))
                {

                    Time.timeScale = 1f;
                    GuiBehavior.Instance.ScoreGui.SetActive(true);
                    GuiBehavior.Instance.OverGui.SetActive(false);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    GuiBehavior.Instance.Health.SetActive(true);
                    CurrentState = State.Play;
                    AudioBehavior.Instance.Soundtrack.loop = true;
                    AudioBehavior.Instance.Soundtrack.Play();
                }
                 if (Input.GetKeyDown(KeyCode.Q))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                        AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                        AudioBehavior.Instance.Soundtrack.Pause();


                    }
                    break;
            case State.Play:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 0f;
                    //Player.Instance.enabled = false;
                    GuiBehavior.Instance.UpdateMessageGUI("Pause");
                    PlayGUIOff();
                    CurrentState = State.Pause;
                    AudioBehavior.Instance.Soundtrack.Pause();


                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                    AudioBehavior.Instance.Soundtrack.Pause();


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
                    PlayGUIOff();
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    //GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
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
                    AudioBehavior.Instance.Soundtrack.Play();
                    GuiBehavior.Instance.ScoreGui.SetActive(true);
                    GuiBehavior.Instance.OverGui.SetActive(false);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    GuiBehavior.Instance.Health.SetActive(true);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    CurrentState = State.Play;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                    AudioBehavior.Instance.Soundtrack.Pause();
                }
                    break;
        }
    }
    public void PlayGUIOff()
    {
        GuiBehavior.Instance.ScoreGui.SetActive(false);
        GuiBehavior.Instance.Health.SetActive(false);
        GuiBehavior.Instance.OverGui.SetActive(true);


    }


}
