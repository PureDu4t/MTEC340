using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour

{

    public static GameBehavior Instance;
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
        ResetGame();
    }

    void ResetGame()
    {
        Score = 0;
    }

    public void ScorePoint()
    {
        Score++;
    }
}
