using UnityEngine;
using UnityEngine.Events;

public class Bucket : MonoBehaviour
{
    public UnityEvent OnHoneyCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HoneyDrop honeyDrop)) 
        {
            HoneyManager.Instance.PutDropBackInQueue(honeyDrop);
            OnHoneyCollected?.Invoke();
        }
    }
}
