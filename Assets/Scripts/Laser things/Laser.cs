using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaserType
{
    //for now unused
    RGB,
    R,
    G,
    B,
    Grey
}


public class Laser : MonoBehaviour {

    //for display
    public Transform startPoint;
    private Vector3 endPoint;
    public LineRenderer lineRenderer;
    public bool active = true; //do we see the laser?

    // for gameLogic
    public BlockObject startingBlock;
    public BlockObject destinationBlock;

    //for imageprocessing
    public Texture2D image;

    private void Start()
    {
        LaserManager.Instance.AddLaser(this);
    }

    //this function shoots a raycast to see which block we hit and draws the laser accordingly
    public void UpdateLaser()//, BlockObject startingBlock)
    {
        if (active)
        {
            lineRenderer.enabled = true;
            RaycastHit hit;
            // Bit shift the index of the layer (0) to get a bit mask
            int layerMask = 1 << 9;

            //calculate the endPoint
            if (Physics.Raycast(startPoint.position, startPoint.forward, out hit, 100, layerMask))
            {
                GameObject hittedObject = hit.collider.gameObject;
                endPoint = hittedObject.transform.position;

            
                if (hittedObject.GetComponent<BlockObject>() != null)
                {
                    if (destinationBlock != hittedObject.GetComponent<BlockObject>())
                    {
                        destinationBlock = hittedObject.GetComponent<BlockObject>();
                    }
                }
                else
                {
                    destinationBlock = null;
                    endPoint = hit.point;
                }

                lineRenderer.SetPosition(0, startPoint.position);
                lineRenderer.SetPosition(1, endPoint);
            }
            else
            {
                destinationBlock = null;
                lineRenderer.SetPosition(0, startPoint.position);
                lineRenderer.SetPosition(1, startPoint.position + startPoint.forward*100);
            }
        }
        else
        {
            lineRenderer.enabled = false;
            destinationBlock = null;
        }

    }

}
