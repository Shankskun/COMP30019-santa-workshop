using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMovement : MonoBehaviour {

    public Material _beltMaterial;
    private float offset;
    private float speed;

    // Movement speed
    private float multipler;
    private float slowDownRate;

    // Get material of belt
    void Start () 
    {
        speed = GameProperties.GetConveyorBeltSpeed();
        _beltMaterial = this.GetComponent<Renderer>().material;

        // get powerup slowdown rate of time
        slowDownRate = GameProperties.GetSlowTimePowerUp();
    }
	
	// Move this material 
	void Update () 
    {
        // Speed up when short in time
        multipler = MultiplyerSpeed.GetMultiplyer();

        // if powerup is activated
        if (PowerUp.snowmanIsDestroyed == true) multipler = multipler * slowDownRate;

        // Move belt
        offset = Time.time * speed * multipler;
        _beltMaterial.mainTextureOffset = new Vector2(0, -offset);
    }
}
