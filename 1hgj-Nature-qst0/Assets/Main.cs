using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] KeyCode keyMoveForward;
    [SerializeField] KeyCode keyMoveBack;
    [SerializeField] KeyCode keyMoveLeft;
    [SerializeField] KeyCode keyMoveRight;
    [SerializeField] float timberForce = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyMoveForward))
        {
          this.GetComponent<Rigidbody>().AddForce(
          new Vector3(0f,0f,1f) * timberForce);
        }
        if (Input.GetKey(keyMoveBack))
        {
            this.GetComponent<Rigidbody>().AddForce(
            new Vector3(0f, 0f, -1f) * timberForce);
        }
        if (Input.GetKey(keyMoveLeft))
        {
            this.GetComponent<Rigidbody>().AddForce(
            new Vector3(-1f, 0f, 0f) * timberForce);
        }
        if (Input.GetKey(keyMoveRight))
        {
            this.GetComponent<Rigidbody>().AddForce(
            new Vector3(1f, 0f, 1f) * timberForce);
        }
    }
}

/*
{
    [SerializeField] private List<GameObject> players = new List<GameObject>();
[SerializeField] private List<bool> playerWinning = new List<bool>();
[SerializeField] private List<float> playerMoveSpeed = new List<float>();
[SerializeField] private List<float> playerJumpPower = new List<float>();

[SerializeField] private List<GameObject> winZones = new List<GameObject>();
[SerializeField] private List<LayerMask> layers = new List<LayerMask>();


private int playerFocusChoice = 1;

private float playerXDirection = 0;
private float playerYDirection = 0;
bool playerHasCommand = false;
bool playerHasJumpCommand = false;

void Start()
{
}

// Update is for:
// Input
// Camera Update
// Win Checking
private void Update()
{

    //Reload on R or Backspace.
    if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Backspace))
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Player Select
    if (Input.GetKey(KeyCode.Alpha1))
    {
        playerFocusChoice = 1;
    }
    if (Input.GetKey(KeyCode.Alpha2))
    {
        playerFocusChoice = 2;
    }
    if (Input.GetKey(KeyCode.Alpha3))
    {
        playerFocusChoice = 3;
    }
    // Player Select Camera Move:
    this.transform.position = new Vector3(
        players[playerFocusChoice].transform.position.x,
        players[playerFocusChoice].transform.position.y,
        -15f); ; //todo zoom level

    //End Player Select

    //Player Commands:
    //Move Command
    if (Input.GetKey(KeyCode.A))
    {
        playerHasCommand = true;
        playerXDirection = -10;
    }
    else if (Input.GetKey(KeyCode.D))
    {
        playerHasCommand = true;
        playerXDirection = 10;
    }
    else
    {
        //todo might need moved to fixedupdate...
        playerHasCommand = false;
        playerXDirection = 0;
    }

    //Jump Command:
    if (Input.GetKeyDown(KeyCode.Space))
    {
        playerHasJumpCommand = true;
    }

    //check if players are in win zones
    for (int i = 1; i <= 3; i++)
    {
        if (Mathf.Abs(players[i].transform.position.x - winZones[i].transform.position.x) < 0.2f
            && Mathf.Abs(players[i].transform.position.y - winZones[i].transform.position.y) < 0.2f)
        {
            playerWinning[i] = true;
        }
        else
        {
            playerWinning[i] = false;
        }
    }
    if (playerWinning[1] && playerWinning[2] && playerWinning[3])
    {
        playerWinning[0] = true;
    }
    else
    {
        playerWinning[0] = false;
    }
    //End win check

}

// Fixed Update is for physics.
// Applying the Movement
// Applying the Jump
void FixedUpdate()
{
    if (playerFocusChoice != 0 && playerHasCommand)
    {
        players[playerFocusChoice].GetComponent<Rigidbody2D>().AddForce(
            new Vector2(playerXDirection, playerYDirection) * playerMoveSpeed[playerFocusChoice]);
    }

    //Jump Command:
    if (playerHasJumpCommand)
    {
        playerHasJumpCommand = false;
        float distToGround = players[playerFocusChoice].GetComponent<BoxCollider2D>().bounds.extents.y + 0.2f;
        RaycastHit2D hit2D = Physics2D.Raycast(
            players[playerFocusChoice].transform.position, Vector2.down, distToGround,
            layers[playerFocusChoice]);
        if (hit2D)
        {
            players[playerFocusChoice].GetComponent<Rigidbody2D>().AddForce(
                Vector2.up * playerJumpPower[playerFocusChoice]);
        }
    }
}
*/