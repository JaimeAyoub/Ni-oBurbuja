using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float inputX;
    public float speedX;
    public float speedlimit;
    public bool isPlayerRunning;
    private bool isFacingRight = true;
    public bool isMoving;
    public StaminaScript staminaScript;

    //public Animator playerAnimator;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        
        staminaScript = GetComponent<StaminaScript>();
    }


    void Update()
    {
        Move(staminaScript.IsOutOfStamina());
        // Debug.Log(rb.);
        HandleAnimationRunning();
        if(Input.GetAxis("Horizontal") < 0 && isFacingRight)
        {
            Flip(); 
        }else if (Input.GetAxis("Horizontal") >= 0 && !isFacingRight)
        {  isFacingRight = true;}

        if (isFacingRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
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
            //playerAnimator.SetBool("IsPlayerRunning", true);
        }
        else
        {
            //playerAnimator.SetBool("IsPlayerRunning", false);
        }
    }

    public void Move(bool outOfStamina)
    {
        if(outOfStamina == false)
        {
            isPlayerRunning = true;
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speedX, -5f));
            rb.drag = 0;
        }
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
