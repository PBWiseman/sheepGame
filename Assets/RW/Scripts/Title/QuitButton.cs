//Exits system when quit button pressed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    //Exits system when button clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
