using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{

    float flapPowerAdd;
    float flapPower;
    public int score;
    public bool gameOver = false;
    float timePassed;
    [SerializeField] private GameObject pipeGroup1;
    [SerializeField] private GameObject pipeGroup2;

    // Start is called before the first frame update
    void Start()
    {
        flapPowerAdd = .8f;
        flapPower = 0f;
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //game loss / flap logic
        if (!gameOver)
        {

            // Floor and roof oof!
            if (this.transform.position.y > 7f
                    || this.transform.position.y < -3f)
            {
                gameOver = true;
            }

            //Collision with pipes
            if (pipeGroup1.transform.position.x < -2.8f
                && pipeGroup1.transform.position.x > -6f)
            {
                if (this.transform.position.y > 2f
                    || this.transform.position.y < 0f)
                {
                    gameOver = true;
                }
            }
            if (pipeGroup2.transform.position.x < -2.8f
                && pipeGroup2.transform.position.x > -6f)
            {
                if (this.transform.position.y > 2f
                    || this.transform.position.y < 0f)
                {
                    gameOver = true;
                }
            }

            // movement logics
            if (Input.GetKeyDown(KeyCode.Space))
            {
                flapPower = flapPowerAdd;
            }
            if (flapPower > 0)
            {
                this.transform.Translate(0f, 0.05f, 0f);
                flapPower -= 0.05f;
            }
            else
            {
                this.transform.Translate(0f, -0.05f, 0f);
            }

        } else //GameOver...
        {
            Debug.Log("Game Over !");
            Debug.Log("Score: " + score);
            Debug.Log("Time: " + Mathf.RoundToInt(timePassed));
            Debug.Log("Press Space to Restart the Game.");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        timePassed += Time.deltaTime;
    }
}
