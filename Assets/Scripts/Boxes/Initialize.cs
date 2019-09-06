using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {

    public GameObject box;
    public GameObject loc;

    private float timeInterval;

    private Vector3 position;
    private float timer;

    // for powerups
    private float slowDownRate;

    /* get spawn location */
    void Start()
    {
        // get from game properties controller
        timeInterval = GameProperties.GetBoxSpawnRate();

        // get starting location of box
        position = loc.gameObject.transform.position;

        // create an offset in timer, (first item comes out earlier)
        timer = timeInterval;

        // get powerup slowdown rate of time
        slowDownRate = GameProperties.GetSlowTimePowerUp();
    }

    /* create new gift box every (timeInterval) secs */
    void Update () { 

        // if powerup is activated
        if (PowerUp.snowmanIsDestroyed == true) timer += Time.deltaTime * slowDownRate;
        // under normal mode
        else timer += Time.deltaTime;

        // time to create new box
        if (timer >= timeInterval)
        {
            // instantiate new boxes
            GameObject newBox = Instantiate<GameObject>(box);
            newBox.transform.position = new Vector3(position.x, position.y, position.z);

            // reset timer
            timer = 0.0f;
        }

	}
}
