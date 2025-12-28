using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPuddle : MonoBehaviour
{
    private HoneyManager _honeyManager;
    [SerializeField] private Honeycomb _pairedHoneyComb;

    public void Init(HoneyManager honeyManager)
    {
        _honeyManager = honeyManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HoneyDrop>(out var honeyDrop)) 
        { 
            _honeyManager.PutDropBackInQueue(honeyDrop);
            _pairedHoneyComb.OnDropReachedPuddle();
        }
    }
}
