using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RConverter : BlockObject
{
    //this block outputs only the rbg channel - its a red Filter

    public Texture2D inputImage;
    public LaserOutput laserOutput;

    //the texture this block outputs
    Texture2D outputImage;

    protected override void Start()
    {
        base.Start();
    }

    override protected void Update()
    {
        base.Update();

        if (inputLasers.Count == 1)
        {
            //we can anly accept one laser for this block, so we check if its the same laser as last time
            foreach (Laser laser in inputLasers)
            {
                if(inputImage == laser.image) //if we already have this image
                {
                    //do nothing
                }
                else //if we have a new inputImage or we had null before
                {
                    inputImage = laser.image;
                    ComputeOutputImage(inputImage);
                }
                
            }

           

            laserOutput.laser.image = outputImage;
            laserOutput.active = true;

        }
        else
        {
            laserOutput.active = false;
        }

    }

    void ComputeOutputImage(Texture2D _inputImage)
    {
        //Debug.Log(_inputImage.format);
       /* outputImage = Instantiate(_inputImage);

        for (int y = 0; y < outputImage.height; y++)
        {
            for (int x = 0; x < outputImage.width; x++)
            {
                //if (x < 20 || x > 150)
                //{
                outputImage.SetPixel(x, y, new Color(_inputImage.GetPixel(x, y).r, 0f, 0f), );

                //}
            }
        }
        outputImage.Apply();*/
    }

}
