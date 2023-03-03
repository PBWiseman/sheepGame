using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    [HideInInspector]
    public int sheepSaved;
    [HideInInspector]
    public int sheepDropped;
    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
    public void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();
    }
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }
    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();
        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            HighScoreSetting();
            GameOver();
        }
    }
    public void HighScoreSetting()
    {
        if (sheepSaved > GameSettings.highScore){
            GameSettings.highScore = sheepSaved;
        }
    }
}
