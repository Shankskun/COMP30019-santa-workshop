/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanGeneratorOri : MonoBehaviour {

    public GameObject snowman_model;

    // magic poof
    public ParticleSystem poof_particle;

    // possibility of snowman appearing
    public int percentage = 2;
    private static bool hasSpawn;
    private bool outOfRange = true;

    // player's position
    public GameObject player;
    private float center;

    // default yz axis
    public const float Y = -1;
    public const float Z = -5;

    // get player pos (z axis)
    private void Start()
    {
        center = player.transform.position.z;
        percentage = GameProperties.GetSnowmanSpawnRate();
    }


    void Update () {

        // only start to spawn snowman after certain time into level
       if (Timer.SpawnTime())
       {
            // range of player, for snowman to spawn
            outOfRange = player.transform.position.z >= center ? true : false;

            if (hasSpawn == false && outOfRange == true)
            {
                //percentage range from 1- 200
                int i = Random.Range(1, 200);

                // if in spawn percentage, make new snowman
                if (i < percentage)
                {
                    GameObject snowman = Instantiate<GameObject>(snowman_model);
                    snowman.transform.position = new Vector3(player.transform.position.x,
                                                                 Y, Z);
                    ParticleSystem particle = Instantiate<ParticleSystem>(poof_particle);
                    particle.transform.position = new Vector3(player.transform.position.x,
                                                                 Y, Z);
                    particle.Play();

                    // new snowman has spawn
                    hasSpawn = true;
                 }
            }
       }
	}

    // indicate snowman has despawned 
    public static void DeSpawn()
    {
        hasSpawn = false;
    }
}

*/