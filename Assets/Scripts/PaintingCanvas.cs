using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PaintingCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject particle;
    [SerializeField] private Material particleMaterial;
    [SerializeField] private Button[] brushButtons;
    private Texture2D texture;
    private Painting paint;
    private Bucket bucket;
    private Stamp stamp;
    public static bool activePaint = true;
    public static bool activeBucket = false;
    public static bool activeErase = false;
    public static bool activeStamp = false;
    public static bool setDraw = true;
    public static Color selectedColor = Color.black;
    public static Texture2D selectedStamp;



    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer mapRenderer = canvas.GetComponent<SpriteRenderer>();
        texture = mapRenderer.sprite.texture;
        texture = new Texture2D(PositionHelpers.textureWidth, PositionHelpers.textureHeight);

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                texture.SetPixel(i, j, Color.white);
            }
        }
        texture.Apply();
        mapRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        paint = gameObject.AddComponent<Painting>();
        bucket = new Bucket();
        stamp = new Stamp();

        LoadImage();

    }

    private void Update()
    {
        if (activePaint)
        {
            particleMaterial.color = selectedColor;
            paint.Painter(texture, GetMouseCoordinates(), selectedColor, setDraw, particle);

        }
        else if (activeBucket)
        {
            bucket.Fill(texture, selectedColor, GetMouseCoordinates(), setDraw);
        }
        else if (activeErase)
        {
            particleMaterial.color = Color.white;
            paint.Painter(texture, GetMouseCoordinates(), Color.white, setDraw, particle);


        }
        else if (activeStamp)
        {
            stamp.PaintStamp(texture, GetMouseCoordinates(), selectedStamp, setDraw);

        }
    }

    public Texture2D GetTexture()
    {
        return texture;
    }

    public Vector2Int GetMouseCoordinates()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 9.70f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        return PositionHelpers.WorldToPixel(worldPos);
    }

    public void SaveImage()
    {
        File.WriteAllBytes(Application.persistentDataPath + "/canvas.png", texture.EncodeToPNG());
    }

    public void LoadImage()
    {
        try
        {

            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/canvas.png");
            if (bytes != null)
                texture.LoadImage(bytes);
        }

        catch (FileNotFoundException e)
        {
            print(e.Message);
        }
    }

    public void SetBrushShape(int shape)
    {
        paint.SetShape(shape == 0 ? Painting.BrushShape.Circle : Painting.BrushShape.Square);
        if (shape == 0)
        {
            brushButtons[0].GetComponent<Image>().color = Color.green;
            brushButtons[1].GetComponent<Image>().color = Color.white;
        }
        else
        {
            brushButtons[1].GetComponent<Image>().color = Color.green;
            brushButtons[0].GetComponent<Image>().color = Color.white;
        }
    }

    public void SetBrushRadius(System.Single radius)
    {
        paint.SetRadius((int)radius);
    }


}
