using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloon_logic : MonoBehaviour
{

    [SerializeField] private Sprite pop0;
    [SerializeField] private GameObject breathCube;
    [SerializeField] private GameObject balloon;
    private float breathLeft = 1f;
    private bool popped = false;
    private float timePassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        breathCube.transform.localScale = new Vector3(0.1f,breathLeft,0.1f);

        if (balloon.transform.localScale.x < 1.7f)
        {
            if (Input.GetKeyDown(KeyCode.Space) && breathLeft > 0.1f)
            {
                breathLeft -= 0.1f;
                balloon.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            } else if (breathLeft < 1f)
            {
                breathLeft += 0.005f;
            }
            if (balloon.transform.localScale.x > 0.1f)
            {
                balloon.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            }
        }
        else if (balloon.transform.localScale.x >= 1.7f && !popped)
        {
            balloon.gameObject.GetComponent<SpriteRenderer>().sprite = pop0;
            popped = true;
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(timePassed) + "s");
        }
        timePassed += Time.deltaTime;
    }
}
