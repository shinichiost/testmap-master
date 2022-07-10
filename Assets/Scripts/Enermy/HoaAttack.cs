using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletposition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField]
    private bool isdestroyed = false;
    private float t1 = 0;
    private float t2 = 2.38f;

 
    void Update()
    {
        if(!isdestroyed)
            shot();
    }
    void shot()
    {
        if (t1 > t2)
        {
            GameObject bullet = ObjectPool.instance.getPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = bulletposition.position;
                bullet.SetActive(true);
            }
            t1 = 0;
        }
        else
        {
            t1 += Time.deltaTime;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<Rigidbody2D>().velocity.y<0)
        {
            isdestroyed = true;
        }

    }
}



