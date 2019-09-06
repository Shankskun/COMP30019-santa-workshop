using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanGenerator : MonoBehaviour {

    public GameObject snowman_model;

    // magic poof
    public ParticleSystem poof_particle;

    // possibility of snowman appearing
    private int spawnRate;
    private bool outOfRange;
    private static bool hasSpawn;

    // player's position
    private float center;
    public GameObject player;
  
    // default yz axis
    public const float Y = -1;
    public const float Z = -5;

    // Time for determining if a Snowman should be spawned
    private float timer;
    private bool canSpawn;
    private int timeInterval;

    // Constant variables
    private const int RESET = 0;


    // get player pos (z axis)
    private void Start()
    {
        canSpawn = false;
        center = player.transform.position.z;
        spawnRate = GameProperties.GetSnowmanSpawnRate() * 10;
        timeInterval = GameProperties.GetTimeIntervalBetweenSnowmanSpawn();
    }


    void Update () {

        // Only allow Snowman to be spawned after certain time into level
       if (Timer.PassSpawnTime())
       {

            // If time since last spawn has passed the pre-defined time interval
            if (canSpawn)
            {
                // Reset timer
                timer = RESET;

                // Check if player is outside of the spawn zone
                outOfRange = IsPlayerOutOfRange();

                // Wait until player is outside of the spawn zone and only then
                // a Snowman will be decided to be spawned or not
                if (hasSpawn == false && outOfRange == true)
                {
                    Debug.Log("Sneaky guy is coming!");
                    // Spawn rate range from 1 - 100
                    int i = Random.Range(1, 100);

                    // Success! Spawn snowman
                    if (i <= spawnRate)
                    {
                        GameObject snowman = Instantiate<GameObject>(snowman_model);
                        snowman.transform.position = new Vector3(player.transform.position.x,
                                                                     Y, Z);
                        ParticleSystem particle = Instantiate<ParticleSystem>(poof_particle);
                        particle.transform.position = new Vector3(player.transform.position.x,
                                                                     Y, Z);
                        particle.Play();

                        // New snowman has spawn
                        hasSpawn = true;
                        Debug.Log("Yeah right!");
                    }
                    // Doesn't matter if a snowman has been successfully spawned or not,
                    // Check back at next time interval.
                    canSpawn = false;
                }
            }
            else
            {
                // Only start counting once the Snowman has disappeared
                if (!hasSpawn) {
                    timer += Time.deltaTime;
                    canSpawn = (timer >= timeInterval);
                }
            }

       }
	}

    /* indicate snowman has despawned */
    public static void DeSpawn()
    {
        hasSpawn = false;
    }

    private bool IsPlayerOutOfRange() 
    {
        return player.transform.position.z >= center ? true : false;
    }
}
