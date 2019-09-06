using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour { 

    public GameObject startPanel;
    public GameObject instructionPanel;

    // when first loading the main menu
    void Start()
    {
        startPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }

    // on screen buttons, load to instruction menu
    public void Play()
    {
        startPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Bye! See you again soon !");
        Application.Quit();
    }
}
