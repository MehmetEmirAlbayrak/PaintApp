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
    [SerializeField] private GameObject brushObject;
    [SerializeField] private Button[] buttons;
    private bool painting=false;

    public void OpenPaint()
    {
        PaintingCanvas.activePaint = true;
        PaintingCanvas.activeBucket = false;
        PaintingCanvas.activeErase = false;
        PaintingCanvas.activeStamp = false;
        brushObject.SetActive(true);
        rSlider.gameObject.SetActive(false);
        gSlider.gameObject.SetActive(false);
        bSlider.gameObject.SetActive(false);
        Stamps.SetActive(false);
        PaintingCanvas.setDraw = true;
        buttons[0].GetComponent<Image>().color = Color.green;
        buttons[1].GetComponent<Image>().color = Color.white;
        buttons[2].GetComponent<Image>().color = Color.white;
        buttons[3].GetComponent<Image>().color = Color.white;




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
        brushObject.SetActive(false);
        PaintingCanvas.setDraw = true;
        
        buttons[0].GetComponent<Image>().color = Color.white;
        buttons[1].GetComponent<Image>().color = Color.green;
        buttons[2].GetComponent<Image>().color = Color.white;
        buttons[3].GetComponent<Image>().color = Color.white;

    }
    public void OpenErase()
    {
        PaintingCanvas.activePaint = false;
        PaintingCanvas.activeBucket = false;
        PaintingCanvas.activeErase = true;
        PaintingCanvas.activeStamp = false;
        brushObject.SetActive(true);
        Stamps.SetActive(false);
        PaintingCanvas.setDraw = true;
        buttons[0].GetComponent<Image>().color = Color.white;
        buttons[1].GetComponent<Image>().color = Color.white;
        buttons[2].GetComponent<Image>().color = Color.green;
        buttons[3].GetComponent<Image>().color = Color.white;

    }
    public void OpenStamp()
    {
        PaintingCanvas.activePaint = false;
        PaintingCanvas.activeBucket = false;
        PaintingCanvas.activeErase = false;
        PaintingCanvas.activeStamp = true;
        Stamps.SetActive(true);
        brushObject.SetActive(false);
        rSlider.gameObject.SetActive(false);
        gSlider.gameObject.SetActive(false);
        bSlider.gameObject.SetActive(false);
        PaintingCanvas.setDraw = false;
        buttons[0].GetComponent<Image>().color = Color.white;
        buttons[1].GetComponent<Image>().color = Color.white;
        buttons[2].GetComponent<Image>().color = Color.white;
        buttons[3].GetComponent<Image>().color = Color.green;
    }

    public void SelectColor()
    {
        painting = !painting;
        rSlider.gameObject.SetActive(painting);
        gSlider.gameObject.SetActive(painting);
        bSlider.gameObject.SetActive(painting);
        brushObject.SetActive(false);
        Stamps.SetActive(false);
        PaintingCanvas.setDraw =!PaintingCanvas.setDraw;
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
