using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreator : MonoBehaviour
{
    [SerializeField] private GameObject paintSound;
    [SerializeField] private GameObject eraseSound;
    [SerializeField] private GameObject bucketSound;
    [SerializeField] private GameObject stampSound;
    private GameObject audioTemp;
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
            
            if (PaintingCanvas.activePaint && PaintingCanvas.setDraw && mouseY.GetMouseCoordinates().y < PositionHelpers.maxPixelY)
            {
                audioTemp = Instantiate(paintSound);
            }
            else if (PaintingCanvas.activeErase && PaintingCanvas.setDraw && mouseY.GetMouseCoordinates().y < PositionHelpers.maxPixelY)
            {
                audioTemp = Instantiate(eraseSound);
            }
            else if (PaintingCanvas.activeBucket && PaintingCanvas.setDraw && mouseY.GetMouseCoordinates().y < PositionHelpers.maxPixelY)
            {
                audioTemp = Instantiate(bucketSound);
            }
            else if (PaintingCanvas.activeStamp && PaintingCanvas.setDraw && mouseY.GetMouseCoordinates().y < PositionHelpers.maxPixelY)
            {
                audioTemp = Instantiate(stampSound);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (PaintingCanvas.activePaint)
            {
                Destroy(audioTemp);
            }
            else if (PaintingCanvas.activeErase)
            {
                Destroy(audioTemp);
            }


        }

       
       
    }
    
}
