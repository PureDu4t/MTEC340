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
    private AudioSource _source;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _scorePoint;
    [SerializeField] private AudioClip _death;
    
    Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        _startPosition = transform.position;

        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("Collision with paddle!!!");
            _source.PlayOneShot(_paddleHit);

            Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence)
                    + collision.rigidbody.linearVelocity * _paddleInfluence;
                
            _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized * _speedIncrement;    
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            _source.pitch = Random.Range(0.9f, 1.1f);
            _source.volume = Random.Range(0.8f, 1.0f);
            
            _source.clip = _wallHit;
            _source.Play();
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            _source.PlayOneShot(_scorePoint);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            _source.PlayOneShot(_death);
            ResetBall();
        }
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