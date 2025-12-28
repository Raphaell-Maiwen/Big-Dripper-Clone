using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void StartGravity()
    {
        _rigidbody.useGravity = true;
    }

    public void StopGravity()
    {
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
    }
}
