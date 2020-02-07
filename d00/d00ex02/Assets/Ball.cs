using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject Putter;
    [SerializeField] private GameObject Hole;
    float putterStart = 0f;
    float swingPower = 0f;
    int score = -15;
    bool PutterNeedsReset = false;
    bool bounced = false;
    bool youWon = false;
    // Start is called before the first frame update
    void Start()
    {
        putterStart = Putter.transform.position.z;
    }

    private bool golfApprox(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }

    // Update is called once per frame
    void Update()
    {
        //check for hole
        if (!youWon && swingPower < 0.3f
            && Mathf.Abs(this.transform.position.z - Hole.transform.position.z) < 0.3f)
        {
            
            if (this.transform.position.y > -1.5)
            {
                //Debug.Log("Going in the hole! " + swingPower);
                this.transform.Translate(0f, -0.25f, 0f);
            } else
            {
                //Debug.Log("YOU WON!");
                Debug.Log("Score: "+score);
                youWon = true;
            }
        } else if (youWon)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (!youWon && Input.GetKey(KeyCode.Space) && Putter.transform.position.z < this.transform.position.z) {
            Putter.transform.Translate(0f, 0f, -0.1f, Space.World);
            //Debug.Log("charging putt...");

        }
        else if (!youWon)//not pressing space
        {
            //swinging towards
            if (Putter.transform.position.z < putterStart)
            {
                Putter.transform.Translate(0f, 0f, 0.1f, Space.World);
                swingPower += 0.03f;
            } //bounce and hit
            else if (swingPower > 0 && golfApprox(Putter.transform.position.z, putterStart, 0.1f))
            {
                //Debug.Log("ball moving...");

                PutterNeedsReset = true;
                if (bounced)
                {
                    if (this.transform.position.z - swingPower < -3.14f)
                    {
                        bounced = false;
                    }
                    else
                    {
                        this.transform.Translate(0f, 0f, -swingPower);
                    }
                }
                else
                {
                    if (this.transform.position.z - swingPower > 10.29f)
                    {
                        bounced = true;
                    }
                    else
                    {
                        this.transform.Translate(0f, 0f, swingPower);
                    }
                }
                swingPower -= 0.01f;
            }
            else if (PutterNeedsReset == true)
            {
                score += 5;
                //Debug.Log("RESETTING");
                PutterNeedsReset = false;
                bounced = false;
                swingPower = 0;
                putterStart = (this.transform.position.z - 0.3f);
                Putter.transform.position = new Vector3(
                    Putter.transform.position.x,
                    Putter.transform.position.y,
                    putterStart
                    );
                //Putter.transform.Translate(0f, 0f, putterStart, Space.World);
                //putterStart = Putter.transform.position.z;
            }
        }
    }
}
