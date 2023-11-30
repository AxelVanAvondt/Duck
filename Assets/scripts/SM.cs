using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM : MonoBehaviour
{
    public static SM instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int Lives = 0;

    public void StartNewGame()
    {
        Lives = 3;
    }

    public void RemoveLife()
    {
        Lives--;
    }
}
