using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputImage : BlockObject {

    /*this image shoots a laser with the image data, there are several types of laser, rgb laser, one channel laser, hsv, ant the other shits*/

    public LaserOutput laserOutput;
    public Texture2D inputImage;
    public Image debugImage;

    override protected void Start()
    {
        base.Start();
        laserOutput.active = true;

        Texture2D newTex = Instantiate(inputImage);

        /*for (int y = 0; y < newTex.height; y++)
        {
            for (int x = 0; x < newTex.width; x++)
            {
                if (x<20||x>150)
                {
                    newTex.SetPixel(x, y, Color.red);
                    
                }
            }
        }
        newTex.Apply();
        */
        laserOutput.laser.image = newTex;
        debugImage.sprite = Sprite.Create(newTex, new Rect(0, 0, newTex.width, newTex.height), new Vector2(0.5f, 0.5f));
    }

    protected override void Update()
    {
        base.Update();
    }

    override public void ActionOnMouseClick()
    {
        transform.Rotate(Vector3.up, 45);
    }

}
