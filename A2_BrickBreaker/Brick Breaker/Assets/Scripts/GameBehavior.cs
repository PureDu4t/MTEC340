using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour

{
    public Color _originalColor;
    [SerializeField] private Transform _bricksParent;
    public SpriteRenderer[] _bricks;
    public static GameBehavior Instance;
    public Utilities.GameState State;
    [SerializeField] private TMP_Text _scoreUI;

    public int Score
    {
        get
        { 
            return _score; // Executed when someone READS Score
        }

        set
        {
            _score = value;
            _scoreUI.SetText(Score.ToString());
        }
    }
    private int _score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("New instance initialized...");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance found and deleted...");
        }
    }

    void Start()
    {
        _bricks = _bricksParent.GetComponentsInChildren<SpriteRenderer>(true);

        if (_bricks.Length > 0)
        {
            _originalColor = _bricks[0].color;
        }

        ResetGame();
        State = Utilities.GameState.Play;
    }

    void ResetGame()
{
    Score = 0;

    foreach (SpriteRenderer brick in _bricks)
    {
        if (brick != null)
        {
            brick.color = _originalColor;
        }
    }
}

    public void ScorePoint()
    {
        Score++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            State = State == Utilities.GameState.Play ?
                    Utilities.GameState.Pause :
                    Utilities.GameState.Play;
        }
    }
}
