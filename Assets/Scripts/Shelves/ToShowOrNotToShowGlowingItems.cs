using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToShowOrNotToShowGlowingItems : MonoBehaviour {

    public GameObject shelf;

    private Renderer rd;
    private GenerateItem itemGeneratingScript;

	void Start () {

        // Get the item's mesh renderer
        rd = this.gameObject.GetComponent<Renderer>();

        // Get the GenerateItem script
        itemGeneratingScript = shelf.GetComponent<GenerateItem>();
    }
	
	void Update () {

        // Only show glowing items since the corresponding items are on shelf
        rd.enabled = itemGeneratingScript.GetIsItemOnShelf() ? true : false;


    }

}
