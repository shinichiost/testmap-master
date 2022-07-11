using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private int health = 3,score = 0;
    public GameObject[] healthlist = new GameObject[3];
    [SerializeField]
    private bool isdead = false, win = false, isfalling = false;
    public List<GameObject> playerlist;
    public static Player instance;
    private Rigidbody2D rb;
    public GameObject enermy;
    public GameObject winbanner;
    public GameObject losebanner;
    private Animator anim;
    public Text scoretext;
    [SerializeField]
    private int index;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        rb = GetComponent<Rigidbody2D>();
        GameObject player = getPlayer();
        anim = player.GetComponent<Animator>();
        player.SetActive(true);
        
    }
    private void Update()
    {
        
        scoretext.text = "x" + score.ToString();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ground")
        {
            Vector2 vt = collision.collider.GetComponent<Rigidbody2D>().velocity;
            if (collision.collider.transform.parent.gameObject != null)
            {
                var EnermyParent = collision.collider.transform.parent.gameObject;

                if (EnermyParent.CompareTag("Enermy"))
                {
                    if (rb.velocity.y < 0)
                    {

                        if (collision.collider.tag != "Ocsen")
                        {
                            collision.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, vt.y);
                            collision.collider.isTrigger = true;
                            Destroy(collision.collider);
                        }

                    }
                    else
                    {
                        collision.collider.isTrigger = true;
                        collision.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(vt.x, 0);
                        decreaseHealth();
                        yield return new WaitForSeconds(2f);
                        collision.collider.isTrigger = false;
                        collision.collider.GetComponent<Rigidbody2D>().velocity = vt;


                    }


                }
                if (collision.collider.CompareTag("Cup"))
                {
                    win = true;
                    UIManager.instance.showwinbanner(win);
                }
            }


        }
        yield return null;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ocsen"))
            {
            
        }
        if (collision.CompareTag("Apple"))
        {
            score++;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("DeadZone"))
        {
            isdead = true;
            UIManager.instance.showlosebanner(isdead);
        }
        if (collision.CompareTag("Bullet"))
        {
            decreaseHealth();
            collision.gameObject.SetActive(false);
        }
        if(collision.CompareTag("Trap"))
        {
            decreaseHealth();
        }
            
    }


    public bool getLose()
    {
        return this.isdead;
    }
    public void setLose(bool isdead)
    {
        this.isdead = isdead;
    }
    public bool getWin()
    {
        return this.win;
    }
    public GameObject getPlayer()
    {
        return playerlist[CharacterSelection.getIndex()];
    }
    public void increaseHealth()
    {
        this.health += 1;
    }
    public void decreaseHealth()
    {
        anim.Play("player_hit");
        health -= 1;
        if (health >= 0)
            healthlist[health].SetActive(false);
        if (health == 0)
        {
            isdead = true;
            UIManager.instance.showlosebanner(isdead);
        }
    }
    public void increaseScore()
    {
        score++;
    }
    

}
