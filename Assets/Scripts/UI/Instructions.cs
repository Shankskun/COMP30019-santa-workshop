using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

    // next
    public GameObject nextButton;

    // skip
    public GameObject skipButton;
    private TextMeshProUGUI textButton;

    // instruction
    public GameObject instruction;
    private TextMeshProUGUI instructionText;

    // instruction pages
    private int step;
    private const int FIRST  = 1;
    private const int SECOND = 2;
    private const int THIRD  = 3;
    private const int FOURTH = 4;

    void Start()
    {
        textButton = skipButton.GetComponent<TMPro.TextMeshProUGUI>();
        instructionText = instruction.GetComponent<TMPro.TextMeshProUGUI>();

        step = 1;
        nextButton.SetActive(true);
    }

    // Use for cycling through each instuctions
    public void Next () 
    {
        ChangeText();

        step++;
	}
	
	// Skip instructions
	public void ProceedToGame () 
    {
        SceneManager.LoadScene("Santa's Workshop");
    }

    void ChangeText()
    {
        if (step == FIRST)
        {
            instructionText.SetText("Help Santa by packing candy canes. Use WASD or the arrow keys to move. Press the SPACE bar to pick up and release any items.");
        }
        else if (step == SECOND)
        {
            instructionText.SetText("You need to get at least 50 points to save Christmas!");
        }
        else if (step == THIRD)
        {
            instructionText.SetText("Make sure you pack a candy cane before you wrap it with a ribbon. Good luck!");

        } else if (step == FOURTH) {

            instructionText.SetText("P.S. Beware of the Snowman! You will need to give him an item to make him disappear, and he 'MIGHT' help you slow down the boxes");

            // disable the "next button"
            nextButton.SetActive(false);

            // change skip to "play"
            textButton.SetText("Play");
        }
    }
}
