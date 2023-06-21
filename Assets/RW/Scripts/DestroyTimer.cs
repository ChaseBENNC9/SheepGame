using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script destroys the specified object after a certain ammount of time.
public class DestroyTimer : MonoBehaviour
{
    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

}
