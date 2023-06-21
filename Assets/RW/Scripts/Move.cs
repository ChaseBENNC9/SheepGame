using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script moves the hay bale .
public class Move : MonoBehaviour
{
    public Vector3 movementSpeed; //Movement speed for each axis
    public Space space;
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space); //Moves  at the set speed , multiply by time.deltatime to remain smooth
    }
}
