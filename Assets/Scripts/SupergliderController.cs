using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupergliderController : MonoBehaviour
{
    // Serialized variable that sets the rotation (or torque) amount of the player.
    [SerializeField] float rotateAmount = 1f;

    // Serialized variable that sets the player's boost speed.
    [SerializeField] float boostSpeed = 70f;

    // Serialized variable that sets the player's normal speed.
    [SerializeField] float normalSpeed = 35f;

    // Creation of a Rigidbody2D component variable.
    Rigidbody2D rigid2d;

    // Creation of a Surface effector component variable.
    SurfaceEffector2D surfaceEffector2D;

    // Boolean variable allowing the player to control the character set to true by default.
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        // The variable can now get a component from the Rigidbody 2D component when called later.
        rigid2d = GetComponent<Rigidbody2D>();

        // The variable can now get a type of object identified as surface effector 2D component when called later.
        // This FindObjectOfType method works like a component method, but only when one of its kind is used in the project.
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player's allowed to move...
        if (canMove)
        {
            // Call player controls.
            RotatePlayer();

            // Call player booster.
            RespondToBoost();
        }
    }

    // Controls disabling method to prevent the player from moving.
    public void DisableControls()
    {
       canMove = false;
    }

    // The Player rotation controls are stored in a method.
    // For readability purposes, it's preferable to stores methods apart and call them from Update.
    void RotatePlayer()
    {
        // If the input key pressed is the left arrow on the keyboard...
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // The Rigidbody 2D component will rotate the player on the left.
            rigid2d.AddTorque(rotateAmount);
        }
        // Otherwise, if the input key pressed is the right arrow on the keyboard...
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // The Rigidbody 2D component will rotate the player on the right, thanks to the negative value.
            rigid2d.AddTorque(-rotateAmount);
        }
    }

    void RespondToBoost ()
    {
        // If the input key pressed is the up arrow on the keyboard...
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // The surface effector 2D's speed will boost.
            surfaceEffector2D.speed = boostSpeed;
        }
        // Otherwise, if no other key is pressed...
        else
        {
            // The surface effector 2D's speed goes back to normal.
            surfaceEffector2D.speed = normalSpeed;
        }
    }
}