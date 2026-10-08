using UnityEngine;
public class BrickBehavior : MonoBehaviour
{
    private SpriteRenderer _brick;
    private int HP = 3;
    
    void Start()
    {
        _brick = GetComponent<SpriteRenderer>();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameBehavior.Instance.ScorePoint();
        HP--;

        if (HP == 2)
        {
            _brick.color = Color.yellow;
        }
        else if (HP == 1)
        {
            _brick.color = Color.red;
        }
        else if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}