using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] public GameObject IM;
    //{ get; set; }
    //public void StartMenu()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
    //}

    public void PauseGame()
    {
        Time.timeScale = 0f;
        //Player.Instance.enabled = false;
        GuiBehavior.Instance.UpdateMessageGUI("Pause");
        GuiBehavior.Instance.OverGui.SetActive(true);
        //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
        GameBehavior.Instance.CurrentState = State.Pause;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void InfoMenuGame(GameObject IMP)
    {
        //infomenuproxy
        ToggleInfoVisibility(IM);

    }
    public void ToggleInfoVisibility(GameObject IMP) {
        if (IMP.gameObject.activeSelf)
        {
            IMP.gameObject.SetActive(true);
        }
        else
        {
            IMP.gameObject.SetActive(false);
        }
}

}

