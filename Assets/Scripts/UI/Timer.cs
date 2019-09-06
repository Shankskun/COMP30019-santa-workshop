using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    // reference from Tutor, Mesut Latifoglu
    public static Timer manager;
    private TextMeshProUGUI text;
    private GrowAndShrink shrinkManager;
    private static bool littleTime;
    private static bool veryLittleTime;
    private static bool hasEnded;

    // countdown timer
    private static float clock;

    // warning time
    private static float warningTime_1 = 45;
    private static float warningTime_2 = 15;
    private static float snowmanSpawn = 70;
    private const int MID = 5;
    private const int MIN = 0;

    // flag if text is pulsing
    private bool isPulsing = false; 

    /* print out timer */
    void Start () 
    {
        // get total time of game
        clock = GameProperties.GetTotalTime();

        // get times where box will increase speed
        warningTime_1 = GameProperties.GetIncreaseSpeedTime1();
        warningTime_2 = GameProperties.GetIncreaseSpeedTime2();

        // get snowman spawn time
        snowmanSpawn = GameProperties.GetSnowmanTime();

        text = GetComponent<TextMeshProUGUI>();
        text.SetText(clock.ToString() + " s: Time Remaining");

        shrinkManager = GetComponent<GrowAndShrink>();

        // reset game when start
        hasEnded = false;
    }

    void Update ()
    {
        clock -= Time.deltaTime;

        // check for warning times
        if (clock <= warningTime_1 && clock > warningTime_2)
        {
            littleTime = true;
        }
        else if (clock <= warningTime_2)
        {
            veryLittleTime = true;
            littleTime = false;
        }

        // change colour, display time running out
        if (clock <= warningTime_2 && clock > MIN)
        {
            if (clock <= MID)
            {
                if (!isPulsing)
                {
                    shrinkManager.StartPulsing();
                    isPulsing = true;
                }
            }
            text.SetText(clock.ToString("#") + " secs: Time Remaining");
            text.faceColor = Color.yellow;
        } 

        // when timer ends, game over
        else if(clock <= MIN){
            text.SetText("GAME OVER");
            shrinkManager.StopPulsing();

            hasEnded = true;
        }

        // game running
        else { 

            text.SetText(clock.ToString("#") + " secs: Time Remaining");
        }
    }

    /* notifies when timer is below 45 secs */
    public static bool WarningTime1()
    {
        return littleTime;
    }
    /* notifies when timer is below 15 secs */
    public static bool WarningTime2()
    {
        return veryLittleTime;
    }

    /* start the spawnning of annoying snowmans */
    public static bool PassSpawnTime()
    {
        return (clock < snowmanSpawn);
    }

    /* game over */
    public static bool GameOverTime()
    {
        return hasEnded;
    }

}
