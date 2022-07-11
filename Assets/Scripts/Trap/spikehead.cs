using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikehead : MonoBehaviour
{
    private int direct = 1;
    float movespeed = 2f;
    private Rigidbody2D rb;
    private bool isdestroyed = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = -Vector2.up * movespeed * direct;
    }
    private void changedirection()
    {
        direct = -direct;
        transform.localScale = new Vector3(direct, 1, 1);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tuong"))
            changedirection();
    }
}
