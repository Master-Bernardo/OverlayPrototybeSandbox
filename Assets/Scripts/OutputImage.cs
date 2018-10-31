using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputImage : BlockObject {

    public Texture2D inputImage;
    public Texture2D goalImage;
    public Image debugImage;

    // Update is called once per frame
    override protected void Update ()
    {
        base.Update();
        if (inputLasers.Count == 1)
        {
            foreach(Laser laser in inputLasers)
            {
                inputImage = laser.image;
            }

            debugImage.sprite = Sprite.Create(inputImage, new Rect(0, 0, inputImage.width, inputImage.height), new Vector2(0.5f, 0.5f));
        }

	}
}
