using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UIArrowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private RawImage image;
    


    void Start()
    {
        image = GetComponent<RawImage>();
        
    }

    public void mouseHoverEnter()
    {
        var tempColor = image.color;
        tempColor.a *= 0.5f;
        image.color = tempColor;
    }

    public void mouseHoverExit()
    {
        var tempColor = image.color;
        tempColor.a /= 0.5f;
        image.color = tempColor;
    }

    public void mouseClick()
    {
        var tempColor = image.color;
        tempColor.a *= 0.5f;
        image.color = tempColor;
    }

    public void mouseRelease()
    {
        var tempColor = image.color;
        tempColor.a /= 0.5f;
        image.color = tempColor;
    }

    public void resetAlpha()
    {
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }

    
}
