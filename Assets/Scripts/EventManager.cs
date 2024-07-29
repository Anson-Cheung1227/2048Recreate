using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnUpdateHighScoreUI;
    public event Action<Vector2> OnGameInput;
    

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeOnGameInput(Vector2 direction)
    {
        OnGameInput?.Invoke(direction);
    }
    public void InvokeOnScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }
    public void InvokeOnUpdateHighScoreUI(int score)
    {
        OnUpdateHighScoreUI?.Invoke(score);
    }
}
