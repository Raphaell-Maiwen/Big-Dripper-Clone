using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] PlayerInput _input;
    [SerializeField] private Bucket _bucket;
    [SerializeField] private GameObject _animal;
    [SerializeField] private Rigidbody _rb;

    private Vector2 movementInput = Vector2.zero;

    [SyncVar(hook = nameof(OnScoreChanged))]
    private int _score = 0;
    private TextMeshProUGUI _scoreLabel;
    private int _index;

    public void Init(TextMeshProUGUI scoreLabel, int index)
    {
        _scoreLabel = scoreLabel;
        _index = index;
        OnScoreChanged(0, 0);
    }

    private void Start()
    {
        //_bucket.gameObject.transform.SetParent(_animal.transform, false);
        _bucket.OnHoneyCollected.AddListener(CollectedHoney);
    }

    public void OnMove(InputAction.CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer) 
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
    }

    [Server]
    public void CollectedHoney() 
    {
        _score++;
    }

    void OnScoreChanged(int oldValue, int newValue) 
    {
        _scoreLabel.text = "P" + _index + ": " + _score;
    }

    public int GetScore() 
    {
        return _score;
    }

    public int GetIndex()
    {
        return _index;
    }
}
