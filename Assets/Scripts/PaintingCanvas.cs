using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PaintingCanvas : MonoBehaviour
{

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject particle;
    [SerializeField]private Material particleMaterial;
    private Texture2D texture;
    private Painting paint;
    private Bucket bucket;
    private Stamp stamp;
    public static bool activePaint=true;
    public static bool activeBucket=false;
    public static bool activeErase=false;
    public static bool activeStamp=false;
    public static bool setDraw = true;
    public static Color selectedColor=Color.black;
    public static Texture2D selectedStamp;
    


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
        paint = new Painting();
        bucket = new Bucket();
        stamp = new Stamp();

        LoadImage();
       



    }
    private void Update()
    {
        if (activePaint)
        {
            particleMaterial.color = selectedColor;
            paint.Painter(texture, GetMouseAxis(),selectedColor,setDraw,particle);
         
        }
        else if (activeBucket)
        {
            bucket.Fill(texture,selectedColor,GetMouseAxis(),setDraw);
            

        }
        else if (activeErase)
        {
            particleMaterial.color = Color.white;
            paint.Painter(texture,GetMouseAxis(),Color.white,setDraw,particle);
            

        }
        else if (activeStamp)
        {
            stamp.PaintStamp(texture,GetMouseAxis(),selectedStamp,setDraw);
            
        }
    }

    public  Texture2D GetTexture()
    {
        return texture;
    }

    public Vector2Int GetMouseAxis()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 9.70f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        float mouseX = texture.width * (worldPos.x + (12.0f)) / (24.0f);
        float mouseY = texture.height * (worldPos.y + (6.75f)) / (13.5f);
        return new Vector2Int((int)mouseX,(int) mouseY);



    }
    public void SaveImage()
    {

        File.WriteAllBytes(Application.dataPath+"/canvas.png", texture.EncodeToPNG());
       

    }

    private void LoadImage()
    {
        
        byte[] bytes = File.ReadAllBytes(Application.dataPath+"/canvas.png");
        if (bytes != null)
            texture.LoadImage(bytes);
    }

    

}
