using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OutputImage : BlockObject {

    public Texture2D inputImage;
    public Texture2D goalImage;
    public Image goalImageUI;
    public Texture2D noImage; //just a white texture we show when no image is present
    public Image debugImage;
    public GameObject winText; //is seen when we make the puzzle correct

    protected override void Start()
    {
        base.Start();
        goalImageUI.sprite = Sprite.Create(goalImage, new Rect(0, 0, goalImage.width, goalImage.height), new Vector2(0.5f, 0.5f));
        debugImage.sprite = Sprite.Create(noImage, new Rect(0, 0, noImage.width, noImage.height), new Vector2(0.5f, 0.5f));
    }

    // Update is called once per frame
    override protected void Update ()
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
                    debugImage.sprite = Sprite.Create(inputImage, new Rect(0, 0, inputImage.width, inputImage.height), new Vector2(0.5f, 0.5f));
                    if (CheckIfImageIsCorrect(inputImage)) winText.SetActive(true);
                    else winText.SetActive(false);
                }
            }
        }
        else
        {
            if (debugImage.sprite.texture != noImage)
            {
                debugImage.sprite = Sprite.Create(noImage, new Rect(0, 0, noImage.width, noImage.height), new Vector2(0.5f, 0.5f));
            }
            inputImage = null;
            winText.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExportCurrentImage();
        }
    }

    bool CheckIfImageIsCorrect(Texture2D _inputImage)
    {
        bool isCorrect = true;
        for (int y = 0; y < _inputImage.height; y++)
        {
            for (int x = 0; x < _inputImage.width; x++)
            {
                if(_inputImage.GetPixel(x,y)!= goalImage.GetPixel(x, y))
                {
                    isCorrect = false;
                }
            }
        }

        return isCorrect;
    }

    void ExportCurrentImage()
    {
        if (inputImage != null)
        {
            byte[] bytes = inputImage.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/../Assets/Images/Exports/SavedScreen.png", bytes);
        }
        else
        {
            Debug.Log("input image is Null");
        }
    }



}
