using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 7.0f;
    [SerializeField] private float _speedIncrement = 1.1f;
    
    [SerializeField] private float _paddleInfluence = 0.4f;
    [SerializeField] private Vector3 _startPosition;
    
    Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;

        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(collision.rigidbody.linearVelocityY, 0.0f))
            {
                Debug.Log("Collision with paddle!!!");

                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence)
                                    + collision.rigidbody.linearVelocity * _paddleInfluence;
                
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized * _speedIncrement;
            }    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetBall();
    }

    private void ResetBall()
    {
        // Stop the ball
        _rb.linearVelocity = Vector2.zero;
        
        transform.position = _startPosition;
        
        float angle = Random.Range(-45f, 45f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        
        // Launch ball in the computed direction with the specified force
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }
}