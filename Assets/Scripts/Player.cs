using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;

    private float inputX;


    public float speedX;
    public float speedlimit;
    public float speedlimitNegative;


    public Vector2 friction;
    private float TotalVelocity;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        speedlimitNegative = -speedlimit;
    }

    // Update is called once per frame
    void Update()
    {
        //inputXRight = Input.GetAxis("Horizontal");
        Move();
        Debug.Log(inputX);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (inputX <= speedlimit)
            {
                inputX += 0.05f;

            }
            else if (inputX > speedlimit)
            {
                inputX = speedlimit;
            }

            TotalVelocity = (speedX * inputX);
        }
        else
        {
            if (inputX > 0)
            {
                inputX -= 0.005f;
                TotalVelocity = (speedX * inputX);
            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (inputX >= -speedlimit)
            {
                inputX -= 0.05f;

            }
            else if (inputX < -speedlimit)
            {
                inputX = -speedlimit;
            }

            TotalVelocity = (speedX * inputX);
        }
        else
        {
            if (inputX < 0)
            {
                inputX += 0.005f;
                TotalVelocity = (speedX * inputX);
            }
        }

        if (TotalVelocity > 0)
            TotalVelocity -= friction.x;
        if (TotalVelocity <= 0)
            TotalVelocity += friction.x;



        rb.velocity = new Vector2(TotalVelocity, 0);
    }
}
