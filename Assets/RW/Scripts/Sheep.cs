//Controls the instances of sheep
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    private bool dropped;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;
    private float currentTime;
    public float heartOffset;
    public GameObject heartPrefab;
    public float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame and makes the sheep move forwards
    void Update()
    {
        //This increases the run speed by .1 every second
        currentTime = Time.fixedTime - GameSettings.startTime;
        transform.Translate(Vector3.forward * (runSpeed + (currentTime / speedIncrease)) * Time.deltaTime);
    }
    
    //On triggers checks if it is hit by a projectile or the end screen collision box
    private void OnTriggerEnter(Collider other)
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

    //When hit by a projectile this stops the sheep, plays a sound, and deletes object after a delay
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        Shrink();
    }

    //Shrinks sheep when hit
    private void Shrink()
    {
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
    }

    //Deletes sheep when it goes beyond play field
    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        SoundManager.Instance.PlaySheepDroppedClip();
        GameStateManager.Instance.DroppedSheep();
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }

    //Sets sheep spawner
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
