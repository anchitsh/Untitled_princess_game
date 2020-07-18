using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontroller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    private SpriteRenderer spriteren;

    
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
        float x = Input.GetAxisRaw("Horizontal");
        bool goinup = charController.goinup;
        bool comingdown = charController.comingdown;
        bool landed = charController.landed;
        bool gp = charController.groundpound;
        bool flipsorite = (spriteren.flipX ? (x > 0.01f) : (x < -0.01f));
        if (flipsorite)
        {
            spriteren.flipX = !spriteren.flipX;
        }


        if (x == 0)
        {
            ani.SetBool("idle", true);
            ani.SetBool("moving", false);
        }
        else if (x != 0)
        {
            ani.SetBool("moving", true);
            ani.SetBool("idle", false);
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
