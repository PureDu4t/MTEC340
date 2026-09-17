using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    private Rigidbody2D rb;
    private float directionX;
    private float directionY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        directionX = 0.0f;
        directionY = 1.0f;
       
        float randomRotation = Random.Range(-90.0f, 90.0f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, randomRotation);
    }

    void Update()
    {
        transform.Translate(new Vector3(directionX, directionY, 0.0f) * Speed * Time.deltaTime);
    }
}
