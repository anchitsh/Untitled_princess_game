using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontroller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    private SpriteRenderer spriteren;

    float x;
    bool goinup, comingdown, landed, gp, block, attack, run, walk, runattack, idleattack, walkattack, takedamage, damagedir;
    public bool sprite_direction;/// left = false, right = true
    bool sprite;
    int health;
    private void Awake()
    {
        spriteren = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        ani.SetInteger("jumpstate", 0);
        sprite_direction = false;

        sprite = spriteren.flipX;
    }

    // Update is called once per frame
    void Update()
    {
    
        x = Input.GetAxisRaw("Horizontal");
        goinup = charController.goinup;
        comingdown = charController.comingdown;
        landed = charController.landed;
        gp = charController.groundpound;
        block = charController.block;
        attack = charController.attack;
        run = charController.run;
        walk = charController.walk;
        runattack = charController.runattack;
        idleattack = charController.idleattack;
        walkattack = charController.walkattack;
        takedamage = charController.takedamage;
        damagedir = charController.damagedirection;
        //flipsprite();
        if (takedamage)
        {
            health = healthsystem.health;
            if (health >= 0)
            {
                ani.SetBool("takedamage", true);
                if (damagedir)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
            }
            else if(health == -1)
            {
                ani.SetBool("dead", true);
                if (damagedir)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
        else
        {
            ani.SetBool("takedamage", false);
        }
        if (Input.GetKey("right"))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (Input.GetKey("left"))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }

        if (block == false )
        {
            
            /*
            if (x == 0)
            {
                ani.SetBool("idle", true);
                ani.SetBool("run", false);
            }
            else if (x != 0)
            {
                ani.SetBool("run", true);
                ani.SetBool("idle", false);
            }*/

            if(run == false && walk == false)
            {
                ani.SetBool("idle", true);
                ani.SetBool("run", false);
                ani.SetBool("walk", false);
                ani.SetBool("attack", false);
                ani.SetBool("walkattack", false);
                if (idleattack == true)
                {
                    ani.SetBool("idleattack", true);
                }
                else
                {
                    ani.SetBool("idleattack", false); 
                }
            }
            else if(run)
            {
                ani.SetBool("run", true);
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("idleattack", false);
                ani.SetBool("walkattack", false);
                if (runattack == true)
                {
                    ani.SetBool("attack", true);
                }
                else
                {
                    ani.SetBool("attack", false);
                }
                
            }
            else if (walk)
            {
                ani.SetBool("walk", true);
                ani.SetBool("idle", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", false);
                ani.SetBool("idleattack", false);
                if (walkattack == true)
                {
                    ani.SetBool("walkattack", true);
                }
                else
                {
                    ani.SetBool("walkattack", false);
                }
            }


        }
        if(block == true)
        {
            ani.SetBool("block", true);
            ani.SetBool("idleattack", false);
        }
        else if (block == false)
        {
            ani.SetBool("block", false);
        }


        if (gp)
        {
            goinup = false;
            comingdown = false;
            ani.SetInteger("jumpstate", 4);
        }
        if (goinup)
        {
            ani.SetInteger("jumpstate", 1);

        }

        else if (comingdown)
        {
            ani.SetInteger("jumpstate", 2);

        }

        else if (landed)
        {
            ani.SetInteger("jumpstate", 3);
        }


    }


    void flipsprite()
    {
        
        bool flipsorite = (sprite ? (x < -0.01f) : (x > 0.01f));
        if (flipsorite == true)
        {
            sprite = !sprite;
            //spriteren.flipX = !spriteren.flipX;
            transform.localRotation = Quaternion.Euler(0, 180, 0);


            sprite_direction = !sprite_direction;
            //fixcoliders();
        }


    }


}
