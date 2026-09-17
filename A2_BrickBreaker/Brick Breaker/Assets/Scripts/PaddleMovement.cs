using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    public KeyCode LeftDirection = KeyCode.LeftArrow;
    public KeyCode RightDirection = KeyCode.RightArrow;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.0f;

        if (Input.GetKey(LeftDirection))
        {
            movement -= Speed;
        }
        if (Input.GetKey(RightDirection))
        {
            movement += Speed;
        }

        movement *= Time.deltaTime;

        Vector2 targetPosition = rb.position + new Vector2(movement, 0.0f);
        rb.MovePosition(targetPosition);
    }
}
