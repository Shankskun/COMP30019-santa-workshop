using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All Playable Character's controller must implement this interface
public interface ICharacterController {

    // Animate Player character to carry item
    void StartsCarrying();

    // Animate Player character to stop carrying item
    void StopsCarrying();

    // Get item's pick up position offset
    Vector3 GetPickUpPositionOffset(string item);

    // Get item's pick up rotation offset 
    Vector3 GetPickUpRotationOffset(string item);

    // Get item's drop off height offset 
    Vector3 GetDropOffHeightOffset(string item);
}
