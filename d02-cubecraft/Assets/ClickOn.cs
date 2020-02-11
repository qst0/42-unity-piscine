using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material yellow;
    [SerializeField]
    private Material red;

    Color OriginalColor;
    bool mouseOver = false;

    [HideInInspector]
    public bool currentlySelected = false;

    private MeshRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        //GameObject.Find("Main Controller").GetComponent<Click>().selectableObjects.Add(this.gameObject);
        Camera.main.gameObject.GetComponent<Click>().selectableObjects.Add(this.gameObject);
        ClickMe();
    }

    public void ClickMe()
    {
        if (currentlySelected == false)
        {
            myRend.material = yellow;
        }
        else
        {
            myRend.material = red;
        }
    }

    //hover effect
    private void OnMouseEnter()
    {
        if (!currentlySelected)
        {
            mouseOver = true;
            //myRend.material = MouseOver; // this is if you want to set a MouseOver material

            OriginalColor = GetComponent<Renderer>().material.GetColor("_Color");
            Color MouseOverColor = new Color(OriginalColor.r + 0.5f, OriginalColor.g + 0.5f, OriginalColor.b + 0.5f, 0f);

            gameObject.GetComponent<Renderer>().material.color = MouseOverColor;
        }
    }

    private void OnMouseExit()
    {
        if (!currentlySelected)
        {
            mouseOver = false;
            //myRend.material = Red; // coming back to the unselected Material (wich is Red in the exemple of c00pala)

            gameObject.GetComponent<Renderer>().material.color = OriginalColor;
        }
    }
}