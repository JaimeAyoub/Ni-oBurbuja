using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputX = Input.GetAxis("Horizontal");
        speedX = 3f;

    }
    private void FixedUpdate()
    {
        EnemyMove();

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, 0.4f, jasbcdhasdhkaisb);
        RaycastHit2D hitwall = Physics2D.Raycast(wallCheck.transform.position, Vector2.right, 0.4f);
        //Debug.Log(hitwall.collider);
        if(!hit.collider)
        {
            StartCoroutine(RataWait());
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

    void Flip()
    {
        isFacingRight = !isFacingRight;
    }

    void Update()
    {
        
    }

    void EnemyMove()
    {
        transform.Translate(Vector2.right * speedX * Time.deltaTime);
    }

    IEnumerator RataWait()
    {
        //rataAnimator.SetBool();
        yield return new WaitForSeconds(2);
        //rataAnimator.SetBool();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Vector3 direction = ; 
        Gizmos.DrawLine(groundCheck.transform.position, new Vector3(groundCheck.transform.position.x, groundCheck.transform.position.y - 0.4f, groundCheck.transform.position.z));
        Gizmos.DrawLine(wallCheck.transform.position, new Vector2(wallCheck.transform.position.x + 0.5f, wallCheck.transform.position.y));
    }

}
