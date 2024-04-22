using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    
    public void painter()
    {
        if (Input.GetMouseButton(0))
        {

        Texture2D paintTexture = GetComponent<Canvas>().getTexture();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 9.70f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        float mouseX = 960 * (worldPos.x - 4.7f) / 9.4f;
        float mouseY = 540 * (worldPos.y - 2.66f) / 5.32f;

        for(float i = mouseY - 3; i < mouseY + 3; i++)
        {
            for(float j= mouseX - 3; j < mouseX + 3; j++)
            {
                paintTexture.SetPixel((int)(j), (int)i, Color.black);
            }
        }
        paintTexture.Apply();
        }
    }
}
