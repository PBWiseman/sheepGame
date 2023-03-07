//Updates UI as needed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text sheepSavedText;
    public Text sheepDroppedText;
    public Text highScoreNumber;
    public GameObject gameOverWindow;

    // Awake is called before start
    void Awake()
    {
        Instance = this;
        UpdateHighScore();
    }

    //Updates number of sheep saved on UI
    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    //Updates number of sheep lost on UI
    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    //Shows game over scene
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

    ////Updates high score on UI
    public void UpdateHighScore()
    {
        highScoreNumber.text = GameSettings.highScore.ToString();
    }
}
