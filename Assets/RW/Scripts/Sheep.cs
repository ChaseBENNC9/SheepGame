using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script controls the sheep and its functionality
public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float maxSpeed = 25;
    public float SpeedIncreaseRate = 0.75f;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    private bool dropped;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;
    public float heartOffset;
    public GameObject heartPrefab;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() 
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

        if(runSpeed < maxSpeed)
        {
            runSpeed += (0.75f * Time.deltaTime);
        }
        

    }

    private void HitByHay() //When the sheep is hit by a hay bale it is removed from the list of active sheep so it can't be hit again. Plays a small animation of a heart and shrinks the sheep.
    {

        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;

        Destroy(gameObject,gotHayDestroyDelay);
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0; 
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
    }

    private void OnTriggerEnter(Collider other) //Tests if the collider it enters matches a hay bale or the drop collider at the end of the island
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }
    private void Drop() //when the sheep reaches the end, gravity is added to it so it falls and it is destroyed after a small delay
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject,dropDestroyDelay);
        SoundManager.Instance.PlaySheepDroppedClip();
        GameStateManager.Instance.DroppedSheep();
    }

    public void SetSpawner(SheepSpawner spawner) //Sets the spawner where sheep will instantiate to.
    {
        sheepSpawner = spawner;
    }
}
