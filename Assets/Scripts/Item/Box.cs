using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject item;
    public Player player;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.CompareTag("Player") )
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.y > 1)
            {
                anim.SetBool("isbreak", true);
                yield return new WaitForSeconds(2);
                Destroy(this.gameObject);
            }
        }
        yield return null;
    }

}
