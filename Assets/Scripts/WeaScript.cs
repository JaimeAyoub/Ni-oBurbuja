using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaScript : MonoBehaviour
{
    public float speedX;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * speedX;
    }
}
