using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerry_H : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Fox_J>())
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
