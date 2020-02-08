using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private List<GameObject> players = new List<GameObject>();
    [SerializeField] private List<LayerMask> layers = new List<LayerMask>();

    private int playerFocusChoice = 1;

    private float playerXDirection = 0;
    private float playerYDirection = 0;
    private int forceAmount = 1;
    bool playerHasCommand = false;
    bool playerHasJumpCommand = false;

    void Start()
    {
    }

    // Update is for input.
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


    }

    // Fixed Update is for physics.
    void FixedUpdate()
    {
        if (playerFocusChoice != 0 && playerHasCommand) 
        {
            players[playerFocusChoice].GetComponent<Rigidbody2D>().AddForce(
                new Vector2(playerXDirection, playerYDirection) * forceAmount);
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
                    Vector2.up * 420);
            }
        }
    }
}