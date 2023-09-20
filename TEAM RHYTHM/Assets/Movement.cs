using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int movementInterval;
    public float boundsUp, boundsDown, boundsLeft, boundsRight;
    public KeyCode up, down, left, right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(up) && transform.position.y < boundsUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movementInterval, transform.position.z);
        }
        if (Input.GetKeyDown(down) && transform.position.y > boundsDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - movementInterval, transform.position.z);
        }
        if (Input.GetKeyDown(left) && transform.position.x > boundsLeft)
        {
            transform.position = new Vector3(transform.position.x - movementInterval, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(right) && transform.position.x < boundsRight)
        {
            transform.position = new Vector3(transform.position.x + movementInterval, transform.position.y, transform.position.z);
        }
    }
}
