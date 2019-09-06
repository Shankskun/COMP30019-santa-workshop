using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanMovement : MonoBehaviour {

    public ParticleSystem magic_poof;

    private GameObject player;
    private GameObject item;
    private bool stoledItem;

    private bool debugOn;

    private PowerUp powerUp;

    private void Start()
    {
        player = GameObject.Find("Elf18");
        debugOn = GameProperties.GetSnowmanCheat();
        GameObject snowmanGenerator = GameObject.Find("Snowman Generator");
        powerUp = snowmanGenerator.GetComponent<PowerUp>();
    }

    /* when in contact with candy cane or ribbon */
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
            stoledItem = true;
            item = collision.gameObject;
        }
    }

    /* follow player's X coordinates */
    void Update () {

        this.transform.position = new Vector3(player.transform.position.x,
                                         transform.position.y, transform.position.z);

        // debuging cheat mode
        if (Input.GetKeyDown(KeyCode.P)) stoledItem = true;

        // when given a gift, accept and disappear
        if(stoledItem == true)
        {
            Destroy(this.gameObject);
            Destroy(item);

            stoledItem = false;

            // magic poof particles
            ParticleSystem particle = Instantiate<ParticleSystem>(magic_poof);
            particle.transform.position = transform.position;

            particle.Play();

            // despawn snowman
            SnowmanGenerator.DeSpawn();

            // give a 50% chance of getting powerup
            powerUp.GivePowerUp();
        }
	}
}
