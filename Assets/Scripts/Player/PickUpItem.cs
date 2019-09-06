using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    bool isCarrying;
    bool canPickSomethingNow;

    GameObject item;
    Pickable pickable;

    Vector3 heightOffset;
    Vector3 positionOffset;
    Vector3 rotationOffset;

    ICharacterController characterController;

    public Transform pickUpGuide;
    public Transform placeGuide;

    void Start()
    {
        // Reset values
        isCarrying = false;
        canPickSomethingNow = false;

        // Get Player Controller (Not CharacterController Class)
        characterController = GetComponent<ICharacterController>();
    }

    // Nearing a pickable item
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickable" && isCarrying == false)
        {
            canPickSomethingNow = true;

            // Get the GameObject
            item = other.gameObject;
        }
    }

    // Getting away from a pickable item
    void OnTriggerExit(Collider other)
    {
        canPickSomethingNow &= (other.tag != "Pickable" || isCarrying != false);

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Pick up item 
            if (!isCarrying && canPickSomethingNow)
            {
                isCarrying = true;

                // Make sure an item is selected
                if (item != null) 
                {
                    // Get item's position and rotation offset based on 
                    // player's character type
                    positionOffset = characterController.GetPickUpPositionOffset(item.name);
                    rotationOffset = characterController.GetPickUpRotationOffset(item.name);

                    // Get pickable components and pick it up
                    pickable = item.GetComponent<Pickable>();
                    pickable.PickUp(pickUpGuide, positionOffset, rotationOffset);

                    // Change tag of the object
                    item.tag = "Item";

                    // Animate Player character to carry item
                    characterController.StartsCarrying();
                }
            }

            // Put down item
            else if (isCarrying)
            {
                isCarrying = false;

                if (item != null) 
                {
                    // Get item's drop off height offset based on item's type
                    heightOffset = characterController.GetDropOffHeightOffset(item.name);

                    // Use Pickable to drop item 
                    pickable.PutDown(placeGuide, heightOffset);

                    // Change tag of the object
                    item.tag = "Pickable";

                    // Animate Player character to stop carrying item
                    characterController.StopsCarrying();
                }
                // Reset item & pickable variables
                item = null;
                pickable = null;
            }
        }

        // Check every frame to see if the item is still in player's
        if (item == null)
        {
            isCarrying = false;
            characterController.StopsCarrying();
        }

    }

}