using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventManager.Instance.InvokeOnGameInput(new Vector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventManager.Instance.InvokeOnGameInput(new Vector2(0, -1));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EventManager.Instance.InvokeOnGameInput(new Vector2(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            EventManager.Instance.InvokeOnGameInput(new Vector2(1, 0));
        }
    }
}
