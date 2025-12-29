using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] PlayerInput _input;
    [SerializeField] private Bucket _bucket;
    [SerializeField] private GameObject _animal;
    [SerializeField] private Rigidbody _rb;

    private Vector2 movementInput = Vector2.zero;
    private int _score = 0;

    private void Start()
    {
        _bucket.gameObject.transform.SetParent(_animal.transform, false);
        _bucket.OnHoneyCollected.AddListener(CollectedHoney);
    }

    public void OnMove(InputAction.CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y).normalized;
        if (movement.magnitude >= 0.1f)
        {
            _rb.velocity = new Vector3(movement.x * _speed, _rb.velocity.y, movement.z * _speed);
            transform.rotation = Quaternion.Slerp(_rb.rotation, Quaternion.LookRotation(movement), Time.fixedDeltaTime * _rotationSpeed);
        }
        else 
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
    }

    public void CollectedHoney() 
    {
        _score++;
        Debug.Log("Score " + _score);
    }
}
