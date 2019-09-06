using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {

    // Speed of Box & Multipler
    private float speed;
    private float multipler;
    private float slowDownRate;

    // Gravity speed
    private readonly float gravity = -0.1f;

    private bool isOnConveyorBelt;


    void Start()
    {
        // Get speed of box 
        speed = GameProperties.GetBoxMovementSpeed();

        // Set initial isOnConveyorBelt value
        isOnConveyorBelt = false;

        // get powerup slowdown rate of time
        slowDownRate = GameProperties.GetSlowTimePowerUp();
    }

    private void FixedUpdate()
    {
        // Let box falls if it has not collided with conveyor belt
        if (!isOnConveyorBelt) 
        {
            transform.position += new Vector3(0, gravity, 0);
        }

        // If boxes is on conveyor belt, moves it
        else 
        {
            // Get speed multiplier (speeds up when short in time)
            multipler = MultiplyerSpeed.GetMultiplyer();

            // if powerup is activated
            if (PowerUp.snowmanIsDestroyed == true) multipler = multipler * slowDownRate;

            // Moving the box 
            float step = multipler * speed * Time.deltaTime;
            transform.position += new Vector3(step, 0, 0);
        }
       
    }


    // If box collides with the conveyor belt 
    private void OnCollisionEnter(Collision collision)
    {
        // Set isOnConveyorBelt to true
        isOnConveyorBelt |= collision.gameObject.name.Equals("BeltMesh");
    }

}