using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private bool isFacingRight = true;
    private float speedX;
    private float inputX;
    private Rigidbody2D rb;
    public GameObject groundCheck;
    public GameObject wallCheck;
    public LayerMask jasbcdhasdhkaisb;
    public Animator rataAnimator;
    private bool continueAnim;
    public float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputX = Input.GetAxis("Horizontal");
        speedX = 3f;
        timer = 25f;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, 0.4f, jasbcdhasdhkaisb);
        RaycastHit2D hitwall = Physics2D.Raycast(wallCheck.transform.position, Vector2.right, 0.4f, jasbcdhasdhkaisb);

        MoveAnim(hit);

        if(!hit.collider)
        {
            Flip();
        }
        if (hitwall)
        {
            Flip();
        }

        if(isFacingRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void MoveAnim(RaycastHit2D groundHit)
    {
        timer -= 0.1f;

        if (!groundHit)
        {
            rataAnimator.SetBool("RataFlip", true);
            continueAnim = true;
        }

        if (timer <= 0)
        {
            continueAnim = false;
            
            timer = 25;
        }

        if (continueAnim == false)
        {
            rataAnimator.SetBool("RataFlip", false);
            EnemyMove();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
    }

    void EnemyMove()
    {
        transform.Translate(Vector2.right * speedX * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
