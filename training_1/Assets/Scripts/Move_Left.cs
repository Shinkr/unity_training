using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour
{

    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the map to the left.
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
