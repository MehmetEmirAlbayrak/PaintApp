using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser
{


    public void Erase(Texture2D paintTexture,Vector2Int mousepos)
    {
        if (Input.GetMouseButton(0))
        {

            for (int i = mousepos.y - Painting.radius; i < mousepos.y + Painting.radius; i++)
            {
                for (int j = mousepos.x - Painting.radius; j < mousepos.x + Painting.radius; j++)
                {
                    paintTexture.SetPixel((j), i, Color.white);
                }
            }
            paintTexture.Apply();
        }
    }
}
