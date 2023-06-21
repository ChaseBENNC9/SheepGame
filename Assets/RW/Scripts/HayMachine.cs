using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The script manages the Hay machine and acts like a player controller
public class HayMachine : MonoBehaviour
{
    public float movementSpeed; //The Movement speed of the hay machine
    public float horizontalBoundary = 22; //The Boundary that the hay machine can move within
    public GameObject hayBalePrefab; //The Hay Bale Prefab that the hay machine fires
    public Transform haySpawnpoint; //The Point where the hay bale is spawned
    public float shootInterval; //The Cooldown ammount before shooting
    private float shootTimer; 


    public Transform modelParent; //The Position of the hay machine

    public GameObject blueModelPrefab; //The Models for the different hay machines
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        LoadModel(); //Loads in the selected machine when the game starts
    }
    private void LoadModel() //Accesses which colour was selected in the menu and loads the correct model.
    {
        Destroy(modelParent.GetChild(0).gameObject); //Destroys the current model
        switch (GameSettings.hayMachineColor) //Spawns the selected colour at the model parent position
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
    private void UpdateMovement() //Tests if the player is within the movement Tracks and moves in the direction of the key press.
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); //When the Horizontal input is pressed

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) //Moves the player when it is within the set boundary
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) //Moves the player the other way up to the max boundary
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }


    private void UpdateShooting() //Manages the shooting and the cooldown before the player can shoot again
    {
        shootTimer -= Time.deltaTime; 
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval; //sets the timer back to the interval for a cooldown
            ShootHay(); //Fires the hay bale
        }
    }

    private void ShootHay() //Creates a new hay bale and plays the appropriate sound.
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip(); 
    }
}
