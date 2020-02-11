using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{
    [SerializeField]
    private RectTransform selectBoxImage;

    Vector3 startPos;
    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        selectBoxImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Pressing the mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            if (Physics.Raycast(
                Camera.main.ScreenPointToRay(Input.mousePosition),
                out rayHit,
                Mathf.Infinity
                ))
            {
                startPos = rayHit.point;
            }
        }

        //Release the mouse button.
        if (Input.GetMouseButtonUp(0))
        {
            selectBoxImage.gameObject.SetActive(false);
        }

        //Holding the mouse button.
        if (Input.GetMouseButton(0))
        {
            if (!selectBoxImage.gameObject.activeInHierarchy)
            {
                selectBoxImage.gameObject.SetActive(true);
            }
            endPos = Input.mousePosition;

            Vector3 selectBoxStart = Camera.main.WorldToScreenPoint(startPos);
            selectBoxStart.z = 0f;

            Vector3 center = (selectBoxStart + endPos) / 2f;

            selectBoxImage.position = center;

            float sizeX = Mathf.Abs(selectBoxStart.x - endPos.x);
            float sizeY = Mathf.Abs(selectBoxStart.y - endPos.y);

            selectBoxImage.sizeDelta = new Vector2(sizeX, sizeY);
        }
    }
}
