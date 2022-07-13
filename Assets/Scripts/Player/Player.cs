using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private int health = 3,score = 0;
    public GameObject[] healthlist = new GameObject[3];
    [SerializeField]
    private bool isdead = false, win = false, isfalling = false;
    public List<GameObject> playerlist;
    public static Player instance;
    private Rigidbody2D rb;
    private Animator anim;
    public Text scoretext;
    [SerializeField]
    private int index;
    //Sound
    public AudioSource aus, soundtrack;
    public AudioClip hitsound, jumpsound, collectsound, deadsound, winsound;
    //Item
    private bool invincible = false;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        rb = GetComponent<Rigidbody2D>();
        GameObject player = getPlayer();
        anim = player.GetComponent<Animator>();
        player.SetActive(true);
        
    }
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    private void Update()
    {
        
        scoretext.text = "x" + score.ToString();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Elixir"))
        {
            GetComponentInChildren<SpriteRenderer>().DOColor(Color.red, 3);
            collision.collider.gameObject.SetActive(false);
            Destroy(collision.collider);
            invincible = true;
            yield return new WaitForSeconds(20f);
            invincible = false;
            GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 1);
        }

        else if (collision.collider.tag != "Ground" )
        {
            if (invincible && collision.collider.tag != "Cup")
            {
                collision.collider.GetComponentInChildren<SpriteRenderer>().flipY = true;
                collision.collider.GetComponent<Collider2D>().enabled = false;
                Vector3 movement = new Vector3(Random.Range(40,70), -40,0);
                collision.collider.transform.position += movement * Time.deltaTime;
            }
            else
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
                                Destroy(collision.collider);
                            }

                        }
                        else
                        {
                            Collider2D col = collision.collider;
                            col.isTrigger = true;
                            col.GetComponent<Rigidbody2D>().gravityScale = 0;
                            decreaseHealth();
                            yield return new WaitForSeconds(2f);
                            col.isTrigger = false;
                            col.GetComponent<Rigidbody2D>().gravityScale = 1;
                            collision.collider.GetComponent<Rigidbody2D>().velocity = vt;


                        }


                    }
                    // WIN--------------------------------------------------------------------
                    if (collision.collider.CompareTag("Cup"))
                    {
                        win = true;
                        aus.PlayOneShot(winsound);
                        soundtrack.Stop();
                        UIManager.instance.showwinbanner(win);
                    }
                }
            }

        }
  
        yield return null;
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (invincible && !collision.CompareTag("Ground") && !collision.CompareTag("DeadZone") && !collision.CompareTag("Apple"))
            Destroy(collision);
        else
        {
            if (collision.CompareTag("Ocsen"))
            {

            }
            if (collision.CompareTag("Apple"))
            {
                score++;
                aus.PlayOneShot(collectsound);
                collision.GetComponent<Animator>().SetBool("iscollected", true);
                yield return new WaitForSeconds(0.5f);
                collision.gameObject.SetActive(false);
            }
            if (collision.CompareTag("Bullet"))
            {
                decreaseHealth();
                collision.gameObject.SetActive(false);
            }
            if (collision.CompareTag("Trap"))
            {
                decreaseHealth();
            }
            // LOSE -----------------------------------------------
            if (collision.CompareTag("DeadZone"))
            {
                isdead = true;
                soundtrack.Stop();
                aus.PlayOneShot(deadsound);
                UIManager.instance.showlosebanner(isdead);
            }
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
    public bool getinvincible()
    {
        return this.invincible;
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
        Player.instance.aus.PlayOneShot(Player.instance.hitsound);
        anim.Play("player_hit");
        health -= 1;
        if (health >= 0)
            healthlist[health].SetActive(false);
        if (health == 0)
        {
            isdead = true;
            aus.PlayOneShot(deadsound);
            soundtrack.Stop();
            UIManager.instance.showlosebanner(isdead);
        }
    }


    public void increaseScore()
    {
        score++;
    }
    

}
