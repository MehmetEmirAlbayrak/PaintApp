using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStamps : MonoBehaviour
{

    public void SelectStamp(Button select)
    {
        PaintingCanvas.selectedStamp = select.image.sprite.texture;
        
    }
}
