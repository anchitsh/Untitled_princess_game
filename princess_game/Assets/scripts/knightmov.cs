using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightmov : MonoBehaviour
{
    public GameObject positionA, positionB;
    bool positionAbool, positionBbool;
    // float start_pos;
    // float end_pos;
    // public float units_mov;
    Rigidbody2D rb, player;
    public bool direction;
    public float velocity, cornerwaittime;
    public bool movebool;
    private SpriteRenderer spriteren;
    bool corbool;
    Animator ani;
    float playerpos, enpos;
    GameObject pl;
    public float playerDistance, attackDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  start_pos = transform.position.x;
        // end_pos = start_pos - units_mov;
        direction = true;
        movebool = true;
        spriteren = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();

        pl = GameObject.FindWithTag("Player");
        player = pl.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
        playerpos = player.transform.position.x;
        enpos = rb.transform.position.x;
        float distance = Mathf.Abs(playerpos - enpos);
        if(distance < attackDistance)
        {
            state3();
            movebool = false;
        }
        else if (distance < playerDistance)
        {
            state2();
            movebool = true;
            ani.SetBool("attack", false);
        }
        else
        {
            state1();
            ani.SetBool("attack", false);
        }
       

        if (movebool)
        {
            move();
            ani.SetBool("walk", true);
        }
        else
        {
            ani.SetBool("walk", false);
        }
    }
    void state1()
    {
        checkdirection();
    }

    void state2()
    {
        if (playerpos>enpos)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }
    }
    void state3()
    {
        ani.SetBool("attack", true);
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
    void flipsprite()
    {
        spriteren.flipX = !spriteren.flipX;
    }
    void checkdirection()
    {
        float currentpos = transform.position.x;
        if (direction == false)
        {
            if (currentpos <= positionA.transform.position.x)
            {
                direction = true;
                movebool = false;
                corbool = true;
                StartCoroutine(waittime());
            }
        }

        if (direction == true)
        {
            if (currentpos >= positionB.transform.position.x)
            {

                movebool = false;
                direction = false;
                corbool = true;
                StartCoroutine(waittime());
            }
        }



    }
    void move()
    {
        if (direction)
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
        }
           
    }
    void attack()
    {
        if(charController.invincibility == false && charController.block == false)
        {
            charController.takedamage = true;
            charController.damagedirection = direction;
            healthsystem.health--;
        }
    }
    IEnumerator waittime()
    {
        while (corbool)
        {
            yield return new WaitForSeconds(cornerwaittime);
            movebool = true;
            

            corbool = false;

        }
        StopCoroutine(waittime());
    }
}
