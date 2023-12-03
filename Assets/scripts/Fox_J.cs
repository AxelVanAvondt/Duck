using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_J : MonoBehaviour
{
    public LayerMask jumpableGround;
    public float jumpforce = 7f;
    public Animator an;
    public BoxCollider2D bc;
    public Rigidbody2D Fox;
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Fox.velocity = new Vector2(Fox.velocity.x, jumpforce);
            an.SetBool("jump", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        an.SetBool("jump", false);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Jerry_H>())
        {
            Fox.velocity = new Vector2(Fox.velocity.x, 0f);
            Fox.AddForce(Vector2.up * 200f);
        }
    }
}
