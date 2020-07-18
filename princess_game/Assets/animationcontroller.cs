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
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Debug.Log(x);
        
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
        if (x != 0)
        {
            ani.SetBool("moving", true);
            ani.SetBool("idle", false);
        }

    }
}
