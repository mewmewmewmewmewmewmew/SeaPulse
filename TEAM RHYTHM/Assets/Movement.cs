using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public int movementInterval;
    public float boundsUp, boundsDown, boundsLeft, boundsRight;
    public KeyCode up, down, left, right;
    bool deadzoneWait;

    private static int playerIndex = 0;
    public Material[] materials;
    public Vector3[] startPositions;
    [SerializeField] private GameObject[] ArtIntegration;

    public GameObject GameObjectPlayerIndex;
    public PlayerManager PlayerIndexScript;


    // Start is called before the first frame update
    void Start()
    {
        GameObjectPlayerIndex = GameObject.Find("PlayerManager");
        PlayerIndexScript = GameObjectPlayerIndex.GetComponent<PlayerManager>();
        GameObjectPlayerIndex.GetComponent<PlayerManager>().AddIndex();
        //playerIndex = PlayerIndex.playerIndex;
        transform.position = startPositions[PlayerIndexScript.PlayerIndex];
        GetComponent<MeshRenderer>().materials[0] = materials[PlayerIndexScript.PlayerIndex];

            GameObject _GO = Instantiate(ArtIntegration[PlayerIndexScript.PlayerIndex], transform.position, ArtIntegration[PlayerIndexScript.PlayerIndex].transform.rotation, transform);
        

    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(up) && transform.position.y < boundsUp)
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

        if (Input.GetAxis("Vertical") > 0.2f && !deadzoneWait && transform.position.y < boundsUp)
        {
            deadzoneWait = true;
        }
        if (Input.GetAxis("Vertical") < 0.2f && Input.GetAxis("Vertical") > -0.2f && !deadzoneWait && transform.position.y < boundsUp)
        {
            deadzoneWait = false;
        }
        if (Input.GetAxis("Horizontal") > 0.2f && !deadzoneWait && transform.position.y < boundsUp)
        {
            deadzoneWait = true;
        }
        if (Input.GetAxis("Horizontal") < 0.2f && Input.GetAxis("Vertical") > -0.2f && !deadzoneWait && transform.position.y < boundsUp)
        {
            deadzoneWait = false;
        }*/



    }

    bool isPressed = false;

    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !isPressed /*&& transform.position.y < boundsUp +1 && transform.position.y > boundsDown-1 && transform.position.x > boundsLeft-1 && transform.position.x < boundsRight+1*/)
        {
            isPressed = true;
            Vector2 dir = ctx.ReadValue<Vector2>();
            dir.x = Mathf.RoundToInt(dir.x);
            dir.y = Mathf.RoundToInt(dir.y);
            Debug.Log(dir);
            transform.position = new Vector3(transform.position.x + (dir.x * movementInterval), transform.position.y + (dir.y * movementInterval), transform.position.z);
        }

        if (ctx.canceled)
        {
            isPressed = false;
        }
    }
}
