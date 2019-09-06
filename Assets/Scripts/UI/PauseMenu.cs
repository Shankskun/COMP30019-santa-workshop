using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    // referenced from : https://www.youtube.com/watch?v=JivuXdrIHK0
    public static bool isPause;
    public GameObject UI;
    public AudioSource backgroundMusic;
    public GameObject pauseObject;
    public Button pauseButton;

    void Start()
    {
        pauseObject.SetActive(true);
        pauseButton.onClick.AddListener(Pause);
    }

    /* check if player pressed ESC */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // not in menu
            if(isPause == false)
            {
                Pause();
            }
            // already in menu
            else
            {
                Resume();
            }
        }
    }

    /* pause/resume time and music */
    void Pause()
    {
        UI.SetActive(true);
        isPause = true;

        Time.timeScale = 0.0f;
        backgroundMusic.Pause();
        pauseObject.SetActive(false);
    }

    public void Resume()
    {
        UI.SetActive(false);
        isPause = false;

        Time.timeScale = 1.0f;
        backgroundMusic.Play();
        pauseObject.SetActive(true);
    }

    /* load main menu scene */
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScreen");
    }
}
