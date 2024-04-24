using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStamps : MonoBehaviour
{
    [SerializeField] private GameObject Stamps;
    public void SelectStamp(Texture2D select)
    {
        PaintingCanvas.selectedStamp = select;
        PaintingCanvas.setDraw = true;
        Stamps.SetActive(false);
        
    }
}
