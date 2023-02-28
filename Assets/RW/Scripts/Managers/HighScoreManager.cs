using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class HighScoreManager : MonoBehaviour
{
       public Text highScoreText; 
    public static HighScoreManager Instance;

    void Start()
    {
        Instance = this;
        this.UpdateHighScoreText();
    }

    public void UpdateHighScoreText()
    {
       highScoreText.text = ReadHighScore().ToString();

    }
    //Test if the current score is higher than the saved Highscore, .
    public static void TestHighScore(int TestScore)
    {
        int CurrentHigh = ReadHighScore();
        if (TestScore > CurrentHigh)
        {
            UpdateHighScore(TestScore);
        }
        
    }

    //Updates the saved highscore with the new score to a file.
    private static void UpdateHighScore(int newScore)
    {
        StreamWriter sw = new StreamWriter(@"highscore.txt");
        sw.Write(newScore.ToString());
        sw.Close();
    }

    //Reads the highscore from a file and returns as an integer.
    public static int ReadHighScore()
    {
        StreamReader sr = new StreamReader(@"highscore.txt");
        string highScore = sr.ReadLine();
        if (sr.ReadLine() == "")
        {
            sr.Close();
            return 0;
        }
        else
        {
           
            sr.Close();
            return Convert.ToInt32(highScore);
            
        }
        
    }

}
