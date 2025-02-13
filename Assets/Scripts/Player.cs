using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;

    //public AudioManager audioManager;

    private float inputX;

    public MenuManager menuManager;
    public float speedX;
    public float speedlimit;

    public float timerUp;
    public float tiempoPresion;


    public Animator playerAnimator;
    public bool isPlayerRunning;

    public bool isMoving;

    private bool isFacingRight = true;

    //public Vector2 friction;
    //private float TotalVelocity;



    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        //audioManager.PlaySFX(audioManager.BGM);
    }


    void Update()
    {
        Move();
        // Debug.Log(rb.);
        HandleAnimationRunning();
        if (Input.GetAxis("Horizontal") < 0 && isFacingRight)
        {
            Flip();
        }
        else if (Input.GetAxis("Horizontal") >= 0 && !isFacingRight)
        { isFacingRight = true; }

        if (isFacingRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            menuManager.OpenEndMenu();
        }
        if (collision.gameObject.CompareTag("End"))
        {
            menuManager.OpenEndMenu();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            menuManager.OpenEndMenu();
        }

    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
    }

    private void HandleAnimationRunning()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            playerAnimator.SetBool("IsPlayerRunning", true);

           // AudioManager.Instance.PlaySFX("KeyPress");

        }
        else
        {
            playerAnimator.SetBool("IsPlayerRunning", false);
        }
    }

    private void Move()
    {
        
        isPlayerRunning = true;
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speedX, -5f));
        if (Input.GetKey(KeyCode.K))
        {
            if (tiempoPresion < timerUp)
            {
                tiempoPresion += Time.deltaTime;
                Up();
            }
            else
            {
                tiempoPresion = 0;
            }

        }


    }
    void Up()
    {
        rb.AddForce(Vector2.up * 5);
    }

    

    #region JAIME PHYSICS
    //private void Move()
    //{
    //    if(Input.GetKey(KeyCode.D))
    //    {
    //        if(inputX < speedlimit)
    //            inputX += 0.1f;
    //        isMoving = true;

    //    }
    //    else if(Input.GetKey(KeyCode.A))
    //    {
    //        if(inputX > -speedlimit)
    //         inputX -= 0.1f;
    //        isMoving = true;
    //    }
    //    else
    //    {
    //        isMoving = false;
    //        if (inputX > 0.01)
    //        {
    //            Mathf.Round(TotalVelocity -= friction.x);
    //            TotalVelocity = (Time.deltaTime * speedX * inputX);
    //        }
    //        else
    //        {
    //            TotalVelocity = (Time.deltaTime * speedX * inputX);
    //        }
    //        //else
    //        //{
    //        //    Mathf.Round(TotalVelocity += friction.x);
    //        //    TotalVelocity = (Time.deltaTime * speedX * inputX);
    //        //}
    //    }
    //    if(!isMoving && inputX != 0)
    //    {
    //        if (inputX > 0.01)
    //        {
    //            Mathf.Round(inputX -= friction.x);
    //            TotalVelocity = (Time.deltaTime * speedX * inputX);
    //        } else if (inputX < -0.01)
    //        {
    //            Mathf.Round(inputX += friction.x);
    //            TotalVelocity = (Time.deltaTime * speedX * inputX);
    //        }
    //    }






    //    TotalVelocity = (Time.deltaTime * speedX * inputX);

    //    rb.velocity = new Vector2(TotalVelocity, 0);
    //}
    #endregion
}
