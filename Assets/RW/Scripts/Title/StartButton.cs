//Starts game when start button pressed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    //Changed scene to start when buttons clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Game");
    }
}
