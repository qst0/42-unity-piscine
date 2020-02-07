using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject PadelLeft;
    [SerializeField] private GameObject PadelRight;
    [SerializeField] private GameObject PongBall;
    private float PongBallHSpeed;
    private float PongBallVSpeed;
    int scoreLeft = 0;
    int scoreRight = 0;
    bool pongBallNeedsReset = false;

    // Start is called before the first frame update
    void Start()
    {
        int choice = Random.Range(0, 2);
        PongBallVSpeed = choice == 0 ? -0.1f : 0.1f;
        choice = Random.Range(0, 2);
        PongBallHSpeed = choice == 0 ? -0.1f : 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        //Player Left
        if (Input.GetKey(KeyCode.W) &&
            PadelLeft.transform.position.y < 4.5)
        {
            PadelLeft.transform.Translate(0f, 0.1f, 0f);
        } else if (Input.GetKey(KeyCode.S) &&
            PadelLeft.transform.position.y > -4.5)
        {
            PadelLeft.transform.Translate(0f, -0.1f, 0f);
        }

        //Player Right
        if (Input.GetKey(KeyCode.UpArrow) &&
            PadelRight.transform.position.y < 4.5)
        {
            PadelRight.transform.Translate(0f, 0.1f, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) &&
            PadelRight.transform.position.y > -4.5)
        {
            PadelRight.transform.Translate(0f, -0.1f, 0f);
        }

        //PongBall

        //Check for out of Bounds.
        //Left Side Miss!
        if (PongBall.transform.position.x < -12)
        {
            scoreRight++;
            pongBallNeedsReset = true;
        }
        //Right Side Miss!
        if (PongBall.transform.position.x > 12)
        {
            scoreLeft++;
            pongBallNeedsReset = true;
        }
        //If needed, reset the Pong Ball
        if (pongBallNeedsReset)
        {
            pongBallNeedsReset = false;
            Debug.Log("Player 1: " + scoreLeft + " | Player 2: " + scoreRight);
            PongBall.transform.position = new Vector3(0, 0, 0);
            int choice = Random.Range(0, 2);
            PongBallVSpeed = choice == 0 ? -0.1f : 0.1f;
            choice = Random.Range(0, 2);
            PongBallHSpeed = choice == 0 ? -0.1f : 0.1f;
        }

        //Check for bounces
        //With the
        //Roof
        if (PongBall.transform.position.y + PongBallVSpeed > 4.5)
        {
            PongBallVSpeed = -PongBallVSpeed;
        }
        //Floor
        if(PongBall.transform.position.y + PongBallVSpeed < -4.5)
        {
            PongBallVSpeed = -PongBallVSpeed;
        }

        //With the Players
        //Player Left
        if(PongBall.transform.position.x + PongBallHSpeed < -9
            && PongBall.transform.position.x + PongBallHSpeed > -9.1)
        {
            if (Mathf.Abs(PadelLeft.transform.position.y - PongBall.transform.position.y) < 1.5)
            {
                PongBallHSpeed = -PongBallHSpeed;
            }
        }


        //Player Right
        if (PongBall.transform.position.x + PongBallHSpeed > 9
            && PongBall.transform.position.x + PongBallHSpeed < 9.1)
        {
            if(Mathf.Abs(PadelRight.transform.position.y - PongBall.transform.position.y) < 1.5)
            {
                PongBallHSpeed = -PongBallHSpeed;
            }
        }

        //Move
        PongBall.transform.Translate(PongBallHSpeed, PongBallVSpeed, 0f);

    }
}
