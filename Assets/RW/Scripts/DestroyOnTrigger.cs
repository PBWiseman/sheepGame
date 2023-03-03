using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("TEst1");
        if (other.CompareTag(tagFilter)) 
        {
            Debug.Log("Test");
            Destroy(gameObject); 
        }
    }
}
