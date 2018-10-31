using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObject : MonoBehaviour {

    public Transform assignedGridPoint; //this is the current position of this block
    public bool stationary = false; //if this is true - then we cant move the object from its position - good for some puzzle objects like walls etc
    public bool actionBlocked = false; // if this is true we cant perform the onClickAction;
    bool selected;
    public GameObject selectionMarker;

    //For Lasers
    protected HashSet<Laser> inputLasers;
    //protected List<Laser> outputLasers;


    //for laser
    //public GameObject laserPrefab;
    //public Transform laserOutputPoint;

    // Use this for initialization
    virtual protected void Start ()
    {
        transform.position = assignedGridPoint.transform.position + new Vector3(0f,0.5f,0f);
        selectionMarker.SetActive(false);

        //inputLasers = new List<Laser>();
        //outputLasers = new List<Laser>();
    }

    virtual protected void Update()
    {
        inputLasers = LaserManager.Instance.GetInputLasers(this);
    }


    //specific actions for the object types - a mirror for example rotates, a picture gets zoomed
    virtual public void ActionOnMouseClick()  
    {
        Debug.Log("singleClickAction");
    }

    public void SetPosition(Transform newPosition)
    {
        transform.position = newPosition.position + new Vector3(0f, 0.5f, 0f);
    }

    public void Select()
    {
        selectionMarker.SetActive(true);
    }

    public void Deselect()
    {
        selectionMarker.SetActive(false);
    }


    /*
    //gets called when a laser hits this
    virtual public void AddInputLaser(Laser laser)
    {
        inputLasers.Add(laser);
        Debug.Log("added");
    }

    virtual public void RemoveInputLaser(Laser laser)
    {
        inputLasers.Remove(laser);
        Debug.Log("removed");
    }
    */

}
