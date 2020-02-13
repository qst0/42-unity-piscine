using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Camera GolfCam;
    [SerializeField] public GameObject GolfBall;

    public bool golfing = false;
    public CharacterController controller;
    public float speed = 12f;
    public float jumpPow = 3f;

    public float grav = -9.81f;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Exit Code  
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        if (Input.GetButtonDown("Fire1"))
        {
            golfing = !golfing;
        }
        if (golfing)
        {
            GolfCam.enabled = true;
            if (Input.GetButton("Jump"))
            {
                GolfBall.GetComponent<Rigidbody>().AddForce(
                    Vector3.forward * 1000);
            }
        }
        else
        {
            GolfCam.enabled = false;

            //Simple Player Controller
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f; //0 makes sense, but this is a bit better.
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpPow * -2f * grav);
            }

            velocity.y += grav * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
