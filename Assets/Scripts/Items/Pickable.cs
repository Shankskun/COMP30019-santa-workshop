using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    private Rigidbody rb;
    private Renderer rend;

    // Initialize required components
    void Start()
    {
        // Get and set rigidbody
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = true;

        // Get renderer
        rend = this.GetComponent<Renderer>();
    }

    // Call when Player picks this up
    public void PickUp(Transform pickupGuide, Vector3 positionOffset, Vector3 rotationOffset) 
    {
        this.GetComponent<MeshRenderer>().enabled = true;

        // Set realistic rigidbody effect
        rb.useGravity = false;
        rb.isKinematic = true;

        // Lock item's position accordingly to Player
        transform.position = pickupGuide.position;
        transform.parent = pickupGuide;

        // Set the item to be in the right position relatively to the Player
        transform.LookAt(pickupGuide.parent);
        transform.localPosition += positionOffset;
        transform.localEulerAngles = rotationOffset;
    }

    // Call when Player drops this down
    public void PutDown(Transform placeGuide, Vector3 heightOffset) 
    {
        // Set realistic rigidbody effects
        rb.useGravity = true;
        rb.isKinematic = false;

        // Set item free
        transform.parent = null;

        // Set item orientation and position in world + its drop off height offset
        transform.position = placeGuide.position + heightOffset;
    }

}
