using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class HighScoreManager : MonoBehaviour
{
    public static float highScoreN = 0;
    public Text highScoreText; 

    void Start()
    {
        UpdateHighScoreText();
    }
   


    public void UpdateHighScoreText()
    {
       highScoreText.text = ReadHighScore().ToString();

    }
    //Test if the current score is higher than the saved Highscore, .
    public static void TestHighScore(float TestScore)
    {
        float CurrentHigh = ReadHighScore();
        if (TestScore > CurrentHigh)
        {
            UpdateHighScore(TestScore);
        }
        
    }

    //Updates the saved highscore with the new score to a file.
    private static void UpdateHighScore(float newScore)
    {
        // StreamWriter sw = new StreamWriter(@"highscore.txt");
        // sw.Write(newScore.ToString());
        // sw.Close();
        highScoreN = newScore;
    }

    //Reads the highscore from a file and returns as an integer.
    public static float ReadHighScore()
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
