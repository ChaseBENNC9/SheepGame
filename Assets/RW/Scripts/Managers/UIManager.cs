using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script manages the User interface items such as the Game over screen and the Text for the sheep rescued and dropped.
public class UIManager : MonoBehaviour
{
    public static UIManager Instance; 

    public Text sheepSavedText; 
    public Text sheepDroppedText; 
    public GameObject gameOverWindow; 
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateSheepSaved() //The Methods update the UI text when the values are changed
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() 
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }


    public void ShowGameOverWindow() //Display the gam over window
    {
        gameOverWindow.SetActive(true);
    }
}
