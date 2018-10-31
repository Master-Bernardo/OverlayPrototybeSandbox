using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOutput : MonoBehaviour {

    public GameObject laserPrefab;
    public Laser laser;
    public bool active = false;

	// Use this for initialization
	void Start () {
        laser = Instantiate(laserPrefab).GetComponent<Laser>();
        laser.startingBlock = transform.parent.GetComponent<BlockObject>();
        laser.startPoint = transform;  //output point sets direction, should be at 000 transform of parent
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            laser.active = true;
        }
        else
        {
            laser.active = false;
        }
	}

    public void SetLaser(Transform startPoint, BlockObject startingBlock)
    {
        laser.startPoint = startPoint;
        laser.startingBlock = startingBlock;
    }


}
