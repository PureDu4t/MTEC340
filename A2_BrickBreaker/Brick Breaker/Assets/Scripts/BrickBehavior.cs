using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameBehavior.Instance.ScorePoint();
        Destroy(gameObject);
    }
}