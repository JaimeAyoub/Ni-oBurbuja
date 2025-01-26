using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float inputX;
    public float speedlimit;
    public float speedX;
    public bool isMoving;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       Move();
    }

    private void Move()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speedX, -5f));
        rb.drag = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    { 
        //TODO DESPLEGAR GAME OVER MENU
        Time.timeScale = 0f;
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
