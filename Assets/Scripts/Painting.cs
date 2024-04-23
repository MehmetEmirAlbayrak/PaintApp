using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting
{
    public static int radius=3;
    public void Painter(Texture2D paintTexture,Vector2Int mousepos,Color selectedColor)
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = mousepos.y - radius; i < mousepos.y + radius; i++)
            {
                for(int j= mousepos.x - radius; j < mousepos.x + radius; j++)
                {
                    paintTexture.SetPixel(j, i, selectedColor);
                }
            }
            paintTexture.Apply();
            }
    }
}
