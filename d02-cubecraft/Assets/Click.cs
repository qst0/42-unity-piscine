using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask SelectableObjectsLayer;

    private List<GameObject> selectedObjects;

    [HideInInspector]
    public List<GameObject> selectableObjects;

    private Vector3 mousePos1;
    private Vector3 mousePos2;

    private void clearSelectedObjects()
    {
        if (selectedObjects.Count > 0)
        {
            foreach (GameObject obj in selectedObjects)
            {
                ClickOn objClickOnScript = obj.GetComponent<ClickOn>();
                objClickOnScript.currentlySelected = false;
                objClickOnScript.ClickMe();
            }
            selectedObjects.Clear();
        }
    }

    private void SelectObjects()
    {
        List<GameObject> remObjects = new List<GameObject>();

        if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            clearSelectedObjects();
        }

        Rect selectRect = new Rect(mousePos1.x, mousePos1.y,
            mousePos2.x - mousePos1.x,
            mousePos2.y - mousePos1.y);

        foreach (GameObject obj in selectableObjects)
        {
            if (obj != null)
            {
                if (selectRect.Contains(Camera.main.WorldToViewportPoint(obj.transform.position), true))
                {
                    selectedObjects.Add(obj);
                    ClickOn objClickOnScript = obj.GetComponent<ClickOn>();
                    objClickOnScript.currentlySelected = true;
                    objClickOnScript.ClickMe();
                }
            }
            else
            {
                remObjects.Add(obj);
            }
        }

        if (remObjects.Count > 0)
        {
            foreach (GameObject obj in remObjects)
            {
                selectableObjects.Remove(obj);
            }
            remObjects.Clear();
        }
    }

    private void Awake()
    {
        selectedObjects = new List<GameObject>();
        selectableObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Clear on Right Click
        if (Input.GetMouseButtonDown(1))
        {
            clearSelectedObjects();
        }

        // Select on Left Click
        if (Input.GetMouseButtonDown(0))
        {
            mousePos1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            RaycastHit rayHit;

            if (Physics.Raycast(
                Camera.main.ScreenPointToRay(Input.mousePosition),
                out rayHit,
                Mathf.Infinity,
                SelectableObjectsLayer))
            {
                ClickOn clickOnScript = rayHit.collider.GetComponent<ClickOn>();

                // Additional Select on Left Ctrl 
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (clickOnScript.currentlySelected == false)
                    {
                        selectedObjects.Add(rayHit.collider.gameObject);
                        clickOnScript.currentlySelected = true;
                        clickOnScript.ClickMe();
                    }
                    else
                    {
                        selectedObjects.Remove(rayHit.collider.gameObject);
                        clickOnScript.currentlySelected = false;
                        clickOnScript.ClickMe();
                    }
                }
                else
                {
                    clearSelectedObjects();

                    selectedObjects.Add(rayHit.collider.gameObject);
                    clickOnScript.currentlySelected = true;
                    clickOnScript.ClickMe();
                }

            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            mousePos2 = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (mousePos1 != mousePos2)
            {
                SelectObjects();
            }
        }
    }
}