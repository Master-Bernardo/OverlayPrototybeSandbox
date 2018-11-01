using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBPrisma : BlockObject
{
    public Texture2D inputImage;

    public LaserOutput laserOutputR;
    public LaserOutput laserOutputG;
    public LaserOutput laserOutputB;

    Texture2D outputImageR;
    Texture2D outputImageG;
    Texture2D outputImageB;


    override protected void Update()
    {
        base.Update();
        if (inputLasers.Count == 1)
        {
            //we can anly accept one laser for this block, so we check if its the same laser as last time
            foreach (Laser laser in inputLasers)
            {
                if (inputImage == laser.image) //if we already have this image
                {
                    //do nothing
                }
                else //if we have a new inputImage or we had null before
                {
                    inputImage = laser.image;

                    outputImageR = new Texture2D(inputImage.width, inputImage.height, TextureFormat.RGBA32, false);
                    outputImageG = new Texture2D(inputImage.width, inputImage.height, TextureFormat.RGBA32, false);
                    outputImageB = new Texture2D(inputImage.width, inputImage.height, TextureFormat.RGBA32, false);

                    for (int y = 0; y < outputImageR.height; y++)
                    {
                        for (int x = 0; x < outputImageR.width; x++)
                        {
                            outputImageR.SetPixel(x, y, new Color(inputImage.GetPixel(x, y).r, 0f, 0f));
                            outputImageG.SetPixel(x, y, new Color(0f, inputImage.GetPixel(x, y).g, 0f));
                            outputImageB.SetPixel(x, y, new Color(0f, 0f, inputImage.GetPixel(x, y).r));
                        }

                    }
                    outputImageR.Apply();
                    outputImageG.Apply();
                    outputImageB.Apply();

                    laserOutputR.laser.image = outputImageR;
                    laserOutputG.laser.image = outputImageG;
                    laserOutputB.laser.image = outputImageB;
                }
            }

            laserOutputR.active = true;
            laserOutputG.active = true;
            laserOutputB.active = true;
        }
        else
        {

            inputImage = null;
            laserOutputR.active = false;
            laserOutputG.active = false;
            laserOutputB.active = false;


        }
    }
}
