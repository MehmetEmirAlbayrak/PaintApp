using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket
{
    public void Fill(Texture2D fillTexture)
    {
        if (Input.GetMouseButtonDown(0))
        {

            for(int i = 0; i < fillTexture.height; i++)
            {
                for(int j = 0; j < fillTexture.width; j++)
                {
                    fillTexture.SetPixel((int)j, (int)i, Color.black);
                }
            }
            fillTexture.Apply();

        }
    }
}
