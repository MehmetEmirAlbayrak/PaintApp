using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting
{
    public static int radius = 5;
    private Vector2Int prevPos;
    public void Painter(Texture2D paintTexture, Vector2Int mousepos, Color selectedColor,bool isDrawable)
    {
        if (Input.GetMouseButtonDown(0) && isDrawable)
        {
            PaintCircle(paintTexture, mousepos.x, mousepos.y, selectedColor);
            prevPos = mousepos;

        }
        else if (Input.GetMouseButton(0) && isDrawable)
        {
            float startX = prevPos.x;
            float endX = mousepos.x;
            float startY = prevPos.y;
            float endY = mousepos.y;
            int step = 1 + 2 * (int)Mathf.Max(Mathf.Abs(endX - startX) / radius, Mathf.Abs(endY - startY) / radius);
            Debug.Log(step);
            for (int i = 1; i <= step; i++)
            {
                float t = (float)i / step;
                int currentX = (int)Mathf.Lerp(startX, endX, t);
                int currentY = (int)Mathf.Lerp(startY, endY, t);
                PaintCircle(paintTexture, currentX, currentY, selectedColor, false);
            }
            paintTexture.Apply();
            prevPos = mousepos;
        }
    }

    private void PaintArea(Texture2D paintTexture, int x, int y, Color selectedColor, bool apply = true)
    {
        for (int i = y - radius + 1; i < y + radius; i++)
        {

            for (int j = x - radius + 1; j < x + radius; j++)
            {
                paintTexture.SetPixel(j, i, selectedColor);
            }
        }
        if (apply)
            paintTexture.Apply();
    }

    private void PaintCircle(Texture2D paintTexture, int x, int y, Color selectedColor, bool apply = true)
    {

        for (int i = y - radius + 1; i < y + radius; i++)
        {

            for (int j = x - radius + 1; j < x + radius; j++)
            {
                float distanceSquare = (x - j) * (x - j) + (y - i) * (y - i);
                if (distanceSquare <= radius * radius)
                    paintTexture.SetPixel(j, i, selectedColor);
            }
        }


        if (apply)
            paintTexture.Apply();
    }
}
