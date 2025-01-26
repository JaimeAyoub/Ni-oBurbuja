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

    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * speedX;

        Destroy(this.gameObject, 5);
    }
}
