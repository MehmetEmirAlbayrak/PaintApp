using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp
{

    public void PaintStamp(Texture2D texture,Vector2Int mousepos,Texture2D stampTexture)
    {
        if (Input.GetMouseButtonDown(0))
        {

            int width = stampTexture.width;
            int height = stampTexture.height;
            for (int i =0 ; i < width; i++)
            {
                for (int j = 0; j <height; j++)
                {
                    if (stampTexture.GetPixel(i, j).a != 0)
                        texture.SetPixel(mousepos.x+(i-width/2),mousepos.y+(j-height/2), stampTexture.GetPixel(i,j));
                }
            }
            texture.Apply();
        }
    }
}
