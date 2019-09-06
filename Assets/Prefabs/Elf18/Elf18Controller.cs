using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced From: "https://answers.unity.com/questions/1065763/how-to-make-character-rotate-in-direction-of-movem.html"
// Referenced From: "https://www.youtube.com/watch?v=BEIaakl9vJE" 

public class Elf18Controller : MonoBehaviour, ICharacterController
{

    static Animator animator;
    static CharacterController characterController;

    public float speed = 10.0f;
    public float gravity = 100.0f;

    static bool isCarrying = false;

    // All items' pick up position, rotation offsets, and drop off height offsets arbitrarily 
    // selected for this character only
    private static readonly Vector3 Elf18CandyPositionOffset = new Vector3(0.15f, 0, 0.05f);
    private static readonly Vector3 Elf18CandyRotationOffset = new Vector3(90, 90, 0);

    private static readonly Vector3 Elf18RibbonPositionOffset = new Vector3(-0.08f, -0.33f, -0.11f);
    private static readonly Vector3 Elf18RibbonRotationOffset = new Vector3(0, 0, 0);

    private static readonly Vector3 Elf18CandyDropOffHeightOffset = new Vector3(0, 0.15f, 0);
    private static readonly Vector3 Elf18RibbonDropOffHeightOffset = new Vector3(0, -0.15f, 0);

    /* Get animations and controller */
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {

        animator.SetBool("isCarrying", isCarrying);

        /* Animation Part */
        // When moving
        if (characterController.velocity != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
        }
        // When standing
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }



        /* Movement Part */
        // Gets the direction
        Vector3 direction = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal"));

        // This prevents going faster when running diagonically
        if (direction.sqrMagnitude > 1f)
        {
            direction = direction.normalized;
        }

        //Multiplies the movement speed
        Vector3 velocity = direction * speed;

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        velocity.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(velocity * Time.deltaTime);
        Vector3 facingrotation = Vector3.Normalize(direction);

        // This condition prevents from spamming "Look rotation viewing vector is zero" when not moving.
        if (facingrotation != Vector3.zero)
        {
            transform.forward = facingrotation;
        }

    }

    // Animate Player character to carry item
    void ICharacterController.StartsCarrying()
    {
        isCarrying = true;
    }

    // Animate Player character to stop carrying item
    void ICharacterController.StopsCarrying()
    {
        isCarrying = false;
    }

    // Get pick up position offset based on item type
    Vector3 ICharacterController.GetPickUpPositionOffset(string item)
    {
        var posOffset = item.Equals("PrefabCandy-Cane(Clone)") ? 
                            Elf18CandyPositionOffset : Elf18RibbonPositionOffset;

        return posOffset;
    }

    // Get pick up rotation offset based on item type
    Vector3 ICharacterController.GetPickUpRotationOffset(string item)
    {
        var rotOffset = item.Equals("PrefabCandy-Cane(Clone)") ? 
                            Elf18CandyRotationOffset : Elf18RibbonRotationOffset;

        return rotOffset;
    }

    // Get item's drop off height offset based on item type
    public Vector3 GetDropOffHeightOffset(string item)
    {
        var heightOffset = item.Equals("PrefabCandy-Cane(Clone)") ?
                            Elf18CandyDropOffHeightOffset : Elf18RibbonDropOffHeightOffset;

        return heightOffset;
    }
}
