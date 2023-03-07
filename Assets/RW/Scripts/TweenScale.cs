using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script adds the scaling animation for the heart effect
public class TweenScale : MonoBehaviour
{
    public float targetScale;
    public float timeToReachTarget;
    private float startScale;
    private float percentScaled;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) //the object is scaled until it reaches its target scale in a specified time.
        {
            percentScaled += Time.deltaTime / timeToReachTarget; 
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); 
            transform.localScale = new Vector3(scale, scale, scale); 
        }
    }
}
