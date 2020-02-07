using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    bool pointScored = false;
    [SerializeField] private GameObject bird;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.GetComponent<Bird>().gameOver)
        {
            //score when past
            if (!pointScored && this.transform.position.x < -6f)
            {
                pointScored = true;
                bird.GetComponent<Bird>().score += 5;
                speed += 0.01f;
            }

            //Reset
            if (this.transform.position.x < -12f)
            {
                this.transform.position = new Vector3(12f, 1, -10f);
                pointScored = false;
            }
            else // move to the left
            {
                this.transform.Translate(-speed, 0f, 0f);
            }
        }
    }
}
