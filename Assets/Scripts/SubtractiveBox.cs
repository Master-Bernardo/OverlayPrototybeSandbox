using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractiveBox : BlockObject
{
    public Texture2D[] inputImages;
    public LaserOutput laserOutput;

    //the texture this block outputs
    Texture2D outputImage;

    protected override void Start()
    {
        base.Start();
        inputImages = new Texture2D[2];
    }

    override protected void Update()
    {
        base.Update();

        if (inputLasers.Count == 2)
        {
            if(inputImages[0] == inputLasers[0].image && inputImages[1] == inputLasers[1].image) //if we already have the images assigned correctly
            {
                //do nothing
            }
            else
            {
                for (int i = 0; i < inputLasers.Count; i++)
                {
                    inputImages[i] = inputLasers[i].image;
                }
                ComputeOutputImage(inputImages);

            }

            laserOutput.active = true;
        }
        else
        {
            laserOutput.active = false;
        }

    }

    void ComputeOutputImage(Texture2D[] _inputImages)
    {
        outputImage = Instantiate(_inputImages[0]); //we will use sameSizedImages
        Debug.Log("-2:  " + _inputImages[0].GetPixel(142, 142).r );
        Debug.Log("-1:  " +  _inputImages[1].GetPixel(142, 142).r );
        Debug.Log("1:  " + _inputImages[0].GetPixel(142, 142).r * _inputImages[1].GetPixel(142, 142).r * 1f);
        Debug.Log("2:  " + (_inputImages[0].GetPixel(142, 142).r * _inputImages[1].GetPixel(142, 142).r * 1f)/255);
        for (int y = 0; y < outputImage.height; y++)
        {
            for (int x = 0; x < outputImage.width; x++)
            {
                outputImage.SetPixel(x, y,
                    new Color(
                    (_inputImages[0].GetPixel(x,y).r *_inputImages[1].GetPixel(x, y).r * 1f)/1 ,
                    (_inputImages[0].GetPixel(x, y).g * _inputImages[1].GetPixel(x, y).g * 1f) / 1,
                    (_inputImages[0].GetPixel(x, y).b * _inputImages[1].GetPixel(x, y).b *1f) / 1
                    ));
            }
        }
        outputImage.Apply();
        laserOutput.laser.image = outputImage;
}

}
