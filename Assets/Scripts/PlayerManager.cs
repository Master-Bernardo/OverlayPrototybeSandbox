using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /*
     * this class just checks which block we click with the mouse, this is done with a raycast.
     * If we hit a block the mouseOnClickFunction of the blockObject class is called, or the doubleClick function
     */

    public BlockObject selectedObject;

    //for double click
    float lastClickedTime;
    public float doubleTapTime;
    bool clickedOnce = false;
    bool doubleTap = false;

    private void Start()
    {
        lastClickedTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            doubleTap = false;

            if (clickedOnce)
            {
                if (Time.time - lastClickedTime < doubleTapTime)
                {
                    doubleTap = true;
                    HandleMouseClick(true);
                }
            }

            if (doubleTap)
            {
                clickedOnce = false;
            }
            else
            {
                clickedOnce = true;
            }

            lastClickedTime = Time.time;
        }

        if (clickedOnce)
        {
            if(Time.time-lastClickedTime > doubleTapTime)
            {
                doubleTap = false;
                clickedOnce = false;
                HandleMouseClick(false);
            }
        }
	}

    //if we click on an object, we trigger that object click action, if we click on a empthy place while an object is selected we place it
    void HandleMouseClick(bool doubleClick)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Bit shift the index of the layer (9) to get a bit mask
        int layerMask = 1 << 9;
        //if (Physics.Raycast(ray, out hit, 100, layerMask)) //TODO Make a LAYER only for Units and Buildings - selectable objects

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            GameObject hittedObject = hit.collider.gameObject;
            if (hittedObject.GetComponent<GridBlock>()!= null)
            {
                if (selectedObject != null && !doubleTap)
                {
                    selectedObject.SetPosition(hittedObject.GetComponent<GridBlock>().positionForObject);
                    selectedObject.Deselect();
                    selectedObject = null;
                }
            }
            else if(hittedObject.GetComponent<BlockObject>() != null)
            {
                if (!doubleTap && !hittedObject.GetComponent<BlockObject>().actionBlocked)
                {
                    hittedObject.GetComponent<BlockObject>().ActionOnMouseClick();
                }
                else
                {
                    if(!hittedObject.GetComponent<BlockObject>().stationary)
                    {
                        if (selectedObject!=null)selectedObject.Deselect();
                        selectedObject = hittedObject.GetComponent<BlockObject>();
                        selectedObject.Select();
                    }
                }
            }
        } 
    }




}
