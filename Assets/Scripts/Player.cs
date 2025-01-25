using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speedX; 

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * speedX, 0));
    }
}
