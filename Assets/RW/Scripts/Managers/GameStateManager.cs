using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//The Purpose of this script is to keep track of the states of different objects within the game. It manages how many sheep are saved or dropped and when a game over is caused. 
public class GameStateManager : MonoBehaviour
{

    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved; 

    [HideInInspector]
    public int sheepDropped; 

    public int sheepDroppedBeforeGameOver; 
    public SheepSpawner sheepSpawner; 
    
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
    public void SavedSheep() //When a sheep is saved, the Score is updated and it is tested against the stored highscore from the highscoreManager script.
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
        HighScoreManager.Instance.TestHighScore(sheepSaved);
        
    }

    private void GameOver() //When the game is over, a window opens and any sheep left on the screen are destroyed.
    {
        
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep(); 
        UIManager.Instance.ShowGameOverWindow();

        
    }

    public void DroppedSheep() //When a Sheep is dropped the sheep Dropped is updated and It is tested to see if it is a gameover
    {
        sheepDropped++; 
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }


}
