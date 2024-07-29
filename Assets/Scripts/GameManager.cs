using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _endScreen; 
    public int Score { get; private set; } = 0; 
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.InvokeOnScoreChanged(Score);
    }

    public void DeathState()
    {
        _endScreen.SetActive(true);
    }

    public void AddScore(int score)
    {
        Score += score;
        EventManager.Instance.InvokeOnScoreChanged(Score);
    }

    public void OnNewGameButtonPressed()
    {
        PersistentManager.Instance.Restart();
    }
}
