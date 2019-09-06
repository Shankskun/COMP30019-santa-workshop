using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItem : MonoBehaviour {

    public GameObject item;
    public GameObject itemLocation;

    public float timeInterval = 2.0f;

    private Vector3 position;
    private float timer;
    private bool itemOnShelf;

	// Use this for initialization
	void Start () {

        // Get generation location of item 
        position = itemLocation.gameObject.transform.position;

        // Generate an item at the start
        GameObject newItem = Instantiate<GameObject>(item);
        newItem.transform.position = new Vector3(position.x, position.y, position.z);
        newItem.transform.rotation = itemLocation.transform.rotation;
        newItem.GetComponent<MeshRenderer>().enabled = false;

        // Set timer to 0
        timer = 0.0f;
    }

    void OnTriggerEnter(Collider other)
    { 
        itemOnShelf = true;
    }

    void OnTriggerExit(Collider other)
    {
        itemOnShelf =  false;

    }

    // Create a new item after (timeInterval) secs when the previous one has been taken
    void Update () {

        // first check if item is on shelf
        if (!itemOnShelf)
        {
            timer += Time.deltaTime;

            // Only generate new item when it has exceeded time interval
            if (timer >= timeInterval)
            {
                // Instantiate new item
                GameObject newItem = Instantiate<GameObject>(item);
                newItem.transform.position = new Vector3(position.x, position.y, position.z);
                newItem.transform.rotation = itemLocation.transform.rotation;
                newItem.tag = "Pickable";
                newItem.GetComponent<MeshRenderer>().enabled = false;
                itemOnShelf = true;

                // reset timer
                timer = 0.0f;
            }
        }
        
	}

    // Getter method for the bool variable "itemOnShelf"
    public bool GetIsItemOnShelf() {
        return itemOnShelf;
    }
}
