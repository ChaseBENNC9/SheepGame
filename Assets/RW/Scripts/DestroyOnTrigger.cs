using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//When an object enters the area of a collider and matches the specified tag, the object is destroyed , eg - hay bales or sheep. 
public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            Destroy(gameObject);
        }
    }
}
