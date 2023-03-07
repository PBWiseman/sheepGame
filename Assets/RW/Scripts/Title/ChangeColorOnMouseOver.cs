//Changes colour of menu buttons on mouseover
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model;
    public Color normalColor;
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    //Changes model colour when mouse enters area
    public void OnPointerEnter(PointerEventData eventData) 
    {
        model.material.color = hoverColor;
    }

    //Changes model colour when mouse leaves area
    public void OnPointerExit(PointerEventData eventData) 
    {
        model.material.color = normalColor;
    }
}
