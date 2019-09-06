using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarning : MonoBehaviour {

    public GameObject warningSpeech;

    private static float warningTime1;
    private static float warningTime2;

    private bool hasDisplayed1;
    private bool isActivated;
    private bool hasDisplayed2;
    private float countdown = 0.0f;
    private const int MAX = 2;

    // get info from game properties
    void Start ()
    {
        warningTime1 = GameProperties.GetIncreaseSpeedTime1();
        warningTime2 = GameProperties.GetIncreaseSpeedTime2();
	}
	
	// show message for 2 secs for each warning time
	void Update ()
    {
        if (Timer.WarningTime1() && hasDisplayed1 == false) PlayWarning();

        else if (Timer.WarningTime2() && hasDisplayed2 == false) PlayWarning();
    }

    // show warning dialogue
    void PlayWarning()
    {
        if (isActivated == false)
        {
            warningSpeech.SetActive(true);
            isActivated = true;

            DialogueManager.Activate();
        }
        else
        {
            countdown += Time.deltaTime;

            // timer for warning speech
            if (countdown >= MAX)
            {
                warningSpeech.SetActive(false);
                isActivated = false;

                countdown = 0.0f;

                // set guard for hasDisplayed 1 and 2
                if (hasDisplayed1 == false) hasDisplayed1 = true;
                else hasDisplayed2 = true;

                // allow other dialogues to show up
                DialogueManager.Deactivate();
            }
        }
    }
}
