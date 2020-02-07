using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private float timePassed = 0f;
    private float nextSpawn = 1f;
    private float spawnWait = 1f;
    private float spawnAdvance = 0.005f;
    private float spawnMinWait = 0.3f;
    private int cubeCursor = 0;
    List<GameObject> cubes = new List<GameObject>();
    [SerializeField] private GameObject spawnerLeft;
    [SerializeField] private GameObject spawnerMid;
    [SerializeField] private GameObject spawnerRight;
    [SerializeField] private GameObject barLow;
    [SerializeField] private GameObject noteCube;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed > nextSpawn)
        {
            nextSpawn += spawnWait;
            if (spawnWait > spawnMinWait) {
                spawnWait -= spawnAdvance;
            }

            switch (Random.Range(0, 3))
            {
                case 0:
                    cubes.Add(Instantiate(noteCube,
                        new Vector3(
                        spawnerLeft.transform.position.x,
                        spawnerLeft.transform.position.y,
                        spawnerLeft.transform.position.z), Quaternion.identity));
                    cubes[cubes.Count - 1].GetComponent<Cube>().lane = 0;
                    break;
                case 1:
                    cubes.Add(Instantiate(noteCube,
                        new Vector3(
                        spawnerMid.transform.position.x,
                        spawnerMid.transform.position.y,
                        spawnerMid.transform.position.z), Quaternion.identity));
                    cubes[cubes.Count - 1].GetComponent<Cube>().lane = 0;
                    break;
                case 2:
                    cubes.Add(Instantiate(noteCube,
                        new Vector3(
                        spawnerRight.transform.position.x,
                        spawnerRight.transform.position.y,
                        spawnerRight.transform.position.z), Quaternion.identity));
                    cubes[cubes.Count - 1].GetComponent<Cube>().lane = 2;
                    break;
            }
            //
            if (cubes[cubeCursor].transform.position.y < -4)
            {
                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
                Debug.Log("Precision: MISS! Too Late!");
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (cubes[cubeCursor].GetComponent<Cube>().lane == 0)
            {

                Debug.Log("Precision: " +
                (cubes[cubeCursor].transform.position.y - barLow.transform.position.y));

                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
            }
            else
            {
                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
                Debug.Log("Precision: MISS! Wrong Lane!");
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (cubes[cubeCursor].GetComponent<Cube>().lane == 1)
            {
                Debug.Log("Precision: " +
                (cubes[cubeCursor].transform.position.y - barLow.transform.position.y));

                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
            }
            else
            {
                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
                Debug.Log("Precision: MISS! Wrong Lane!");
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (cubes[cubeCursor].GetComponent<Cube>().lane == 2)
            {
                Debug.Log("Precision: " +
                (cubes[cubeCursor].transform.position.y - barLow.transform.position.y));
                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
            }
            else
            {
                GameObject.Destroy(cubes[cubeCursor]);
                cubeCursor++;
                Debug.Log("Precision: MISS! Wrong Lane!");
            }
        }

        timePassed += Time.deltaTime;
    }
}
