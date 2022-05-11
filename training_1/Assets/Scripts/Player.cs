using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour // Collection of variables and functions that C# can use.
{

    // Variables
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private bool isGrounded;
    public float jumpHeight = 5;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Space is pressed down.
        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded)
        {
            // Debug.Log("Space key was pressed down."); // Console.
            // Jumping Physics.
            jumpKeyWasPressed = true;
        }

        // Getting horizontal input.
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the map to the left.
        // transform.position += Vector3.right * speed * Time.deltaTime;


        // Left and right movement.
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left / moveSpeed, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right / moveSpeed, ForceMode.VelocityChange);
        }
    }

    // Will call every physics call.
    private void FixedUpdate()
    {
       if (jumpKeyWasPressed == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}
