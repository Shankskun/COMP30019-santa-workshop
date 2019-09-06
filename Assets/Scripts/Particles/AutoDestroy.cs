using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    private const int MAX = 3;

	// destroy particle after 3sec after intialized
	void Start ()
    {
        Destroy(this.gameObject, MAX);
	}

}
