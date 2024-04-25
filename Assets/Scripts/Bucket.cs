using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket
{
    public void Fill(Texture2D fillTexture, Color selectedColor,Vector2Int mousepos,bool isDrawable)
    {
        if (Input.GetMouseButtonDown(0) && mousepos.y< PositionHelpers.maxPixelY && isDrawable )
        {

            for (int i = 0; i < fillTexture.height; i++)
            {
                for (int j = 0; j < fillTexture.width; j++)
                {
                    fillTexture.SetPixel(j, i, selectedColor);
                }
            }
            fillTexture.Apply();

        }
    }
}
