using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBall : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 10.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    public bool freeCamOn = false;

    private float dist = 6.0f;
    private float curX = 0.0f;
    private float curY = 0.0f;
    private float sensX = 2.0f;
    private float sensY = 1.0f;

    private void Start()
    {
        camTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //3rd Person Follow
        curX += Input.GetAxis("Mouse X");
        curY += Input.GetAxis("Mouse Y");
        curY = Mathf.Clamp(curY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -dist);
        Quaternion rot = Quaternion.Euler(curY, curX, 0);
        camTransform.position = lookAt.position + rot * dir;
        camTransform.LookAt(lookAt.position);
    }

}
