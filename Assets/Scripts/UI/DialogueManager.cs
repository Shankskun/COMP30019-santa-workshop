using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    // the 3 different warning popups
    public GameObject warning_1;
    public GameObject warning_2;
    public GameObject warning_3;

    public static bool PriorityIsActivated;

    private void Start()
    {
        // deafult where higher priority UI elements are not activated
        PriorityIsActivated = false;
    }

    /* activate or deactivate dialogues, prevent overlapping */
    public static void Activate()
    {
        PriorityIsActivated = true;
    }

    public static void Deactivate()
    {
        PriorityIsActivated = false;
    }

}
