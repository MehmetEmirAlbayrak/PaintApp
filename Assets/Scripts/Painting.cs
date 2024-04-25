using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Painting
{
    public enum BrushShape
    {
        Square,
        Circle
    }

    private int radius = 3;
    private Vector2Int prevPos;
    private BrushShape currentShape;
    public void Painter(Texture2D paintTexture, Vector2Int mousepos, Color selectedColor, bool isDrawable, GameObject particle)
    {

        if (Input.GetMouseButtonDown(0) && isDrawable && mousepos.y < PositionHelpers.maxPixelY)
        {
            if (currentShape == BrushShape.Circle)
                PaintCircle(paintTexture, mousepos.x, mousepos.y, selectedColor);

            else
                PaintArea(paintTexture, mousepos.x, mousepos.y, selectedColor);

            prevPos = mousepos;
        }
        else if (Input.GetMouseButton(0) && isDrawable && mousepos.y < PositionHelpers.maxPixelY)
        {
            float startX = prevPos.x;
            float endX = mousepos.x;
            float startY = prevPos.y;
            float endY = mousepos.y;
            int step = 1 + 2 * (int)Mathf.Max(Mathf.Abs(endX - startX) / radius, Mathf.Abs(endY - startY) / radius);
            for (int i = 1; i <= step; i++)
            {
                float t = (float)i / step;
                int currentX = (int)Mathf.Lerp(startX, endX, t);
                int currentY = (int)Mathf.Lerp(startY, endY, t);

                if (currentShape == BrushShape.Circle)
                    PaintCircle(paintTexture, currentX, currentY, selectedColor);

                else
                    PaintArea(paintTexture, currentX, currentY, selectedColor);

                var temp = GameObject.Instantiate(particle, PositionHelpers.PixelToWorld(new Vector2Int(currentX,currentY)), Quaternion.identity);
                GameObject.Destroy(temp, 0.5f);
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

    public void SetShape(BrushShape shape)
    {
        currentShape = shape;
    }

    public void SetRadius(int size)
    {
        radius = size;
    }

}
