using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float _direction = 0.0f;
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private KeyCode _updirection = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downdirection = KeyCode.DownArrow;

    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityY = _direction * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = 0.0f;

        if (Input.GetKey(_updirection))
        {
            _direction += 1.0f;
        }
        if (Input.GetKey(_downdirection))
        {
            _direction -= 1.0f;
        }
    }
}

