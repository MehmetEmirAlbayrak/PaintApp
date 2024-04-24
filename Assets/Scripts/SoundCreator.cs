using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreator : MonoBehaviour
{
    [SerializeField] private GameObject paintSound;
    [SerializeField] private GameObject eraseSound;
    [SerializeField] private GameObject bucketSound;
    [SerializeField] private GameObject stampSound;
    private GameObject paintTemp;
    private GameObject eraseTemp;
    private GameObject bucketTemp;
    private GameObject stampTemp;
    private PaintingCanvas mouseY;
    // Start is called before the first frame update
    void Start()
    {
        mouseY = GetComponent<PaintingCanvas>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            if (PaintingCanvas.activePaint && PaintingCanvas.setDraw && mouseY.GetMouseAxis().y < 428)
            {
                paintTemp = Instantiate(paintSound);
            }
            else if (PaintingCanvas.activeErase && PaintingCanvas.setDraw && mouseY.GetMouseAxis().y < 428)
            {
                eraseTemp = Instantiate(eraseSound);
            }
            else if (PaintingCanvas.activeBucket && PaintingCanvas.setDraw && mouseY.GetMouseAxis().y < 428)
            {
                bucketTemp = Instantiate(bucketSound);
            }
            else if (PaintingCanvas.activeStamp && PaintingCanvas.setDraw && mouseY.GetMouseAxis().y < 428)
            {
                stampTemp = Instantiate(stampSound);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (PaintingCanvas.activePaint)
            {
                Destroy(paintTemp);
            }
            else if (PaintingCanvas.activeErase)
            {
                Destroy(eraseTemp);
            }
            else if (PaintingCanvas.activeBucket)
            {
                Invoke("DestroyBucket",3.0f);
            }
            else if (PaintingCanvas.activeStamp)
            {
                Invoke("DestroyStamp", 2.0f);
            }


        }

       
       
    }
    private void DestroyBucket()
    {
        Destroy(bucketTemp);
    }
    private void DestroyStamp()
    {
        Destroy(stampTemp);
    }
}
