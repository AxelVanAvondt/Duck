using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Follow : MonoBehaviour
{
    public GameObject player;
    public float distanceFromPlayer = 4;
    public Vector2 bottomLeft = new Vector2(-10, -5);
    public Vector2 topRight = new Vector2(10, 5);
    public GameObject background;

    private Vector2 fieldSize;
    private Vector3 backgroundPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (background == null)
        {
            Debug.Log("Camera has no background set");
        }
        fieldSize = topRight - bottomLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -distanceFromPlayer);
        }

        backgroundPosition = background.transform.position;
        backgroundPosition.x = transform.position.x + (transform.position.x / fieldSize.x);
        backgroundPosition.y = transform.position.y + (transform.position.y / fieldSize.y);

        background.transform.position = backgroundPosition;
    }

    public void FocusOn(GameObject player)
    {
        this.player = player;
    }
}
