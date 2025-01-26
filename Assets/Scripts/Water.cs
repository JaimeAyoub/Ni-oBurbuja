using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool isRight;
    public float Force;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(collision);
            if (isRight)
            {
                rb.AddForce(new Vector2(Mathf.Lerp(rb.velocity.x, -Force, Time.deltaTime * 20), rb.velocity.y));
            }
            else
            {
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, Force, Time.deltaTime * 2), rb.velocity.y);
            }
        }
    }

}

