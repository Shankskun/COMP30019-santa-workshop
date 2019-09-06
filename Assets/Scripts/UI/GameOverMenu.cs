using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public static bool hasEnded;
    public GameObject UI;
    public GameObject pauseObject;
    public GameObject scoreObject;
    public GameObject timerObject;

    private void Start()
    {
        hasEnded = false;
        Time.timeScale = 1.0f;
        UI.SetActive(false);
    }

    /* check if player pressed ESC */
    void FixedUpdate()
    {
        if (Timer.GameOverTime() == true)
        {
            LoadGameOverMenu();
        }
    }

    /* load game over menu scene */
    public void LoadGameOverMenu()
    {
        // pause the game in the background
        Time.timeScale = 0.0f;
        UI.SetActive(true);
        pauseObject.SetActive(false);
        scoreObject.SetActive(false);
        timerObject.SetActive(false);
    }

    /* go back to main menu button */
    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScreen");
    }

    /* quit game */
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("hope you enjoyed the game");
    }
}
