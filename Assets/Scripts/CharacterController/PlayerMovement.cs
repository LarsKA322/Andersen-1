using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;

    //GroundChecker, Velocity resetting
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        //This is like a child-friendly raycasting system. 
        //we will probably need to add raycasting system for checking what kind of element is hit, but for now this will do. 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Getting input for WASD controls
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //created local direction vector on where the player is facing
        Vector3 move = transform.right * x + transform.forward * z;
        Debug.Log(move);

        //In-built movement function inherited from characterController.
        //Time.deltaTime makes it framerate independent
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //find out what this equation is called? where is it frooooom?!
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        //due to the nature of gravity in y-axis, it is necessary to multiply once more with time.deltatime, since time is squared in the equation.
        controller.Move(velocity * Time.deltaTime);

    }
}
