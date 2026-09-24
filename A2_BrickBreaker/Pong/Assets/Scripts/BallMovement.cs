using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] public float _launchForce = 5.0f;
    [SerializeField] private float _paddleInfluence = 0.4f;
    [SerializeField] private float _speedIncrement = 1.0f; // Added missing variable
    
    Rigidbody2D _rb;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Vector2 direction = Random.insideUnitCircle.normalized;

        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Fixed: changed linearVelocityY to linearVelocity.y
            if (!Mathf.Approximately(collision.rigidbody.linearVelocity.y, 0.0f))
            {
                // We compute direction using a weighted sum, where the weights use a one minus to be determined
                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence)
                + collision.rigidbody.linearVelocity * _paddleInfluence;

                // Fixed: changed direction.normalize to direction.normalized
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
        //stop the ball
        _rb.linearVelocity = Vector2.zero;

        //teleport the ball to the middle of the screen
        transform.position = Vector3.zero;

        //compute a new random direction
        Vector2 direction = Random.insideUnitCircle.normalized;

        //launch ball in the computed direction with the specified force
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }
}