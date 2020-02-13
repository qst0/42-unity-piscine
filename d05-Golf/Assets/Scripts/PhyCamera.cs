using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhyCamera : MonoBehaviour
{

    float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            this.GetComponent<Rigidbody>().AddForce(
                Vector2.down * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.GetComponent<Rigidbody>().AddForce(
                Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody>().AddForce(
                Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddForce(
                Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Rigidbody>().AddForce(
                Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().AddForce(
                Vector3.right * speed);
        }
    }
}
