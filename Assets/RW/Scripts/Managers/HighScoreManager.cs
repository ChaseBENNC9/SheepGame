using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

//The Purpose of this Script is to Manage a Highscore that will update when the user scores higher. The Score is displayed on a text box in the game scene and tite scene.
//The Highscore is not saved to a file and will reset when the game is closed.
public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public static float highScore = 0;
    public Text highScoreText; 

    void Awake()
    {
        Instance = this;
        UpdateHighScoreText();
    }
   


    //Updates the Text on the UI for the HighScore
    public void UpdateHighScoreText()
    {
       highScoreText.text = ReadHighScore().ToString();

    }
    //Test if the current score is higher than the saved Highscore and if it is, the highscore is updated.
    public void TestHighScore(float TestScore)
    {
        float CurrentHigh = ReadHighScore();
        if (TestScore > CurrentHigh)
        {
            UpdateHighScore(TestScore);
        }
        
    }

    //Updates the saved highscore with the new score. And updates the Text on the UI.
    private void UpdateHighScore(float newScore)
    {

        highScore = newScore;
        UpdateHighScoreText();
    }

    //Reads the highscore from a file and returns as an integer.
    public float ReadHighScore()
    {

        return highScore;
        
    }

}
