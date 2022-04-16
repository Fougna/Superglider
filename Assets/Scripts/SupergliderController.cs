using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupergliderController : MonoBehaviour
{
    // Serialized variable that sets the rotation (or torque) amount of the player.
    [SerializeField] float rotateAmount = 1f;

    // Creation of a Rigidbody2D component variable.
    Rigidbody2D rigid2d;

    // Start is called before the first frame update
    void Start()
    {
        // The variable can now get a component from the Rigidbody 2D component when called later.
        rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
}