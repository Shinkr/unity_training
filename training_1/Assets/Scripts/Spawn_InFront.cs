using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_InFront : MonoBehaviour
{

    public GameObject dirt_tile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Left Click.
        if (Input.GetKey(KeyCode.F))
        {
            GameObject newTile = Instantiate(dirt_tile);
            newTile.transform.position = transform.position + new Vector3(1, 0, 0);
            return;
        }
    }
}
