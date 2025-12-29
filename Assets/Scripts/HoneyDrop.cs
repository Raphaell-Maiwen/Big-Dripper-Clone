using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private Honeycomb _honeycombSpawnedFrom;

    public void Spawn(Honeycomb honeycomb)
    {
        _rigidbody.useGravity = true;
        _honeycombSpawnedFrom = honeycomb;
    }

    public void UnSpawn()
    {
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _honeycombSpawnedFrom.OnDropReachedPuddle();
    }
}
