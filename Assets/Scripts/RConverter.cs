using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RConverter : BlockObject
{
    public Texture2D inputImage;
    public LaserOutput laserOutput;

    // Update is called once per frame


    override protected void Update()
    {
        base.Update();

        if (inputLasers.Count == 1)
        {
            foreach (Laser laser in inputLasers)
            {
                inputImage = laser.image;
            }

            Texture2D newTex = Instantiate(inputImage);

            for (int y = 0; y < newTex.height; y++)
            {
                for (int x = 0; x < newTex.width; x++)
                {
                    //if (x < 20 || x > 150)
                    //{
                        newTex.SetPixel(x, y, new Color(inputImage.GetPixel(x, y).r, 0f,0f));

                    //}
                }
            }
            newTex.Apply();

            laserOutput.laser.image = newTex;
            laserOutput.active = true;

        }
        else
        {
            laserOutput.active = false;
        }

    }

}
