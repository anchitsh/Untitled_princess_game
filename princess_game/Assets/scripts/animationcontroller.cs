using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontroller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    private SpriteRenderer spriteren;

    float x;
    bool goinup, comingdown, landed, gp, block, attack, run, walk, runattack;
    private void Awake()
    {
        spriteren = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        ani.SetInteger("jumpstate", 0);
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
        Debug.Log("runattack" + runattack);
        if (block == false )
        {
            bool flipsorite = (spriteren.flipX ?  (x < -0.01f) :  (x > 0.01f));
            if (flipsorite == true)
            {
                spriteren.flipX = !spriteren.flipX;
            }
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
            }
            else if(run)
            {
                ani.SetBool("run", true);
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                if (runattack == true)
                {
                    Debug.Log("in");
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
            }



        }
        if(block == true)
        {
            ani.SetBool("block", true);
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
}
