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
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Space is pressed down.
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            // Debug.Log("Space key was pressed down."); // Console.
            // Jumping Physics.
            //GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = true;
        }

        // Getting horizontal input.
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the map to the left.
        transform.position += Vector3.right * speed * Time.deltaTime;

        {
            // if (Input.GetKey(KeyCode.A))
            // {
            //     GetComponent<Rigidbody>().AddForce(Vector3.left / 10, ForceMode.VelocityChange);
            // }
            // 
            // if (Input.GetKey(KeyCode.D))
            // {
            //     GetComponent<Rigidbody>().AddForce(Vector3.right / 10, ForceMode.VelocityChange);
            // }
        }
    }

    // Will call every physics call.
    private void FixedUpdate()
    {
       if (jumpKeyWasPressed == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
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
