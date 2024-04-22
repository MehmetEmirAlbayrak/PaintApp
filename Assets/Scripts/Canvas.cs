using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{

    [SerializeField] private GameObject canvas;
    private Texture2D texture;
  

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer mapRenderer = canvas.GetComponent<SpriteRenderer>();
        texture = mapRenderer.sprite.texture;
        texture = new Texture2D(960, 540);

        for(int i = 0; i < texture.width; i++)
        {
            for(int j = 0; j < texture.height; j++)
            {
                texture.SetPixel(i, j, Color.white);
            }
        }
        texture.Apply();
        mapRenderer.sprite= Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public  Texture2D getTexture()
    {
        return texture;
    }
}
