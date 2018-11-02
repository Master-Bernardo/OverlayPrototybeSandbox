using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOutput : MonoBehaviour {

    /*
     * Jedes BlockObject, welches Laser ruasschießt hat einen oder mehrere LaserOutputs
     * Abhängig davon wie die Rotation eines Laser ooutputs ist, so werden auch die Laser rausgeschoissen
     */

    public GameObject laserPrefab;
    public Laser laser;
    public bool active = false;

	void Start () {
        laser = Instantiate(laserPrefab).GetComponent<Laser>();
        laser.startingBlock = transform.parent.GetComponent<BlockObject>();
        laser.startPoint = transform;  //output point sets direction, should be at 000 transform of parent
	}
	
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
