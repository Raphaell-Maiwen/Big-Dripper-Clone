using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HoneyDrop honeyDrop)) 
        {
            HoneyManager.Instance.PutDropBackInQueue(honeyDrop);
            //Something for the score here
        }
    }
}
