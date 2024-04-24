using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private Slider rSlider;
    [SerializeField] private Slider gSlider;
    [SerializeField] private Slider bSlider;
    [SerializeField] private Image showColor;
    [SerializeField] private GameObject Stamps;

    public void OpenPaint()
    {
        PaintingCanvas.activePaint = true;
        PaintingCanvas.activeBucket = false;
        PaintingCanvas.activeErase = false;
        PaintingCanvas.activeStamp = false;
        rSlider.gameObject.SetActive(false);
        gSlider.gameObject.SetActive(false);
        bSlider.gameObject.SetActive(false);
        Stamps.SetActive(false);
        PaintingCanvas.setDraw = true;

    }
    public void OpenBucket()
    {
        PaintingCanvas.activePaint = false;
        PaintingCanvas.activeBucket = true;
        PaintingCanvas.activeErase = false;
        PaintingCanvas.activeStamp = false;
        rSlider.gameObject.SetActive(false);
        gSlider.gameObject.SetActive(false);
        bSlider.gameObject.SetActive(false);
        Stamps.SetActive(false);
        PaintingCanvas.setDraw = true;

    }
    public void OpenErase()
    {
        PaintingCanvas.activePaint = false;
        PaintingCanvas.activeBucket = false;
        PaintingCanvas.activeErase = true;
        PaintingCanvas.activeStamp = false;
        Stamps.SetActive(false);
        PaintingCanvas.setDraw = true;

    }
    public void OpenStamp()
    {
        PaintingCanvas.activePaint = false;
        PaintingCanvas.activeBucket = false;
        PaintingCanvas.activeErase = false;
        PaintingCanvas.activeStamp = true;
        Stamps.SetActive(true);
        rSlider.gameObject.SetActive(false);
        gSlider.gameObject.SetActive(false);
        bSlider.gameObject.SetActive(false);
        PaintingCanvas.setDraw = false;
    }

    public void SelectColor()
    {
        rSlider.gameObject.SetActive(true);
        gSlider.gameObject.SetActive(true);
        bSlider.gameObject.SetActive(true);
        Stamps.SetActive(false);
        PaintingCanvas.setDraw = false;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            PaintingCanvas.selectedColor = new Color(rSlider.value, gSlider.value, bSlider.value);
            showColor.color = PaintingCanvas.selectedColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
