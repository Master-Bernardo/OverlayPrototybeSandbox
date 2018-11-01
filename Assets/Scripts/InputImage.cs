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

        Texture2D outputImage = new Texture2D(inputImage.width, inputImage.height, TextureFormat.RGBA32,false);
        for (int y = 0; y < outputImage.height; y++)
        {
            for (int x = 0; x < outputImage.width; x++)
            {
                outputImage.SetPixel(x, y, inputImage.GetPixel(x, y));
            }
            
        }
        outputImage.Apply();

        laserOutput.laser.image = outputImage;
        debugImage.sprite = Sprite.Create(outputImage, new Rect(0, 0, outputImage.width, outputImage.height), new Vector2(0.5f, 0.5f));
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
