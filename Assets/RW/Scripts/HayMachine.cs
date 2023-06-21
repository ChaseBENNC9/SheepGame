using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The script manages the Hay machine and acts like a player controller
public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;


    public Transform modelParent; 

    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }
    private void LoadModel() //Accesses which colour was selected in the menu and loads the correct model.
    {
        Destroy(modelParent.GetChild(0).gameObject);
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab,modelParent);
            break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab,modelParent);
            break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab,modelParent);
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
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
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
            ShootHay();
        }
    }

    private void ShootHay() //Creates a new hay bale and plays the appropriate sound.
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }
}
