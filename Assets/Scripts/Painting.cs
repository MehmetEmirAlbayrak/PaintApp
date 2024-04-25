using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Painting : MonoBehaviour
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
                PaintCircle(paintTexture, mousepos.x, mousepos.y, selectedColor,true);

            else
                PaintArea(paintTexture, mousepos.x, mousepos.y, selectedColor,true);

            prevPos = mousepos;
        }
        else if (Input.GetMouseButton(0) && isDrawable && mousepos.y < PositionHelpers.maxPixelY)
        {
            float startX = prevPos.x;
            float endX = mousepos.x;
            float startY = prevPos.y;
            float endY = mousepos.y;
            float temprad = radius *0.5f;
            int step = (int)(Mathf.Max(Mathf.Abs(endX - startX) / temprad, Mathf.Abs(endY - startY) / temprad));
            if (step >= 1)
            {
                prevPos = mousepos;
            }
            else
                return;
            HashSet<Vector2Int> points = new HashSet<Vector2Int>();
            for (int i = 1; i <= step; i++)
            {
                float t = (float)i / step;
                int currentX = (int)Mathf.Lerp(startX, endX, t);
                int currentY = (int)Mathf.Lerp(startY, endY, t);

                if (currentShape == BrushShape.Circle)
                    StartCoroutine(GetCirclePoints(paintTexture, currentX, currentY,points));

                else
                    StartCoroutine(GetSquarePoints(paintTexture, currentX, currentY, points));
                if (Random.value < 0.15f)
                {
                    var temp = GameObject.Instantiate(particle, PositionHelpers.PixelToWorld(new Vector2Int(currentX, currentY)), Quaternion.identity);
                    GameObject.Destroy(temp, 0.5f);
                }
            }
            foreach (var pixels in points)
            {
                paintTexture.SetPixel(pixels.x, pixels.y, selectedColor);
            }
            paintTexture.Apply();
        }
    }

    private IEnumerator GetSquarePoints(Texture2D paintTexture, int x, int y, HashSet<Vector2Int> points)
    {
        for (int i = y - radius + 1; i < y + radius; i++)
        {
            for (int j = x - radius + 1; j < x + radius; j++)
            {
                lock (points)
                {
                    points.Add(new Vector2Int(j, i));
                }

            }
        }

        yield return null;
    }

    private IEnumerator GetCirclePoints(Texture2D paintTexture, int x, int y, HashSet<Vector2Int> points)
    {

        for (int i = y - radius + 1; i < y + radius; i++)
        {
            for (int j = x - radius + 1; j < x + radius; j++)
            {
                float distanceSquare = (x - j) * (x - j) + (y - i) * (y - i);

                if (distanceSquare <= radius * radius)
                {
                    lock (points)
                    {
                        points.Add(new Vector2Int(j, i));
                    }
                }

            }
        }

        yield return null;
    }

    public void SetShape(BrushShape shape)
    {
        currentShape = shape;
    }

    public void SetRadius(int size)
    {
        radius = size;
    }

    private void PaintArea(Texture2D paintTexture, int x, int y, Color selectedColor, bool apply)
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

    private void PaintCircle(Texture2D paintTexture, int x, int y, Color selectedColor, bool apply)
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

    private IEnumerator PaintAreaAsync(Texture2D paintTexture, int x, int y, Color selectedColor, bool apply)
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

        yield return null;
    }

    private IEnumerator PaintCircleAsync(Texture2D paintTexture, int x, int y, Color selectedColor, bool apply)
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

        yield return null;
    }

}
