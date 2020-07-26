using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydeath : MonoBehaviour
{
    public bool death;
    Animator ani;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
        ani = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(death == true)
        {
            ani.SetBool("dead", true);
        }
    }

    void kill()
    {
        Destroy(gameObject);
    }
    void turnoffcollider()
    {
        col.enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }
}
