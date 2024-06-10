using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBorder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("touched border");
        Destroy(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("touched border");
        Destroy(collision.gameObject);
    }
}
