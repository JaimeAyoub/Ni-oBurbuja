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

    public bool isMoving;



    public Vector2 friction;
    private float TotalVelocity;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
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
        if(Input.GetKey(KeyCode.D))
        {
            if(inputX < speedlimit)
                inputX += 0.1f;
            isMoving = true;

        }
        else if(Input.GetKey(KeyCode.A))
        {
            if(inputX > -speedlimit)
             inputX -= 0.1f;
            isMoving = true;
        }
        else
        {
            isMoving = false;
            if (inputX > 0.01)
            {
                Mathf.Round(TotalVelocity -= friction.x);
                TotalVelocity = (Time.deltaTime * speedX * inputX);
            }
            else
            {
                TotalVelocity = (Time.deltaTime * speedX * inputX);
            }
            //else
            //{
            //    Mathf.Round(TotalVelocity += friction.x);
            //    TotalVelocity = (Time.deltaTime * speedX * inputX);
            //}
        }
        if(!isMoving && inputX != 0)
        {
            if (inputX > 0.01)
            {
                Mathf.Round(inputX -= friction.x);
                TotalVelocity = (Time.deltaTime * speedX * inputX);
            } else if (inputX < -0.01)
            {
                Mathf.Round(inputX += friction.x);
                TotalVelocity = (Time.deltaTime * speedX * inputX);
            }
        }
        

        

    

        TotalVelocity = (Time.deltaTime * speedX * inputX);

        rb.velocity = new Vector2(TotalVelocity, 0);
    }
}
