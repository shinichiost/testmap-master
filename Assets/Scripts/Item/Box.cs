using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Box : MonoBehaviour
{
    public GameObject Elixir;
    public int fruitamount = 0, direct = 1;
    public bool haveelixir = false, bebroken = false;
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

                StartCoroutine(boxcollider());
            } 
        }
        yield return null;
    }
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.GetComponent<Rigidbody2D>().velocity.y > 1)
            {
                StartCoroutine(boxcollider());
            }
        }
        yield return null;
    }
    IEnumerator boxcollider()
    {
        transform.DOMoveY(transform.position.y + 0.2f, 0.2f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
        if(haveelixir)
        {
            fruitamount = 0;
            GameObject elixir = Instantiate(Elixir);
            elixir.transform.position = transform.position;
            elixir.SetActive(true);
            elixir.transform.DOMoveY(transform.position.y + 1, 0.5f);
            elixir.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            elixir.GetComponent<Rigidbody2D>().velocity = -Vector2.right * 2f * direct;
        }
        if (fruitamount > 0)
        {
            fruitamount--;
            Player.instance.increaseScore();
            Player.instance.aus.PlayOneShot(Player.instance.collectsound);
            GameObject fruit = ObjectPoolFruits.instance.getpooledObject();
            if (fruit != null)
            {
                fruit.transform.position = transform.position;
                fruit.SetActive(true);
            }
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(fruit.transform.DOMoveY(fruit.transform.position.y + 1, 0.5f)).Append(fruit.GetComponent<SpriteRenderer>().DOFade(0, 1)).SetUpdate(true);
            fruit.transform.DORotate(new Vector3(0, 180, 0), 0.25f).SetLoops(4);
            yield return new WaitForSeconds(2);
            fruit.GetComponent<SpriteRenderer>().DOFade(1, 0);
            fruit.SetActive(false);
        }
        else
        {
            if (bebroken)
            {
                anim.SetBool("isbreak", true);
                yield return new WaitForSeconds(0.5f);
                Destroy(this.gameObject);
            }
            
        }
    }
    private void changedirection()
    {
        direct = -direct;
        transform.localScale = new Vector3(direct, 1, 1);
    }
}
