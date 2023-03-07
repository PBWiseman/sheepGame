//Runs game state tasks.
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

    // Awake is called before start
    void Awake()
    {
        Instance = this;
        GameSettings.startTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    //Destroys all sheep and ends game
    public void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();
    }

    //Counts saved sheep
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }
    
    //Counts dropped sheep
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

    //Updates high score at end of game
    public void HighScoreSetting()
    {
        if (sheepSaved > GameSettings.highScore){
            GameSettings.highScore = sheepSaved;
        }
    }
}
