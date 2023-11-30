using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static GM instance { get; private set; }

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

    public GameObject player;
    public GameObject sp;
    public GameObject playerPrefab;
    public bool gameActive = false;

    private void Update()
    {
        if (!gameActive && Input.GetKeyDown(KeyCode.R))
        {
            StartNewGame();
        }
    }

    private void InstantiatePlayer()
    {
        player = Instantiate(playerPrefab);
        player.transform.position = sp.transform.position;
        FindObjectOfType<C_Follow>().FocusOn(player);
    }

    public void StartNewGame()
    {
        if (sp == null)
        {
            Debug.Log("Spawnpoint has failed to exist");
        }
        else
        {
            InstantiatePlayer();

            SM.instance.StartNewGame();
            gameActive = true;
        }
    }

    public void RespawnIfPossible()
    {
        if (SM.instance.Lives > 0)
        {
            InstantiatePlayer();
        }
    }
}
