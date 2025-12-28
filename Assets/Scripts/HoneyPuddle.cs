using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPuddle : MonoBehaviour
{
    [SerializeField] private Honeycomb _pairedHoneyComb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HoneyDrop>(out var honeyDrop)) 
        { 
            HoneyManager.Instance.PutDropBackInQueue(honeyDrop);
            _pairedHoneyComb.OnDropReachedPuddle();
        }
    }
}
