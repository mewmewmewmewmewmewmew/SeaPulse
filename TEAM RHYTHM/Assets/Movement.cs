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
    private Vector3 lastPosition;
    public GameObject _mashableNote;
    public InputAction playerMash;

    private void OnEnable()
    {
        playerMash.Enable();

    }
    private void OnDisable()
    {
        playerMash.Disable();

    }


    // Start is called before the first frame update
    void Start()
    {
        GameObjectPlayerIndex = GameObject.Find("PlayerManager");
        PlayerIndexScript = GameObjectPlayerIndex.GetComponent<PlayerManager>();
        //playerIndex = PlayerIndex.playerIndex;
        transform.position = startPositions[PlayerIndexScript.PlayerIndex];
        GameObject _GO = Instantiate(ArtIntegration[PlayerIndexScript.PlayerIndex], transform.position, ArtIntegration[PlayerIndexScript.PlayerIndex].transform.rotation, transform);
        GameObjectPlayerIndex.GetComponent<PlayerManager>().AddIndex();


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > boundsUp  || transform.position.y < boundsDown || transform.position.x < boundsLeft || transform.position.x > boundsRight)
        {
            transform.position = lastPosition;
        }

        if(playerMash.triggered)
        {
            newMashInput();
        }
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

    private void PlayerMash_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    bool isPressed = false;

    public void Move(InputAction.CallbackContext ctx)
    {
        lastPosition = transform.position;
        if (ctx.performed && !isPressed )
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

    public bool mashPressed = false;

    public void MashInput(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && !mashPressed)
        {
            mashPressed = true;
            _mashableNote = GameObject.FindGameObjectWithTag("Mash");
            _mashableNote.GetComponent<NoteProperties>().Mash();
            Debug.Log("pressed");
            if(_mashableNote=null) 
            {
                isPressed = false;
                return; 
            }

        }
        if (ctx.canceled)
        {
            isPressed = false;
        }

    }

    public void newMashInput()
    {

        _mashableNote = GameObject.FindGameObjectWithTag("Mash");
        _mashableNote.GetComponent<NoteProperties>().Mash();
    }
}
