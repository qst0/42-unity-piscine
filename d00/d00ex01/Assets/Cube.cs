using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int lane = 0; //0 left 1 mid right 2
    public float fallSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = Random.Range(0.09f, 0.12f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0f, -fallSpeed, 0f);
    }
}
