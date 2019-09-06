using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SantaWarning : MonoBehaviour {

    public GameObject popUp;
    private Animator animator;
    public TextMeshProUGUI santaSpeech;
    public int hierachyLevel = 2;

    // when the wrong item is placed in the box
    private static bool wrongItem;

    // when box is burnt
    private static bool isBurnt;

    // number of burnt boxes
    private int count;

    // timer for speech bubble
    private float timer;
    private const float MAXTIME = 2.0f;

    // santa's angry-ness level
    private const int MIN_ANGRY = 2;
    private const int MAX_ANGRY = 4;

    // enum of angry-ness
    enum Angry
    {
        level1 = 1,
        level2 = 2,
        level3 = 3,
        level4 = 4
    }

    private void Start()
    {
        animator = popUp.GetComponent<Animator>();
    }

    /* pulls out santa's speech when box is burnt or when the wrong item is placed in a box */
    void Update()
    {
        // in game
        if (Timer.GameOverTime() == false)
        {
            // when here are no other dialogues present
            if (DialogueManager.PriorityIsActivated == false)
            {
                popUp.SetActive(true);
                ManageDialogue();
            }
            // other higher priotrity dialogues present
            else
            {
                // reset all properties of the warning, and disable it
                timer = 0.0f;
                popUp.SetActive(false);
            }
        }
        // game ended
        else
        {
            popUp.SetActive(false);
        }        
    }

    /* displays different speeches, depending on number of times elf made santa angry */
    void DialogueBox(int i)
    {
        switch (i)
        {
            case (int)Angry.level1:
                santaSpeech.SetText("Hey! Those gifts don't wrap themselves you know!!");
                animator.SetBool("SlideIn", true);
                count++;
                break;
            case (int)Angry.level2:
                santaSpeech.SetText("Looks like there will be lots of sad kids tonight...");
                animator.SetBool("SlideIn", true);
                count++;
                break;
            case (int)Angry.level3:
                santaSpeech.SetText("ARE YOU TRYING TO RUIN MY REPUTATION !!!");
                animator.SetBool("SlideIn", true);
                count++;
                break;
            // warning for placing wrong item into boxes
            case (int)Angry.level4:
                santaSpeech.SetText("Make sure you place an item in the box before you wrap it!");
                animator.SetBool("SlideIn", true);
                break;
        }
        // reset timer
        timer = 0.0f;
    }

    /* decides which dialogue to show, also manages time of dialogue shown */
    private void ManageDialogue()
    {
        // when wrong item is placed in the box, set appropriate speech
        if (wrongItem)
        {
            DialogueBox((int)Angry.level4);
            wrongItem = false;
        }
        // when object is burnt, set appropriate speech
        else if (isBurnt)
        {
            if (count < MIN_ANGRY) DialogueBox((int)Angry.level1);
            else if (count < MAX_ANGRY) DialogueBox((int)Angry.level2);
            else if (count >= MAX_ANGRY) DialogueBox((int)Angry.level3);

            isBurnt = false;
        }
        // increment timer
        timer += Time.deltaTime;

        // reset time, and push back the dialogue
        if (timer >= MAXTIME)
        {
            animator.SetBool("SlideIn", false);
            timer = 0.0f;
        }
    }

    /* getters */
    public static void WhenBoxIsBurn()
    {
        isBurnt = true;
    }

    public static void WhenWrongItem()
    {
        wrongItem = true;
    }
}
