using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerry : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;

    public LayerMask ground;
    public float speed;

    private int direction;
    private float scaleX;

    // Start is called before the first frame update
    void Start()
    {

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        scaleX = Mathf.Abs(transform.localScale.x);
        transform.localScale = new Vector2(scaleX * direction, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += Time.deltaTime * speed * direction;
        transform.position = position;

        if (!WalkableSurface())
        {
            direction = -direction;
            transform.localScale = new Vector2(scaleX * direction * -1, transform.localScale.y);
        }
    }

    private bool WalkableSurface()
    {
        Vector2 position = coll.bounds.center;
        position.x += coll.bounds.size.x * direction;
        return Physics2D.BoxCast(position, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
}
