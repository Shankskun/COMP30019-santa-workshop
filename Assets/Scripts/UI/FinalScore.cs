using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinalScore : MonoBehaviour {

    public static FinalScore manager;
    private int score;

    public GameObject scoreObject;
    public GameObject quoteObject;
    public GameObject gameOverTextObject;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI quoteText;
    private TextMeshProUGUI gameOverText;

    private const int HIGH_SCORE = 80;
    private const int PASS_SCORE = 50;

    /* remove extra scoring managers */
    private void Awake()
    {
        if (manager != null)
        {
            Destroy(this);
            return;
        }
        manager = this;
    } 
    
    /* print out the scoring screen (without the score) */
    void Start () {
        scoreText = scoreObject.GetComponent<TMPro.TextMeshProUGUI>();

        quoteText = quoteObject.GetComponent<TMPro.TextMeshProUGUI>();

        gameOverText = gameOverTextObject.GetComponent<TMPro.TextMeshProUGUI>();

        // get score
        score = Scoring.getScore();
    }

    /* displaying score when game is over */
    void Update()
    {
        // get score
        score = Scoring.getScore();

        scoreText.SetText("Your score: " + score.ToString());

        if (score < PASS_SCORE)
        {
            quoteText.SetText("Better luck next time!");
            gameOverText.SetText("Game Over");
        }
        else if(score < HIGH_SCORE)
        {
            quoteText.SetText("Not bad! Santa is impressed");
            gameOverText.SetText("You Win!");
        }
        else
        {
            quoteText.SetText("You're hired! Santa loves you");
            gameOverText.SetText("You Win!");
        }
    }
}
