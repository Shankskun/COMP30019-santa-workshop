using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
using UnityEngine;
using TMPro;

public class SnowmanWarning : MonoBehaviour {

    public GameObject speechObject;
    public GameObject speechText;
    private TextMeshProUGUI speech;

    private bool notifyTime = true;
    private float timer;
    private const float MAX_TIME = 2.0f;

    private Animator anim;

    private void Start()
    {
        anim = speechObject.GetComponent<Animator>();
        speech = speechText.GetComponent<TextMeshProUGUI>();   
    }
    void Update ()
    {
        if (Timer.PassSpawnTime()) WarningSnowmanIncoming();
	}

    // activate snowman warning speech
    void WarningSnowmanIncoming()
    {
        if (notifyTime == true)
        {
            // enable
            if (timer < MAX_TIME)
            {
                speech.SetText("Watch out for the Snowman!");
                anim.SetBool("SlideIn", true);

                DialogueManager.Activate();
            }
            // disable
            else
            {
                anim.SetBool("SlideIn", false);
                notifyTime = false;

                DialogueManager.Deactivate();
            }
            timer += Time.deltaTime;
        }
    }


}
