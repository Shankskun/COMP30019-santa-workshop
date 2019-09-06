using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scoring : MonoBehaviour {

    // reference from Tutor, Mesut Latifoglu
    public static Scoring manager;
    public GameObject num;
    private TextMeshProUGUI text;
    // score counter
    private static int count;

    // score for each successful action
    public int scorePerSuccessfulAction;
    // score for each unsuccessful gift delivered
    public int scorePerMistake;

    /* print out score */
    void Start () {

        count = 0;

        // Display score
        text = num.GetComponent<TMPro.TextMeshProUGUI>();
        text.SetText("Score: " + count.ToString());
	}
	
	/* increment score */
	void Update () 
    {
        // Display score
        text = num.GetComponent<TextMeshProUGUI>();
        text.SetText("Score: "+ count.ToString());
	}

    public void addScore()
    {
        count += scorePerSuccessfulAction;
    }

    public void minusScore()
    {
        count -= scorePerMistake;
        // minimum score is 0
        if (count < 0)
        {
            count = 0;
        }
    }

    public static int getScore()
    {
        return count;
    }
}
