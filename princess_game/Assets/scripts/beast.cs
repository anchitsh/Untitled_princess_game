using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beast : MonoBehaviour
{

    public GameObject positionA, positionB;
    bool positionAbool, positionBbool;
    // float start_pos;
    // float end_pos;
    // public float units_mov;
    Rigidbody2D rb, player;
    public bool direction;
    public float velocity;
    private SpriteRenderer spriteren;
    bool corbool, stop;
    Animator ani;
    float playerpos, enpos;
    GameObject pl;
    public float playerDistanceattack, prepdistance;
    bool state2start, state2bool;
    Vector2 startposition;
    public float attackdistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  start_pos = transform.position.x;
        // end_pos = start_pos - units_mov;
        direction = false;
        ani = GetComponent<Animator>();

        pl = GameObject.FindWithTag("Player");
        player = pl.GetComponent<Rigidbody2D>();

        state2start = false;
        state2bool =false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop == false)
        {
            playerpos = player.transform.position.x;
            enpos = rb.transform.position.x;
            float distance = Mathf.Abs(playerpos - enpos);

            if (distance < playerDistanceattack)
            {
                state2bool = true;



            }
            else if (distance < prepdistance && state2bool == false)
            {
                ani.SetBool("prep", true);
                ani.SetBool("attack", false);
                if (playerpos > enpos)
                {
                    direction = true;
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    direction = false;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }

            else if (state2bool == false && distance > prepdistance)
            {
                state1();
                ani.SetBool("idle", true);
                ani.SetBool("attack", false);
                ani.SetBool("prep", false);
            }

            if (state2bool)
            {
                state2();
            }

        }
        else
        {
             ani.SetBool("idle", true);
        }

    }
    void state1()
    {
    }

    void state2()
    {
        
        if (state2start== false)
        {
            state2start = true;
            startposition = transform.position;


            if (playerpos > enpos)
            {
                direction = true;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                direction = false;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        ani.SetBool("attack", true);
        ani.SetBool("prep", false);
        ani.SetBool("idle", false);
        move();

    }
    void move()
    {
        if (direction)
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            if (transform.position.x > startposition.x+ attackdistance)
            {
                state2bool = false;
                state2start = false;
            }
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            if (transform.position.x < startposition.x- attackdistance)
            {
                state2bool = false;
                state2start = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && charController.invincibility == false)
        {
            Debug.Log("in");
            healthsystem.health--;
            charController.takedamage = true;
            charController.damagedirection = direction;
            stop = true;
            StartCoroutine(stopco());
        }
    }

    IEnumerator stopco()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(3);
            stop = false;
            StopCoroutine(stopco());

        }

    }
}
