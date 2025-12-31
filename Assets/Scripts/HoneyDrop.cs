using Mirror;
using UnityEngine;

public class HoneyDrop : NetworkBehaviour
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
