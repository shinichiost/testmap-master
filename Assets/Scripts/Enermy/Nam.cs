using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Nam : MonoBehaviour
{
    private int direct = 1;
    float movespeed = 2f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

     
    void Update()
    {
        mushRoomMoving();
    }
    public void mushRoomMoving()
    {
        
            rb.velocity = Vector2.left * movespeed * direct;
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tuong"))
            changedirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            Destroy(this);
        }
            
    }
 
    private void changedirection()
    { 
        direct = -direct;
        transform.localScale = new Vector3(direct,1,1);
    }
}

