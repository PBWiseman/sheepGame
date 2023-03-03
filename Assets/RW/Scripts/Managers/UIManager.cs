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
    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }
    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
    public void UpdateHighScore()
    {
        highScoreNumber.text = GameSettings.highScore.ToString();
    }
}
