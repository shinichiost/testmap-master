using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    public Playermovement playermovement;
    Player player;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var EnermyParent = collision.collider.transform.parent.gameObject;
        if (collision.collider.CompareTag("Ground"))
        {
            playermovement.setGrounded(true) ;
        }
        if (EnermyParent.CompareTag("Enermy") || collision.collider.CompareTag("Enermy"))
        {
            player.increaseHealth();
            Destroy(collision.collider);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            playermovement.setGrounded(false);
        }
    }
}
