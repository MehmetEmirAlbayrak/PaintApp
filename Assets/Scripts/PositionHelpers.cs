using System;
using UnityEngine;

public static class PositionHelpers
{
    public static float minX = -12.0f;
    public static float maxX = 12.0f;
    public static float minY = -6.75f;
    public static float maxY = 6.75f;
    public static int textureWidth = 960;
    public static int textureHeight = 540;
    public static int maxPixelY = 428;

    public static Vector3 PixelToWorld(Vector2Int pos)
    {
        //0 -12 960 12:X
        //960 12
        return new Vector3((maxX - minX) * pos.x / textureWidth + minX,
            (maxY - minY) * pos.y / textureHeight + minY, 0);
    }

    public static Vector2Int WorldToPixel(Vector3 worldPos)
    {
        //-12 0 12 960
        // 12 960

        return new Vector2Int((int)(textureWidth * worldPos.x / (maxX - minX) + textureWidth / 2),
            (int)(textureHeight * worldPos.y / (maxY - minY) + textureHeight / 2));
    }
}

