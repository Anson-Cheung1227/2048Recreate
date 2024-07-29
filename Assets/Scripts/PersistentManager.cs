using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!Application.isEditor)
        {
            SceneManager.LoadScene("Core", LoadSceneMode.Additive);
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }

    public void Restart()
    {
        SceneManager.UnloadSceneAsync("UI");
        SceneManager.UnloadSceneAsync("Core");
        SceneManager.LoadScene("Core", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
}
