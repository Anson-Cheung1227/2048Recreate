using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private TMP_Text _highScoreText;

    private void Awake()
    {
        EventManager.Instance.OnScoreChanged += UpdateScoreUI;
        EventManager.Instance.OnUpdateHighScoreUI += UpdateHighScoreUI;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScoreUI(int score)
    {
        _scoreText.text = score.ToString();
    }
    public void UpdateHighScoreUI(int highscore)
    {
        _highScoreText.text = highscore.ToString();
    }

    public void OnNewGameButtonPressed()
    {
        GameManager.Instance.OnNewGameButtonPressed();
    }
}
