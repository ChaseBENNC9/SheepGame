using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public static float highScoreN = 0;
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
    //Test if the current score is higher than the saved Highscore, .
    public void TestHighScore(float TestScore)
    {
        float CurrentHigh = ReadHighScore();
        if (TestScore > CurrentHigh)
        {
            UpdateHighScore(TestScore);
        }
        
    }

    //Updates the saved highscore with the new score to a file.
    private void UpdateHighScore(float newScore)
    {
        // StreamWriter sw = new StreamWriter(@"highscore.txt");
        // sw.Write(newScore.ToString());
        // sw.Close();
        highScoreN = newScore;
    }

    //Reads the highscore from a file and returns as an integer.
    public float ReadHighScore()
    {
        // StreamReader sr = new StreamReader(@"highscore.txt");
        // string highScore = sr.ReadLine();
        // if (sr.ReadLine() == "")
        // {
        //     sr.Close();
        //     return 0;
        // }
        // else
        // {
           
        //     sr.Close();
        //     return Convert.ToInt32(highScore);
            
        // }
        return highScoreN;
        
    }

}
