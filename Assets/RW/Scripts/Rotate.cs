using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script rotates the hay bale 
public class Rotate : MonoBehaviour 
{
    public Vector3 rotationSpeed; //The Rotation speed of the object, each axis can have a different speed 


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime); //Roatates object at a specific speed for each axis of the vector3
    }
}
