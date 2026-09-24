using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    private float _direction = 0.0f;
    
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private KeyCode _upDirection = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _downDirection = KeyCode.RightArrow;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _direction * _speed;
    }

    void Update()
    {
        _direction = 0.0f;

        if (Input.GetKey(_upDirection))
        {
            _direction += 1.0f;
        }

        if (Input.GetKey(_downDirection))
        {
            _direction -= 1.0f;
        }
    }
}