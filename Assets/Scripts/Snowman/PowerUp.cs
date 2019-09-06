using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour {

    public GameObject[] FreezeUIOverlay;

    public static bool snowmanIsDestroyed;
    public static float chance;
    public float powerUpInterval = 5.0f;

    //UI notification for the user
    public GameObject snowmanWarningObject;
    public GameObject snowmanWarningTextObject;
    private TextMeshProUGUI snowmanWarningText;
    private Animator snowmanAnim;

    //UI overlay
    public GameObject topLeftIce;
    public GameObject bottomLeftIce;
    public GameObject topRightIce;
    public GameObject bottomRightIce;
    private Animator topLeftAnim;
    private Animator bottomLeftAnim;
    private Animator topRightAnim;
    private Animator bottomRightAnim;

    private static float timer;
    private const int MIN = 0;
    private const int MAX = 100;

    private void Start()
    {
        snowmanIsDestroyed = false;
        timer = 0.0f;

        // get chance and timeinterval data from game properties
        powerUpInterval = GameProperties.GetPowerUpTimeInterval();
        chance = GameProperties.GetPowerUpChance();

        // UI Overlay detection
        topLeftAnim = topLeftIce.GetComponent<Animator>();
        bottomLeftAnim = bottomLeftIce.GetComponent<Animator>();
        topRightAnim = topRightIce.GetComponent<Animator>();
        bottomRightAnim = bottomRightIce.GetComponent<Animator>();

        // Get UI text
        snowmanWarningText = snowmanWarningTextObject.GetComponent<TextMeshProUGUI>();
        snowmanAnim = snowmanWarningObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(snowmanIsDestroyed == true)
        {
            timer += Time.deltaTime;

            // times up (3 secs)
            if(timer >= powerUpInterval)
            {
                snowmanIsDestroyed = false;
                timer = 0.0f;

                // UI over-lay 
                topLeftAnim.SetBool("fadeIn", false);
                bottomLeftAnim.SetBool("fadeIn", false);
                topRightAnim.SetBool("fadeIn", false);
                bottomRightAnim.SetBool("fadeIn", false);

                // Hide pop up text
                snowmanAnim.SetBool("SlideIn", false);

                DialogueManager.Deactivate();

                Debug.Log("warmed up");
            }
        }
    }

    // called when snowman is satisfied with its candy
    public void GivePowerUp()
    { 
        int i = Random.Range(MIN, MAX);

        // 50% chance of getting a slow down time powerup
        if (i <= chance)
        {
            // slowdown "time" (just the moving items, and not the time)
            snowmanIsDestroyed = true;
            timer = 0.0f;

            // UI over-lay 
            topLeftAnim.SetBool("fadeIn", true);
            bottomLeftAnim.SetBool("fadeIn", true);
            topRightAnim.SetBool("fadeIn", true);
            bottomRightAnim.SetBool("fadeIn", true);

            // Notify user of power up
            snowmanWarningText.SetText("Thanks for the gift! I've slowed down the boxes for you :)");
            snowmanAnim.SetBool("SlideIn", true);

            DialogueManager.Activate();

            Debug.Log("snowman exploded, too cold need to slow down");
        }
	}
}
