using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : BlockObject
{

    public LaserOutput outputLaserFront;
    public LaserOutput outputLaserBack;

    Laser inputLaserBack;
    Laser inputLaserFront;


    override public void ActionOnMouseClick()
    {
        transform.Rotate(Vector3.up, 45);
    }

    protected override void Update()
    {
        base.Update();

        //reset the mevery time
        inputLaserBack = null;
        inputLaserFront = null;

        foreach (Laser laser in inputLasers)
        {

            //check for input lasers
           
            int angleDifference = (int)Vector3.Angle(laser.startPoint.forward, transform.forward);

            //zwischen 0 und 45 - back, zwischen 135 und 180 front
            if (angleDifference >= 0 && angleDifference <= 50)
            {
                inputLaserBack = laser;
                outputLaserBack.gameObject.transform.forward = Vector3.Reflect(inputLaserBack.startPoint.forward, transform.forward);

            }
            else if (angleDifference >= 130 && angleDifference <= 180)
            {
                inputLaserFront = laser;
                outputLaserFront.gameObject.transform.forward = Vector3.Reflect(inputLaserFront.startPoint.forward, transform.forward);
            }

        }

        //decide what to do with the lasers
        if (inputLaserFront != null)
        {
            outputLaserFront.active = true;
            //here we would copy the values of the input laser to the output laser - the mirror does not change them
            outputLaserFront.laser.image = inputLaserFront.image;
        }
        else
        {
            outputLaserFront.active = false;
        }
        if (inputLaserBack != null)
        {
            outputLaserBack.active = true;
            //here we would copy the values of the input laser to the output laser
            outputLaserBack.laser.image = inputLaserBack.image;

        }
        else
        {
            outputLaserBack.active = false;
        }
    }
}
        