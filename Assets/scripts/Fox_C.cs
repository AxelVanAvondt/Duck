using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fox_C : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator an;
    public float dirX = 0f;
    public float movespeed = 5f;
    public float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * movespeed, rb.velocity.y);
        if (dirX < 0f && gameObject.transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
        }
        if (dirX > 0f && gameObject.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
        }
        rb.rotation = 0;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        an.SetFloat("speed", Mathf.Abs(dirX));
    }
    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }
    public void Kill()
    {
        health = 0;
        SM.instance.RemoveLife();
        GM.instance.RespawnIfPossible();
        Destroy(gameObject);
    }
}
