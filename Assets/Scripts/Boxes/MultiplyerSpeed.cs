using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyerSpeed : MonoBehaviour {

    public static float multiply;
    public float increase = 1.5f;

    // initial rate of box/belt movement (1)
	void Start () 
    {
        multiply = 1.0f;
	}
	
	// change its rate when time reduces to the 2 checkpoints
	void Update () 
    {
        if (Timer.WarningTime1()) multiply = increase;
        if (Timer.WarningTime2()) multiply = Mathf.Pow(increase, 2);
    }

    // for box/belt scripts
    public static float GetMultiplyer()
    {
        return multiply;
    }
}
