using System;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    [SerializeField] private string _dataLocation;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnScoreChanged += OnScoreChanged;
        EventManager.Instance.InvokeOnUpdateHighScoreUI(GetHighScore());
    }

    private void OnScoreChanged(int score)
    {
        if (score > Int32.Parse(File.ReadAllText(_dataLocation + "highscore.txt")))
        {
            UpdateHighScore(score);
            EventManager.Instance.InvokeOnUpdateHighScoreUI(GetHighScore());
        }
    }

    private void UpdateHighScore(int score)
    {
        File.WriteAllText(_dataLocation + "highscore.txt", score.ToString());
    }

    private int GetHighScore()
    {
        return Int32.Parse(File.ReadAllText(_dataLocation + "highscore.txt"));
    }
}
