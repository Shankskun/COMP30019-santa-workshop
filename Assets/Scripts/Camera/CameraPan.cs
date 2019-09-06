using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    public GameObject target;
    public float rotateSpeed = 1.5f;

    // offset for camera to player
    public Vector3 offset;
    // starting point of player
    private Vector3 center;
    // previous position of player (z axis)
    private float preZ;

	void Start ()
    {
        // initial left right coordinate (z axis)
        preZ = target.transform.position.z;

        // center point of player (x axis)
        center = target.transform.position - offset;

    }

    /* pans the camera */
    void Update ()
    { 
        Vector3 rotate = transform.eulerAngles;

        // elf is moving (left to right)
        if ( HasMoved(preZ, target.transform.position.z) )
        {
            rotate.y += Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        }
        // pan camera
        transform.eulerAngles = rotate;

        // assign new previous values (z axis)
        preZ = target.transform.position.z;
    }

    /* move camera forward */
    private void FixedUpdate()
    {
        Vector3 desiredPos = target.transform.position - offset;
        Vector3 smooth;

        // when player is further away in the room
        if(desiredPos.x <= center.x)
        {
            smooth = Vector3.Lerp(transform.position, desiredPos, 0.05f);
        }
        // closer towards the cam, fix the camera
        else
        {
            smooth = Vector3.Lerp(transform.position, center, 0.05f);
        }
        // trasnform the camera position
        transform.position = new Vector3(smooth.x, transform.position.y, transform.position.z);
    } 

    /* check elf's previoud pos */
    private bool HasMoved(float previous, float current)
    {
        // difference in z axis from previous update frame (precision to 2 dec)
        float diff = Mathf.Round((current - previous) * 100f) / 100f;

        // assign new privious point
        previous = target.transform.position.z;

        // has moved
        if (diff != 0.0f ) return true;
        
        // hasnt moved
        else return false;
    }
}
